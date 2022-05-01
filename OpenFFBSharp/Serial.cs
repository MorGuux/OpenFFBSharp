using System;
using System.IO;
using System.IO.Ports;
using static OpenFFBoard.Commands;

namespace OpenFFBoard
{
    public class Serial : Board
    {

        private readonly SerialPort serialPort;

        public Serial(string comPort, int baudRate)
        {
            serialPort = new SerialPort(comPort, baudRate);
        }

        public override void Connect()
        {
            serialPort.Handshake = Handshake.None;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.DtrEnable = true;
            serialPort.ReadTimeout = 200;
            serialPort.WriteTimeout = 50;
            try
            {
                serialPort.Open();
                IsConnected = serialPort.IsOpen;
            }
            catch
            {
                IsConnected = false;
                throw new IOException("Could not connect to the OpenFFBoard on " + serialPort.PortName);
            }
        }

        public override void Disconnect()
        {
            serialPort.Close();
        }

        public static string[] GetBoards()
        {
            //TODO Filter to just OpenFFBoards
            return SerialPort.GetPortNames();
        }

        public override Commands.BoardResponse GetBoardData(BoardClass boardClass, byte? instance, BoardCommand cmd, ulong? address, bool info = false)
        {
            return SendCmd(boardClass, instance, cmd, address, null, info);
        }

        public override Commands.BoardResponse SetBoardData<T>(BoardClass boardClass, byte instance, BoardCommand<T> cmd, T value, ulong? address)
        {
            return SendCmd(boardClass, null, cmd, address, value is bool ? (Convert.ToBoolean(value) ? "1" : "0") : Convert.ToString(value), false);
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

            serialPort.WriteLine(cmdBuffer);
            string response = "";
            do
                response += serialPort.ReadExisting();
            while (!response.Contains("]"));
            response = response.Trim();

            if (response.StartsWith("["))
            {
                response = response.TrimStart('[');
                response = response.TrimEnd(']');
                string[] splitResponse = response.Split('|');
                if (splitResponse[0] == cmdBuffer)
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
                        responseAddr = address ?? 0;
                    }
                    return new Commands.BoardResponse
                    {
                        Type = (Commands.CmdType)cmd.Id,
                        ClassId = classId.ClassId,
                        Instance = instance ?? 0,
                        Cmd = cmd,
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
                            ClassId = classId.ClassId,
                            Instance = instance ?? 0,
                            Cmd = cmd,
                            Data = splitResponse[1],
                            Address = 0
                        };
                    }
                }
            }

            return null;
        }

        public string ConstructMessage(BoardClass classId, byte? instance, BoardCommand cmd, ulong? address, string data, bool info)
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
                    cmdBuffer += address;
                    break;
                case CmdType.Info:
                    cmdBuffer += '!';
                    break;
            }
            return cmdBuffer;
        }

        /// <summary>
        /// Get the name of the COM port
        /// </summary>
        /// <returns>COM port name (typically COMx)</returns>
        public string GetPort()
        {
            return serialPort.PortName;
        }
    }
}
