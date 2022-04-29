using System;
using System.IO;
using System.IO.Ports;

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

        public override Commands.BoardResponse GetBoardData(BoardClass boardClass, byte instance, BoardCommand cmd)
        {
            return SendCmd(Commands.CmdType.Request, boardClass, instance, cmd);
        }

        public override Commands.BoardResponse GetBoardData(BoardClass boardClass, BoardCommand cmd)
        {
            return SendCmd(Commands.CmdType.Request, boardClass, null, cmd);
        }

        public override Commands.BoardResponse SetBoardData<T>(BoardClass boardClass, byte instance, BoardCommand<T> cmd, T value, ulong address = 0)
        {
            return SendCmd(Commands.CmdType.Write, boardClass, null, cmd);
        }

        public Commands.BoardResponse SendCmd(Commands.CmdType type, BoardClass classId, byte? instance, BoardCommand cmd, ulong data = 0, ulong addr = 0)
        {
            string cmdBuffer = classId.Prefix + ".";
            if (instance != null)
                cmdBuffer += $"{instance}.";
            cmdBuffer += cmd.Name;
            switch (type)
            {
                case Commands.CmdType.Request:
                    cmdBuffer += '?';
                    break;
                case Commands.CmdType.Write:
                    cmdBuffer += '=';
                    cmdBuffer += data;
                    break;
                case Commands.CmdType.Info:
                    cmdBuffer += '!';
                    break;
            }

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
                        responseAddr = addr;
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
            }
            return null;

        }
    }
}
