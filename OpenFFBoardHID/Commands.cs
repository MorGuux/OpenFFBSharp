using System;

namespace OpenFFBoard
{
    public static class Commands
    {
        public class FFBAxis
        {
            private readonly Board _board;
            private const int ClassId = 0xA01;
            private const string Prefix = "axis";
            internal FFBAxis(Board board)
            {
                _board = board;
            }

            private enum ClassDefinitions : uint
            {
                Id = 0x80000001,
                Name = 0x80000002,
                Help = 0x80000003,
                CmdUid = 0x80000005,
                Instance = 0x80000004,
                Power = 0x0,
                Degrees = 0x1,
                EsGain = 0x2,
                ZeroEnc = 0x3,
                Invert = 0x4,
                IdleSpring = 0x5,
                AxisDamper = 0x6,
                EncType = 0x7,
                DrvType = 0x8,
                Pos = 0x9,
                MaxSpeed = 0xA,
                MaxTorqueRate = 0xB,
                FxRatio = 0xC,
                CurTorque = 0xD,
                CurPos = 0xE
            }

            /// <summary>
            /// ID of class
            /// </summary>
            /// <returns></returns>
            public long GetId()
            {
                return Convert.ToInt64(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.Id).Data);
            }

            /// <summary>
            /// Name of class
            /// </summary>
            /// <returns></returns>
            public string GetName()
            {
                if (_board is Serial)
                    return Convert.ToString(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.Name).Data);
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
                    return Convert.ToString(_board.GetBoardData(ClassId, 0, (uint) ClassDefinitions.Help).Data);
                else
                    throw new NotSupportedException("Cannot read help of a class using the HID system.");
            }

            /// <summary>
            /// Command handler index
            /// </summary>
            /// <returns></returns>
            public long GetCmdUid()
            {
                return Convert.ToInt64(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.CmdUid).Data);
            }

            /// <summary>
            /// Command handler instance number
            /// </summary>
            /// <returns></returns>
            public long GetInstance()
            {
                return Convert.ToInt64(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.Instance).Data);
            }

            /// <summary>
            /// Overall force strength
            /// </summary>
            /// <returns></returns>
            public ushort GetPower()
            {
                return Convert.ToUInt16(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.Power).Data);
            }

            /// <summary>
            /// Rotation range in deg
            /// </summary>
            /// <returns></returns>
            public ushort GetRotationDegrees()
            {
                return Convert.ToUInt16(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.Degrees).Data);
            }

            /// <summary>
            /// Endstop stiffness
            /// </summary>
            /// <returns></returns>
            public byte GetEndstopGain()
            {
                return Convert.ToByte(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.EsGain).Data);
            }

            /// <summary>
            /// Zero axis
            /// </summary>
            /// <returns>True if successful, false otherwise</returns>
            public bool ZeroEncoder()
            {
                var query = _board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.ZeroEnc);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == (uint)ClassDefinitions.ZeroEnc;
            }

            /// <summary>
            /// Invert axis
            /// </summary>
            /// <returns></returns>
            public bool InvertAxis()
            {
                var query = _board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.Invert);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == (uint)ClassDefinitions.Invert;
            }

            /// <summary>
            /// Idle spring strength
            /// </summary>
            /// <returns></returns>
            public long GetIdleSpring()
            {
                return Convert.ToInt64(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.IdleSpring).Data);
            }

            /// <summary>
            /// Independent damper effect
            /// </summary>
            /// <returns></returns>
            public long GetAxisDamper()
            {
                return Convert.ToInt64(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.AxisDamper).Data);
            }

            /// <summary>
            /// Encoder type
            /// </summary>
            /// <returns></returns>
            public long GetEncoderType()
            {
                return Convert.ToInt64(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.EncType).Data);
            }

            /// <summary>
            /// Motor driver type
            /// </summary>
            /// <returns></returns>
            public long GetDriverType()
            {
                return Convert.ToInt64(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.DrvType).Data);
            }

            /// <summary>
            /// Encoder position
            /// </summary>
            /// <returns></returns>
            public int GetEncoderPosition()
            {
                return Convert.ToInt32(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.Pos).Data);
            }

            /// <summary>
            /// Speed limit in deg/s
            /// </summary>
            /// <returns></returns>
            public long GetMaxSpeed()
            {
                return Convert.ToInt64(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.MaxSpeed).Data);
            }

            /// <summary>
            /// Torque rate limit in counts/ms
            /// </summary>
            /// <returns></returns>
            public long GetMaxTorqueRate()
            {
                return Convert.ToInt64(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.MaxTorqueRate).Data);
            }

            /// <summary>
            /// Effect ratio. Reduces effects excluding endstop, 255 = 100%
            /// </summary>
            /// <returns></returns>
            public long GetEffectsRatio()
            {
                return Convert.ToInt64(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.FxRatio).Data);
            }

            /// <summary>
            /// Axis torque
            /// </summary>
            /// <returns></returns>
            public int GetAxisTorque()
            {
                return Convert.ToInt32(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.CurTorque).Data);
            }

            /// <summary>
            /// Axis position
            /// </summary>
            /// <returns></returns>
            public short GetAxisPosition()
            {
                return Convert.ToInt16(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.CurPos).Data);
            }
        }
        public class System
        {
            private readonly Board _board;
            private const int ClassId = 0x0;
            private const string Prefix = "sys";
            internal System(Board board)
            {
                _board = board;
            }

            private enum ClassDefinitions : uint
            {
                Help = 0x0,
                Save = 0x1,
                Reboot = 0x2,
                DFU = 0x3,
                LsMain = 0x6,
                LsActive = 0x8,
                VInt = 0xE,
                VExt = 0xF,
                Main = 0x7,
                SwVer = 0x4,
                HwType = 0x5,
                FlashRaw = 0xD,
                FlashDump = 0xC,
                Errors = 0xA,
                ErrorsClr = 0xB,
                HeapFree = 0x11,
                Format = 0x9,
                Debug = 0x13,
                DevId = 0x14
            }

            /// <summary>
            /// Print system help
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetHelp()
            {
                if (_board is Serial)
                    return Convert.ToString(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.Save).Data);
                else
                    throw new NotSupportedException("Cannot read help of a class using the HID system.");
            }

            /// <summary>
            /// Write all settings to flash
            /// </summary>
            /// <returns>True if successful, false otherwise</returns>
            public bool Save()
            {
                var query = _board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.Save);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == (uint)ClassDefinitions.Save;
            }

            /// <summary>
            /// Reset chip
            /// </summary>
            public void Reboot()
            {
                _board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.Reboot);
            }

            /// <summary>
            /// Reboot into DFU boot-loader
            /// </summary>
            public void DFU()
            {
                _board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.DFU);
            }

            /// <summary>
            /// List available main classes
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetMainClasses()
            {
                if (_board is Serial)
                    return Convert.ToString(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.LsMain).Data);
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
                    return Convert.ToString(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.LsActive).Data);
                else
                    throw new NotSupportedException("Cannot read help of a class using the HID system.");
            }

            /// <summary>
            /// Internal voltage (mV)
            /// </summary>
            /// <returns></returns>
            public ulong GetInternalVoltage()
            {
                return Convert.ToUInt64(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.VInt).Data);
            }

            /// <summary>
            /// External voltage (mV)
            /// </summary>
            /// <returns></returns>
            public ulong GetExternalVoltage()
            {
                return Convert.ToUInt64(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.VExt).Data);
            }

            /// <summary>
            /// Active main class
            /// </summary>
            /// <returns></returns>
            public ulong GetActiveMainClass()
            {
                return Convert.ToUInt64(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.Main).Data);
            }

            /// <summary>
            /// Set active main class
            /// </summary>
            /// <returns></returns>
            public bool SetActiveMainClass(ulong mainClass)
            {
                var query = _board.SetBoardData(ClassId, 0, (uint)ClassDefinitions.Main, mainClass);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == (uint)ClassDefinitions.Main;
            }

            /// <summary>
            /// Firmware version
            /// </summary>
            /// <returns></returns>
            public string GetFirmwareVersion()
            {
                if (_board is Serial)
                    return Convert.ToString(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.SwVer).Data);
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
                    return Convert.ToString(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.HwType).Data);
                else
                    throw new NotSupportedException("Cannot read hardware type of the board using the HID system.");
            }

            /// <summary>
            /// Write value to flash address
            /// </summary>
            /// <returns></returns>
            public bool WriteToFlash(ulong address, ulong value)
            {
                var query = _board.SetBoardData(ClassId, 0, (uint)ClassDefinitions.FlashRaw, value, address);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == (uint)ClassDefinitions.FlashRaw;
            }

            /// <summary>
            /// Read all flash variables (val:adr)
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetFlashDump()
            {
                if (_board is Serial)
                    return Convert.ToString(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.FlashDump).Data);
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
                    return Convert.ToString(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.Errors).Data);
                else
                    throw new NotSupportedException("Cannot read errors on the board using the HID system.");
            }

            /// <summary>
            /// Clear errors
            /// </summary>
            /// <returns></returns>
            public bool ClearErrors()
            {
                var query = _board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.ErrorsClr);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == (uint)ClassDefinitions.ErrorsClr;
            }

            /// <summary>
            /// Memory info
            /// </summary>
            /// <returns></returns>
            public ulong GetMemoryHeapFree()
            {
                return Convert.ToUInt64(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.HeapFree).Data);
            }

            /// <summary>
            /// Erase all stored flash values
            /// </summary>
            /// <returns></returns>
            public bool Format()
            {
                var query = _board.SetBoardData(ClassId, 0, (uint)ClassDefinitions.Format, 1);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == (uint)ClassDefinitions.Format;
            }

            /// <summary>
            /// Debug commands status
            /// </summary>
            /// <returns></returns>
            public bool GetDebugMode()
            {
                var query = _board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.Debug);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == (uint)ClassDefinitions.Format;
            }

            /// <summary>
            /// Set debug commands status
            /// </summary>
            /// <returns></returns>
            public bool SetDebugMode(bool state)
            {
                var query = _board.SetBoardData(ClassId, 0, (uint)ClassDefinitions.Debug, state ? (uint)1 : 0);
                return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == (uint)ClassDefinitions.Debug;
            }

            /// <summary>
            /// Get chip dev id and rev id
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotSupportedException"></exception>
            public string GetDeviceId()
            {
                if (_board is Serial)
                    return Convert.ToString(_board.GetBoardData(ClassId, 0, (uint)ClassDefinitions.DevId).Data);
                else
                    throw new NotSupportedException("Cannot read device Id of the board using the HID system.");
            }

        }

        public class BoardResponse
        {
            public CmdType Type { get; set; }
            public ushort ClassId { get; set; }
            public byte Instance { get; set; }
            public uint Cmd { get; set; }
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
}
