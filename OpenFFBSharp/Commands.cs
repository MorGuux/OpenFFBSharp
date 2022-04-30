using System;

namespace OpenFFBoard
{
    public static class Commands
    {
        public class FFBAxis : BoardClass
        {
            private readonly Board _board;
            public override ushort ClassId => 0xA01;
            public override string Prefix => "axis";

            private BoardCommand<long> id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);
            private BoardCommand<string> name = new BoardCommand<string>("name", 0x80000002, "Name of class", CmdTypes.Get);
            private BoardCommand<string> help = new BoardCommand<string>("help", 0x80000003, "Help for commands", CmdTypes.Get);
            private BoardCommand<long> cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

            private BoardCommand<long> instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number",
                CmdTypes.Get);

            private BoardCommand<ushort> power =
                new BoardCommand<ushort>("power", 0x0, "Overall force strength", CmdTypes.Get | CmdTypes.Set);

            private BoardCommand<ushort> degrees =
                new BoardCommand<ushort>("degrees", 0x1, "Rotation range in deg", CmdTypes.Get | CmdTypes.Set);

            private BoardCommand<byte> esgain =
                new BoardCommand<byte>("esgain", 0x2, "Endstop stiffness", CmdTypes.Get | CmdTypes.Set);

            private BoardCommand<bool> zeroenc = new BoardCommand<bool>("zeroenc", 0x3, "Zero axis", CmdTypes.Get);
            private BoardCommand<bool> invert = new BoardCommand<bool>("invert", 0x4, "Invert axis", CmdTypes.Get | CmdTypes.Set);

            private BoardCommand<byte> idlespring =
                new BoardCommand<byte>("idlespring", 0x5, "Idle spring strength", CmdTypes.Get | CmdTypes.Set);

            private BoardCommand<byte> axisdamper = new BoardCommand<byte>("axisdamper", 0x6, "Independent damper effect",
                CmdTypes.Get | CmdTypes.Set);

            private BoardCommand<string> enctype = new BoardCommand<string>("enctype", 0x7, "Encoder type get/set/list",
                CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

            private BoardCommand<string> drvtype = new BoardCommand<string>("drvtype", 0x8, "Motor driver type get/set/list",
                CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

            private BoardCommand<long> pos = new BoardCommand<long>("pos", 0x9, "Encoder position", CmdTypes.Get);

            private BoardCommand<long> maxspeed =
                new BoardCommand<long>("maxspeed", 0xA, "Speed limit in deg/s", CmdTypes.Get | CmdTypes.Set);

            private BoardCommand<long> maxtorquerate = new BoardCommand<long>("maxtorquerate", 0xB, "Torque rate limit in counts/ms",
                CmdTypes.Get | CmdTypes.Set);

            private BoardCommand<byte> fxratio = new BoardCommand<byte>("fxratio", 0xC,
                "Effect ratio. Reduces effects excluding endstop. 255=100%", CmdTypes.Get | CmdTypes.Set);

            private BoardCommand<long> curtorque = new BoardCommand<long>("curtorque", 0xD, "Axis torque", CmdTypes.Get);
            private BoardCommand<long> curpos = new BoardCommand<long>("curpos", 0xE, "Axis position", CmdTypes.Get);

            internal FFBAxis(Board board)
            {
                _board = board;
            }

            /// <summary>
            /// ID of class
            /// </summary>
            /// <returns></returns>
            public long GetId()
            {
                return id.GetValue(_board, this);
            }

            /// <summary>
            /// Name of class
            /// </summary>
            /// <returns></returns>
            public string GetName()
            {
                if (_board is Serial)
                    return name.GetValue(_board, this);
                else
                    throw new NotSupportedException("Cannot read name of a class using the HID system.");
            }

            /// <summary>
            /// Prints help for commands
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetHelp()
            {
                if (_board is Serial)
                    return help.GetValue(_board, this);
                else
                    throw new NotSupportedException("Cannot read help of a class using the HID system.");
            }

            /// <summary>
            /// Command handler index
            /// </summary>
            /// <returns></returns>
            public long GetCmdUid()
            {
                return cmduid.GetValue(_board, this);
            }

            /// <summary>
            /// Command handler instance number
            /// </summary>
            /// <returns></returns>
            public long GetInstance()
            {
                return instance.GetValue(_board, this);
            }

            /// <summary>
            /// Overall force strength
            /// </summary>
            /// <returns></returns>
            public long GetPower()
            {
                return power.GetValue(_board, this);
            }

            /// <summary>
            /// Set Overall force strength
            /// </summary>
            /// <returns></returns>
            public bool SetPower(ushort newPower)
            {
                var query = power.SetValue(_board, this, newPower);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == power;
            }

            /// <summary>
            /// Rotation range in deg
            /// </summary>
            /// <returns></returns>
            public long GetRotationDegrees()
            {
                return degrees.GetValue(_board, this);
            }

            /// <summary>
            /// Endstop stiffness
            /// </summary>
            /// <returns></returns>
            public long GetEndstopGain()
            {
                return esgain.GetValue(_board, this);
            }

            /// <summary>
            /// Zero axis
            /// </summary>
            /// <returns>True if successful, false otherwise</returns>
            public bool ZeroEncoder()
            {
                var query = zeroenc.GetResponse(_board, this);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == zeroenc;
            }

            /// <summary>
            /// Get invert axis
            /// </summary>
            /// <returns></returns>
            public bool GetInvertAxis()
            {
                return invert.GetValue(_board, this);
            }

            /// <summary>
            /// Set invert axis
            /// </summary>
            /// <returns></returns>
            public bool SetInvertAxis(bool newInvert)
            {
                var query = invert.SetValue(_board, this, newInvert);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == invert;
            }

            /// <summary>
            /// Idle spring strength
            /// </summary>
            /// <returns></returns>
            public long GetIdleSpring()
            {
                return idlespring.GetValue(_board, this);
            }

            /// <summary>
            /// Independent damper effect
            /// </summary>
            /// <returns></returns>
            public long GetAxisDamper()
            {
                return axisdamper.GetValue(_board, this);
            }

            /// <summary>
            /// Encoder type
            /// </summary>
            /// <returns></returns>
            public string GetEncoderType()
            {
                return enctype.GetValue(_board, this);
            }

            /// <summary>
            /// Motor driver type
            /// </summary>
            /// <returns></returns>
            public string GetDriverType()
            {
                return drvtype.GetValue(_board, this);
            }

            /// <summary>
            /// Encoder position
            /// </summary>
            /// <returns></returns>
            public long GetEncoderPosition()
            {
                return pos.GetValue(_board, this);
            }

            /// <summary>
            /// Speed limit in deg/s
            /// </summary>
            /// <returns></returns>
            public long GetMaxSpeed()
            {
                return maxspeed.GetValue(_board, this);
            }

            /// <summary>
            /// Torque rate limit in counts/ms
            /// </summary>
            /// <returns></returns>
            public long GetMaxTorqueRate()
            {
                return maxtorquerate.GetValue(_board, this);
            }

            /// <summary>
            /// Effect ratio. Reduces effects excluding endstop, 255 = 100%
            /// </summary>
            /// <returns></returns>
            public long GetEffectsRatio()
            {
                return fxratio.GetValue(_board, this);
            }

            /// <summary>
            /// Axis torque
            /// </summary>
            /// <returns></returns>
            public long GetAxisTorque()
            {
                return curtorque.GetValue(_board, this);
            }

            /// <summary>
            /// Axis position
            /// </summary>
            /// <returns></returns>
            public long GetAxisPosition()
            {
                return curpos.GetValue(_board, this);
            }
        }
        public class System : BoardClass
        {
            private readonly Board _board;
            public override ushort ClassId => 0x0;
            public override string Prefix => "sys";

            private BoardCommand<string> help = new BoardCommand<string>("help", 0x0, "Help for commands", CmdTypes.Get);
            private BoardCommand<bool> save = new BoardCommand<bool>("save", 0x1, "Write all settings to flash", CmdTypes.Get);
            private BoardCommand<bool> reboot = new BoardCommand<bool>("reboot", 0x2, "Reset chip", CmdTypes.Get);
            private BoardCommand<bool> dfu = new BoardCommand<bool>("dfu", 0x3, "Reboot into DFU boot-loader", CmdTypes.Get);
            private BoardCommand<string> lsmain = new BoardCommand<string>("lsmain", 0x6, "List available main classes", CmdTypes.Get);
            private BoardCommand<string> lsactive = new BoardCommand<string>("lsactive", 0x8, "List available main classes", CmdTypes.Get);
            private BoardCommand<uint> vint = new BoardCommand<uint>("vint", 0xE, "Internal voltage(mV)", CmdTypes.Get);
            private BoardCommand<uint> vext = new BoardCommand<uint>("vext", 0xF, "External voltage(mV)", CmdTypes.Get);
            private BoardCommand<byte> main = new BoardCommand<byte>("main", 0x7, "Query or change main class", CmdTypes.Get | CmdTypes.Set);
            private BoardCommand<string> swver = new BoardCommand<string>("swver", 0x4, "Firmware version", CmdTypes.Get);
            private BoardCommand<string> hwtype = new BoardCommand<string>("hwtype", 0x5, "Hardware type", CmdTypes.Get);
            private BoardCommand<ulong> flashraw = new BoardCommand<ulong>("flashraw", 0xD, "Write value to flash address", CmdTypes.Set);
            private BoardCommand<string> flashdump = new BoardCommand<string>("flashdump", 0xC, "Read all flash variables)", CmdTypes.Get);
            private BoardCommand<string> errors = new BoardCommand<string>("errors", 0xA, "Read error states", CmdTypes.Get);
            private BoardCommand<bool> errorsclr = new BoardCommand<bool>("errorsclr", 0xB, "Reset errors", CmdTypes.Get);
            private BoardCommand<ulong> heapfree = new BoardCommand<ulong>("heapfree", 0x11, "Memory info", CmdTypes.Get);
            private BoardCommand<bool> format = new BoardCommand<bool>("format", 0x9, "Erase all stored values", CmdTypes.Set);
            private BoardCommand<bool> debug = new BoardCommand<bool>("debug", 0x13, "Enable or disable debug commands", CmdTypes.Get | CmdTypes.Set);
            private BoardCommand<string> devid = new BoardCommand<string>("devid", 0x14, "Get chip dev id and rev id", CmdTypes.Get);

                internal System(Board board)
            {
                _board = board;
            }

            /// <summary>
            /// Prints help for commands
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetHelp()
            {
                if (_board is Serial)
                    return help.GetValue(_board, this);
                else
                    throw new NotSupportedException("Cannot read help of a class using the HID system.");
            }

            /// <summary>
            /// Write all settings to flash
            /// </summary>
            /// <returns>True if successful, false otherwise</returns>
            public bool Save()
            {
                var query = save.SetValue(_board, this, true);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == save;
            }

            /// <summary>
            /// Reset chip
            /// </summary>
            public void Reboot()
            {
                reboot.GetValue(_board, this);
            }

            /// <summary>
            /// Reboot into DFU boot-loader
            /// </summary>
            public void DFU()
            {
                dfu.GetValue(_board, this);
            }

            /// <summary>
            /// List available main classes
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetMainClasses()
            {
                if (_board is Serial)
                    return lsmain.GetValue(_board, this);
                else
                    throw new NotSupportedException("Cannot read help of a class using the HID system.");
            }

            /// <summary>
            /// List active main classes
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetActiveClasses()
            {
                //TODO HID support
                if (_board is Serial)
                    return lsactive.GetValue(_board, this);
                else
                    throw new NotSupportedException("Cannot read help of a class using the HID system.");
            }

            /// <summary>
            /// Internal voltage (mV)
            /// </summary>
            /// <returns></returns>
            public float GetInternalVoltage()
            {
                return (float)vint.GetValue(_board, this) / 1000;
            }

            /// <summary>
            /// External voltage (mV)
            /// </summary>
            /// <returns></returns>
            public float GetExternalVoltage()
            {
                return (float)vext.GetValue(_board, this) / 1000;
            }

            /// <summary>
            /// Active main class
            /// </summary>
            /// <returns></returns>
            public ulong GetActiveMainClass()
            {
                return main.GetValue(_board, this);
            }

            /// <summary>
            /// Set active main class
            /// </summary>
            /// <returns></returns>
            public bool SetActiveMainClass(byte mainClass)
            {
                var query = main.SetValue(_board, this, mainClass);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == main;
            }

            /// <summary>
            /// Firmware version
            /// </summary>
            /// <returns></returns>
            public string GetFirmwareVersion()
            {
                if (_board is Serial)
                    return swver.GetValue(_board, this);
                else
                    throw new NotSupportedException("Cannot read firmware version of the board using the HID system.");
            }

            /// <summary>
            /// Hardware type
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetHardwareType()
            {
                if (_board is Serial)
                    return hwtype.GetValue(_board, this);
                else
                    throw new NotSupportedException("Cannot read hardware type of the board using the HID system.");
            }

            /// <summary>
            /// Write value to flash address
            /// </summary>
            /// <returns></returns>
            public bool WriteToFlash(ulong address, ulong value)
            {
                var query = flashraw.SetValue(_board, this, value, address);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == flashraw;
            }

            /// <summary>
            /// Read all flash variables (val:adr)
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetFlashDump()
            {
                if (_board is Serial)
                    return flashdump.GetValue(_board, this);
                else
                    throw new NotSupportedException("Cannot read flash dump of the board using the HID system.");
            }

            /// <summary>
            /// Read error states
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetErrors()
            {
                if (_board is Serial)
                    return errors.GetValue(_board, this);
                else
                    throw new NotSupportedException("Cannot read errors on the board using the HID system.");
            }

            /// <summary>
            /// Clear errors
            /// </summary>
            /// <returns></returns>
            public bool ClearErrors()
            {
                return errorsclr.GetValue(_board, this);
            }

            /// <summary>
            /// Memory info
            /// </summary>
            /// <returns></returns>
            public ulong GetMemoryHeapFree()
            {
                return heapfree.GetValue(_board, this);
            }

            /// <summary>
            /// Erase all stored flash values
            /// </summary>
            /// <returns></returns>
            public bool Format()
            {
                var query = format.SetValue(_board, this, true);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == format;
            }

            /// <summary>
            /// Debug commands status
            /// </summary>
            /// <returns></returns>
            public bool GetDebugMode()
            {
                return debug.GetValue(_board, this);
            }

            /// <summary>
            /// Set debug commands status
            /// </summary>
            /// <returns></returns>
            public bool SetDebugMode(bool state)
            {
                var query = debug.SetValue(_board, this, state);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == debug;
            }

            /// <summary>
            /// Get chip dev id and rev id
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetDeviceId()
            {
                if (_board is Serial)
                    return devid.GetValue(_board, this);
                else
                    throw new NotSupportedException("Cannot read device Id of the board using the HID system.");
            }

        }

        public class BoardResponse
        {
            public CmdType Type { get; set; }
            public ushort ClassId { get; set; }
            public byte Instance { get; set; }
            public BoardCommand Cmd { get; set; }
            public object Data { get; set; }
            public ulong Address { get; set; }
        }

        public enum CmdType
        {
            Write = 0,
            Request = 1,
            Info = 2,
            WriteAddress = 3,
            RequestAddress = 4,
            Acknowledgment = 10,
            NotFound = 13,
            Notification = 14,
            Error = 15
        }

        public enum FFBController : ulong
        {
            Id = 0x80000001,
            Name = 0x80000002,
            Help = 0x80000003,
            CmdUid = 0x80000005,
            Instance = 0x80000004,
            FFBActive = 0x0,
            BtnTypes = 0x2,
            AddBtn = 0x4,
            LsBtn = 0x3,
            AinTypes = 0x5,
            LsAin = 0x6,
            AddAin = 0x7,
            HIDRate = 0x8,
            HIDSendSpd = 0x9
        }

        public enum FFBEffects : ulong
        {
            Id = 0x80000001,
            Name = 0x80000002,
            Help = 0x80000003,
            CmdUid = 0x80000005,
            Instance = 0x80000004,
            FilterCFFreq = 0x0,
            FilterCFQ = 0x1,
            Spring = 0x3,
            Friction = 0x4,
            Damper = 0x5,
            Inertia = 0x6,
            Effects = 0x2
        }
    }

    public abstract class BoardClass
    {
        public abstract ushort ClassId { get; }
        public abstract string Prefix { get; }
        [Flags]
        public enum CmdTypes
        {
            Get,
            Set,
            Info,
        }
    }

    public class BoardCommand<T> : BoardCommand
    {
        public override string Name { get; }
        public override ulong Id { get; }
        public override string Description { get; }

        public BoardClass.CmdTypes Types { get; set; }

        public BoardCommand(string name, ulong id, string description, BoardClass.CmdTypes types)
        {
            this.Name = name;
            this.Id = id;
            this.Description = description;
            this.Types = types;
        }

        public T GetValue(Board board, BoardClass boardClass)
        {
            if (Types.HasFlag(BoardClass.CmdTypes.Get))
            {
                Commands.BoardResponse response = board.GetBoardData(boardClass, this);
                return (T)Convert.ChangeType(response.Data, typeof(T));
            }
            else
            {
                throw new Exception("Command does not support get request");
            }   
        }

        public Commands.BoardResponse SetValue(Board board, BoardClass boardClass, T value)
        {
            if (Types.HasFlag(BoardClass.CmdTypes.Set))
            {
                return board.SetBoardData(boardClass, 0, this, value);
            }
            else
            {
                throw new Exception("Command does not support set request");
            }
        }

        public Commands.BoardResponse SetValue(Board board, BoardClass boardClass, T value, ulong address)
        {
            if (Types.HasFlag(BoardClass.CmdTypes.Set))
            {
                return board.SetBoardData(boardClass, 0, this, value, address);
            }
            else
            {
                throw new Exception("Command does not support set request");
            }
        }

        public string GetInfo(Board board, BoardClass boardClass)
        {
            if (Types.HasFlag(BoardClass.CmdTypes.Info))
            {
                Commands.BoardResponse response = board.GetBoardData(boardClass, this);
                return Convert.ToString(response.Data);
            }
            else
            {
                throw new Exception("Command does not support info request");
            }
            
        }

        public Commands.BoardResponse GetResponse(Board board, BoardClass boardClass)
        {
            return board.GetBoardData(boardClass, this);
        }
    }

    public abstract class BoardCommand
    {
        public abstract string Name { get; }
        public abstract ulong Id { get; }
        public abstract string Description { get; }
    }
}
