using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using static OpenFFBoard.Commands;

namespace OpenFFBoard
{
    public class Serial : Board
    {
        private readonly SerialPort _serialPort;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private const int Timeout = 500;

        internal class SerialCommand
        {
            public readonly BoardClass boardClass;
            public readonly byte? instance;
            public readonly BoardCommand cmd;
            public readonly ulong? address;
            public readonly string data;
            public readonly bool info = false;

            public SerialCommand(BoardClass boardClass, byte? instance, BoardCommand cmd, ulong? address, string data, bool info = false)
            {
                this.boardClass = boardClass;
                this.instance = instance;
                this.cmd = cmd;
                this.address = address;
                this.data = data;
                this.info = info;
            }
        }

        public Serial(string comPort, int baudRate)
        {
            _serialPort = new SerialPort(comPort, baudRate);
        }

        public override void Connect()
        {
            _serialPort.Handshake = Handshake.None;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.DtrEnable = true;
            _serialPort.ReadTimeout = 200;
            _serialPort.WriteTimeout = 50;
            try
            {
                _serialPort.Open();
                IsConnected = _serialPort.IsOpen;
            }
            catch(Exception ex)
            {
                IsConnected = false;
                throw new IOException("Could not connect to the OpenFFBoard on " + _serialPort.PortName, ex);
            }
        }

        public override void Disconnect()
        {
            _serialPort.Close();
        }

        public static string[] GetBoards()
        {
            //TODO Filter to just OpenFFBoards
            return SerialPort.GetPortNames();
        }

        internal override Commands.BoardResponse GetBoardData(BoardClass boardClass, byte? instance, BoardCommand cmd, ulong? address, bool info = false)
        {
            SerialCommand command = new SerialCommand(boardClass, instance, cmd, address, null, info);
            return Task.Run(() => SendCmd(command)).Result;
        }

        internal override Commands.BoardResponse SetBoardData<T>(BoardClass boardClass, byte instance, BoardCommand<T> cmd, T value, ulong? address)
        {
            SerialCommand command = new SerialCommand(boardClass, instance, cmd, address, value is bool ? (Convert.ToBoolean(value) ? "1" : "0") : Convert.ToString(value), false);
            return Task.Run(() => SendCmd(command)).Result;
        }

        internal async Task<BoardResponse> SendCmd(SerialCommand cmd)
        {
            await _semaphore.WaitAsync();
            string response;
            try
            {
                await WriteLineAsync(ConstructMessage(cmd));

                var task = ReadCommandAsync();
                if (await Task.WhenAny(task, Task.Delay(Timeout)) == task)
                {
                    await task;
                    response = task.Result;
                }
                else
                {
                    return null;
                }
            }
            catch (IOException)
            {
                return null;
            }
            finally
            {
                _semaphore.Release();
            }
            return Task.Run(() => ParseBoardResponse(cmd, response)).Result;
        }

        /// <summary>
        /// Read a line from the SerialPort asynchronously
        /// </summary>
        /// <returns>A raw command read from the input</returns>
        public async Task<string> ReadCommandAsync()
        {
            try
            {
                byte[] buffer = new byte[1];
                string ret = string.Empty;

                // Read the input one byte at a time, convert the
                // byte into a char, add that char to the overall
                // response string, once the response string ends
                // with the line ending then stop reading
                while (true)
                {
                    await _serialPort.BaseStream.ReadAsync(buffer, 0, 1);
                    ret += _serialPort.Encoding.GetString(buffer);

                    if (ret.EndsWith("]"))
                        return ret.Trim();
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                throw new IOException("Could not read data from the OpenFFBoard.", ex);
            }
        }

        /// <summary>
        /// Write a line to the SerialPort asynchronously
        /// </summary>
        /// <param name="str">The text to send</param>
        /// <returns></returns>
        public async Task WriteLineAsync(string str)
        {
            try
            {
                byte[] encodedStr =
                    _serialPort.Encoding.GetBytes(str + _serialPort.NewLine);

                await _serialPort.BaseStream.WriteAsync(encodedStr, 0, encodedStr.Length);
                await _serialPort.BaseStream.FlushAsync();
            }
            catch (Exception ex)
            {
                IsConnected = false;
                throw new IOException("Could not write data to the OpenFFBoard.", ex);
            }
            
        }

        public Commands.BoardResponse SendCmd(BoardClass classId, byte? instance, BoardCommand cmd, ulong? address, string data, bool info)
        {
            if (cmd.Types.HasFlag(BoardClass.CmdTypes.Debug))
            {
                BoardCommand<bool> debugCommand = new BoardCommand<bool>("debug", 0x13,
                    "Enable or disable debug commands", BoardClass.CmdTypes.Get | BoardClass.CmdTypes.Set);

                BoardClass systemClass = new Commands.System(null);

                var debugResponse = SendCmd(systemClass, instance, debugCommand, null, data, false);
                //make sure debug mode is enabled
                if ((string)debugResponse.Data == "0")
                {
                    throw new InvalidOperationException("OpenFFBoard has debug mode disabled.");
                }
            }
            string cmdBuffer = ConstructMessage(classId, instance, cmd, address, data, info);

            _serialPort.WriteLine(cmdBuffer);
            string response = "";
            do
                response += _serialPort.ReadExisting();
            while (!response.Contains("]"));
            return ParseBoardResponse(new SerialCommand(classId, instance, cmd, address, data, info), response);
        }

        public async Task<string> SendRawMessage(string message)
        {
            Debug.WriteLine($"Raw message waiting for place in serial queue: {message}");
            await _semaphore.WaitAsync();
            Debug.WriteLine($"Place found, sending raw message: {message}");
            string response;
            try
            {
                await WriteLineAsync(message);

                var task = ReadCommandAsync();
                if (await Task.WhenAny(task, Task.Delay(Timeout)) == task)
                {
                    await task;
                    response = task.Result;
                    Debug.WriteLine($"Raw message response received: {response}");
                }
                else
                {
                    return null;
                }
            }
            catch (IOException)
            {
                return null;
            }
            finally
            {
                _semaphore.Release();
            }

            return response;
        }

        private BoardResponse ParseBoardResponse(SerialCommand cmd, string response)
        {
            Stopwatch sw = Stopwatch.StartNew();

            if (response.StartsWith("["))
            {
                response = response.TrimStart('[');
                response = response.TrimEnd(']');
                string[] splitResponse = response.Split('|');
                if (splitResponse[0] == ConstructMessage(cmd))
                {
                    string[] splitData = splitResponse[1].Split(new char[':'], 1);
                    string responseData;
                    ulong responseAddr;
                    if (splitData.Length >= 2)
                    {
                        responseData = splitData[0];
                        responseAddr = Convert.ToUInt64(splitData[1]);
                    }
                    else
                    {
                        responseData = splitResponse[1];
                        responseAddr = cmd.address ?? 0;
                    }
                    
                    return new Commands.BoardResponse
                    {
                        Type = (Commands.CmdType)cmd.cmd.Id,
                        ClassId = cmd.boardClass.ClassId,
                        Instance = cmd.instance ?? 0,
                        Cmd = cmd.cmd,
                        Data = responseData,
                        Address = responseAddr
                    };
                }
                else
                {
                    //response command doesn't match what was sent
                    if (splitResponse[0] == "sys.0.errors?")
                    {
                        //Error message
                        string[] splitData = splitResponse[1].Trim().Split(':');
                        return new Commands.BoardResponse
                        {
                            Type = Commands.CmdType.Error,
                            ClassId = cmd.boardClass.ClassId,
                            Instance = cmd.instance ?? 0,
                            Cmd = cmd.cmd,
                            Data = splitResponse[1],
                            Address = 0
                        };
                    }
                }
            }

            return null;
        }

        private static string ConstructMessage(BoardClass classId, byte? instance, BoardCommand cmd, ulong? address, string data, bool info)
        {
            CmdType type;
            if (info)
                type = CmdType.Info;
            else if (address == null && data == null)
                type = CmdType.Request;
            else if (address != null && data == null)
                type = CmdType.RequestAddress;
            else if (address == null)
                type = CmdType.Write;
            else
                type = CmdType.WriteAddress;

            string cmdBuffer = classId.Prefix + ".";
            if (instance != null)
                cmdBuffer += $"{instance}.";
            cmdBuffer += cmd.Name;

            switch (type)
            {
                case CmdType.Request:
                    cmdBuffer += '?';
                    break;
                case CmdType.RequestAddress:
                    cmdBuffer += '?';
                    cmdBuffer += address;
                    break;
                case CmdType.Write:
                    cmdBuffer += '=';
                    cmdBuffer += data;
                    break;
                case CmdType.WriteAddress:
                    cmdBuffer += '=';
                    cmdBuffer += data;
                    cmdBuffer += '?';
                    cmdBuffer += address;
                    break;
                case CmdType.Info:
                    cmdBuffer += '!';
                    break;
            }
            return cmdBuffer;
        }

        private static string ConstructMessage(SerialCommand command)
        {
            return ConstructMessage(
                command.boardClass, 
                command.instance, 
                command.cmd, 
                command.address, 
                command.data,
                command.info);
        }

        /// <summary>
        /// Get the name of the COM port
        /// </summary>
        /// <returns>COM port name (typically COMx)</returns>
        public string GetPort()
        {
            return _serialPort.PortName;
        }
    }
}
