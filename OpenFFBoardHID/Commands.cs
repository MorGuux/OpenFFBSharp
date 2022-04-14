using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenFFBoard
{
    public static class Commands
    {
        public class FFBAxis : BoardClass
        {
            private readonly Board _board;
            public override ushort ClassId => 0xA01;
            public override string Prefix => "axis";

            public override BoardCommand[] Commands => new BoardCommand[]
            {
                new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get),
                new BoardCommand<string>("name", 0x80000002, "Name of class", CmdTypes.Get),
                new BoardCommand<string>("help", 0x80000003, "Help for commands", CmdTypes.Get),
                new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get),
                new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get),
                new BoardCommand<ushort>("power", 0x0, "Overall force strength", CmdTypes.Get | CmdTypes.Set),
                new BoardCommand<ushort>("degrees", 0x1, "Rotation range in deg", CmdTypes.Get | CmdTypes.Set),
                new BoardCommand<byte>("esgain", 0x2, "Endstop stiffness", CmdTypes.Get | CmdTypes.Set),
                new BoardCommand<bool>("zeroenc", 0x3, "Zero axis", CmdTypes.Get),
                new BoardCommand<bool>("invert", 0x4, "Invert axis", CmdTypes.Get | CmdTypes.Set),
                new BoardCommand<byte>("idlespring", 0x5, "Idle spring strength", CmdTypes.Get | CmdTypes.Set),
                new BoardCommand<byte>("axisdamper", 0x6, "Independent damper effect", CmdTypes.Get | CmdTypes.Set),
                new BoardCommand<string>("enctype", 0x7, "Encoder type get/set/list", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info),
                new BoardCommand<string>("drvtype", 0x8, "Motor driver type get/set/list", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info),
                new BoardCommand<long>("pos", 0x9, "Encoder position", CmdTypes.Get),
                new BoardCommand<long>("maxspeed", 0xA, "Speed limit in deg/s", CmdTypes.Get | CmdTypes.Set),
                new BoardCommand<long>("maxtorquerate", 0xB, "Torque rate limit in counts/ms", CmdTypes.Get | CmdTypes.Set),
                new BoardCommand<byte>("fxratio", 0xC, "Effect ratio. Reduces effects excluding endstop. 255=100%", CmdTypes.Get | CmdTypes.Set),
                new BoardCommand<long>("curtorque", 0xD, "Axis torque", CmdTypes.Get),
                new BoardCommand<long>("curpos", 0xE, "Axis position", CmdTypes.Get)
            };

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
                //return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("id")).Data);
                return Convert.ToInt64(GetCommandFromName("id").)
            }

            /// <summary>
            /// Name of class
            /// </summary>
            /// <returns></returns>
            public string GetName()
            {
                if (_board is Serial)
                    return Convert.ToString(_board.GetBoardData(this, 0, GetCommandFromName("name")).Data);
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
                    return Convert.ToString(_board.GetBoardData(this, 0, GetCommandFromName("help")).Data);
                else
                    throw new NotSupportedException("Cannot read help of a class using the HID system.");
            }

            /// <summary>
            /// Command handler index
            /// </summary>
            /// <returns></returns>
            public long GetCmdUid()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("cmduid")).Data);
            }

            /// <summary>
            /// Command handler instance number
            /// </summary>
            /// <returns></returns>
            public long GetInstance()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("instance")).Data);
            }

            /// <summary>
            /// Overall force strength
            /// </summary>
            /// <returns></returns>
            public long GetPower()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("power")).Data);
            }

            /// <summary>
            /// Set Overall force strength
            /// </summary>
            /// <returns></returns>
            public bool SetPower(ushort power)
            {
                var query = _board.SetBoardData(this, 0, GetCommandFromName("power"), power);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == GetCommandFromName("power");
            }

            /// <summary>
            /// Rotation range in deg
            /// </summary>
            /// <returns></returns>
            public long GetRotationDegrees()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("degrees")).Data);
            }

            /// <summary>
            /// Endstop stiffness
            /// </summary>
            /// <returns></returns>
            public long GetEndstopGain()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("esgain")).Data);
            }

            /// <summary>
            /// Zero axis
            /// </summary>
            /// <returns>True if successful, false otherwise</returns>
            public bool ZeroEncoder()
            {
                var query = _board.GetBoardData(this, 0, GetCommandFromName("zeroenc"));
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == GetCommandFromName("zeroenc");
            }

            /// <summary>
            /// Invert axis
            /// </summary>
            /// <returns></returns>
            public bool InvertAxis()
            {
                var query = _board.GetBoardData(this, 0, GetCommandFromName("invert"));
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == Commands[9];
            }

            /// <summary>
            /// Idle spring strength
            /// </summary>
            /// <returns></returns>
            public long GetIdleSpring()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("idlespring")).Data);
            }

            /// <summary>
            /// Independent damper effect
            /// </summary>
            /// <returns></returns>
            public long GetAxisDamper()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("axisdamper")).Data);
            }

            /// <summary>
            /// Encoder type
            /// </summary>
            /// <returns></returns>
            public long GetEncoderType()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("enctype")).Data);
            }

            /// <summary>
            /// Motor driver type
            /// </summary>
            /// <returns></returns>
            public long GetDriverType()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("drvtype")).Data);
            }

            /// <summary>
            /// Encoder position
            /// </summary>
            /// <returns></returns>
            public long GetEncoderPosition()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("pos")).Data);
            }

            /// <summary>
            /// Speed limit in deg/s
            /// </summary>
            /// <returns></returns>
            public long GetMaxSpeed()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("maxspeed")).Data);
            }

            /// <summary>
            /// Torque rate limit in counts/ms
            /// </summary>
            /// <returns></returns>
            public long GetMaxTorqueRate()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("maxtorquerate")).Data);
            }

            /// <summary>
            /// Effect ratio. Reduces effects excluding endstop, 255 = 100%
            /// </summary>
            /// <returns></returns>
            public long GetEffectsRatio()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("fxratio")).Data);
            }

            /// <summary>
            /// Axis torque
            /// </summary>
            /// <returns></returns>
            public long GetAxisTorque()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("curtorque")).Data);
            }

            /// <summary>
            /// Axis position
            /// </summary>
            /// <returns></returns>
            public long GetAxisPosition()
            {
                return Convert.ToInt64(_board.GetBoardData(this, 0, GetCommandFromName("curpos")).Data);
            }
        }
        public class System : BoardClass
        {
            private readonly Board _board;
            public override ushort ClassId => 0x0;
            public override string Prefix => "sys";

            public override BoardCommand[] Commands => new BoardCommand[]
            {
                new BoardCommand<string>("Help", 0x0, "Help for commands", CmdTypes.Get),
                new BoardCommand<bool>("Save", 0x1, "Write all settings to flash", CmdTypes.Get),
                new BoardCommand<bool>("Reboot", 0x2, "Reset chip", CmdTypes.Get),
                new BoardCommand<bool>("DFU", 0x3, "Reboot into DFU boot-loader", CmdTypes.Get),
                new BoardCommand<string>("LsMain", 0x6, "List available main classes", CmdTypes.Get),
                new BoardCommand<string>("LsActive", 0x8, "List available main classes", CmdTypes.Get),
                new BoardCommand<uint>("Vint", 0xE, "Internal voltage(mV)", CmdTypes.Get),
                new BoardCommand<uint>("Vext", 0xF, "External voltage(mV)", CmdTypes.Get),
                new BoardCommand<byte>("Main", 0x7, "Query or change main class", CmdTypes.Get | CmdTypes.Set),
                new BoardCommand<long>("SwVer", 0x4, "Firmware version", CmdTypes.Get),
                new BoardCommand<long>("HwType", 0x5, "Hardware type", CmdTypes.Get),
                new BoardCommand<bool>("FlashRaw", 0xD, "Write value to flash address", CmdTypes.Set),
                new BoardCommand<string>("FlashDump", 0xC, "Read all flash variables)", CmdTypes.Get),
                new BoardCommand<string>("Errors", 0xA, "Read error states", CmdTypes.Get),
                new BoardCommand<bool>("ErrorsClr", 0xB, "Reset errors", CmdTypes.Get),
                new BoardCommand<long>("HeapFree", 0x11, "Memory info", CmdTypes.Get),
                new BoardCommand<bool>("Format", 0x9, "Erase all stored values", CmdTypes.Set),
                new BoardCommand<bool>("Debug", 0x13, "Enable or disable debug commands", CmdTypes.Get | CmdTypes.Set),
                new BoardCommand<long>("DevId", 0x14, "Get chip dev id and rev id", CmdTypes.Get),
            };

            internal System(Board board)
            {
                _board = board;
            }

            /// <summary>
            /// Print system help
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetHelp()
            {
                if (_board is Serial)
                    return Convert.ToString(_board.GetBoardData(this, 0, Commands[0]).Data);
                else
                    throw new NotSupportedException("Cannot read help of a class using the HID system.");
            }

            /// <summary>
            /// Write all settings to flash
            /// </summary>
            /// <returns>True if successful, false otherwise</returns>
            public bool Save()
            {
                var query = _board.GetBoardData(this, 0, Commands[1]);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == Commands[1];
            }

            /// <summary>
            /// Reset chip
            /// </summary>
            public void Reboot()
            {
                _board.GetBoardData(this, 0, Commands[2]);
            }

            /// <summary>
            /// Reboot into DFU boot-loader
            /// </summary>
            public void DFU()
            {
                _board.GetBoardData(this, 0, Commands[3]);
            }

            /// <summary>
            /// List available main classes
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetMainClasses()
            {
                if (_board is Serial)
                    return Convert.ToString(_board.GetBoardData(this, 0, Commands[4]).Data);
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
                    return Convert.ToString(_board.GetBoardData(this, 0, Commands[5]).Data);
                else
                    throw new NotSupportedException("Cannot read help of a class using the HID system.");
            }

            /// <summary>
            /// Internal voltage (mV)
            /// </summary>
            /// <returns></returns>
            public ulong GetInternalVoltage()
            {
                return Convert.ToUInt64(_board.GetBoardData(this, 0, Commands[6]).Data);
            }

            /// <summary>
            /// External voltage (mV)
            /// </summary>
            /// <returns></returns>
            public ulong GetExternalVoltage()
            {
                return Convert.ToUInt64(_board.GetBoardData(this, 0, Commands[7]).Data);
            }

            /// <summary>
            /// Active main class
            /// </summary>
            /// <returns></returns>
            public ulong GetActiveMainClass()
            {
                return Convert.ToUInt64(_board.GetBoardData(this, 0, Commands[8]).Data);
            }

            /// <summary>
            /// Set active main class
            /// </summary>
            /// <returns></returns>
            public bool SetActiveMainClass(ulong mainClass)
            {
                var query = _board.SetBoardData(this, 0, Commands[9], mainClass);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == Commands[9];
            }

            /// <summary>
            /// Firmware version
            /// </summary>
            /// <returns></returns>
            public string GetFirmwareVersion()
            {
                if (_board is Serial)
                    return Convert.ToString(_board.GetBoardData(this, 0, Commands[10]).Data);
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
                    return Convert.ToString(_board.GetBoardData(this, 0, Commands[11]).Data);
                else
                    throw new NotSupportedException("Cannot read hardware type of the board using the HID system.");
            }

            /// <summary>
            /// Write value to flash address
            /// </summary>
            /// <returns></returns>
            public bool WriteToFlash(ulong address, ulong value)
            {
                var query = _board.SetBoardData(this, 0, Commands[12], value, address);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == Commands[12];
            }

            /// <summary>
            /// Read all flash variables (val:adr)
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetFlashDump()
            {
                if (_board is Serial)
                    return Convert.ToString(_board.GetBoardData(this, 0, Commands[13]).Data);
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
                    return Convert.ToString(_board.GetBoardData(this, 0, Commands[14]).Data);
                else
                    throw new NotSupportedException("Cannot read errors on the board using the HID system.");
            }

            /// <summary>
            /// Clear errors
            /// </summary>
            /// <returns></returns>
            public bool ClearErrors()
            {
                var query = _board.GetBoardData(this, 0, Commands[15]);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == Commands[15];
            }

            /// <summary>
            /// Memory info
            /// </summary>
            /// <returns></returns>
            public ulong GetMemoryHeapFree()
            {
                return Convert.ToUInt64(_board.GetBoardData(this, 0, Commands[16]).Data);
            }

            /// <summary>
            /// Erase all stored flash values
            /// </summary>
            /// <returns></returns>
            public bool Format()
            {
                var query = _board.SetBoardData(this, 0, Commands[17], 1);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == Commands[17];
            }

            /// <summary>
            /// Debug commands status
            /// </summary>
            /// <returns></returns>
            public bool GetDebugMode()
            {
                var query = _board.GetBoardData(this, 0, Commands[18]);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == Commands[18];
            }

            /// <summary>
            /// Set debug commands status
            /// </summary>
            /// <returns></returns>
            public bool SetDebugMode(bool state)
            {
                var query = _board.SetBoardData(this, 0, Commands[19], state ? (uint)1 : 0);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == Commands[19];
            }

            /// <summary>
            /// Get chip dev id and rev id
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetDeviceId()
            {
                if (_board is Serial)
                    return Convert.ToString(_board.GetBoardData(this, 0, Commands[20]).Data);
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
        public abstract BoardCommand[] Commands { get; }
        public BoardCommand GetCommandFromId(ulong id) => Commands.FirstOrDefault(c => c.Id == id);
        public BoardCommand GetCommandFromName(string name) => Commands.FirstOrDefault(c => c.Name == name);
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

        public T Value { get; set; }

        public BoardClass.CmdTypes Types { get; set; }

        public BoardCommand(string name, ulong id, string description, BoardClass.CmdTypes types)
        {
            this.Name = name;
            this.Id = id;
            this.Description = description;
            this.Types = types;
        }

        public T GetValue() => Value;
        public void SetValue(T value) => Value = value;
    }

    public abstract class BoardCommand
    {
        public abstract string Name { get; }
        public abstract ulong Id { get; }
        public abstract string Description { get; }
    }
}
