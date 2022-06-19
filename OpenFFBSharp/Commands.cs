using OpenFFBoard;
using System;

namespace OpenFFBoard
{

	public static class Commands
	{

		public class AnalogAxes : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0x41;
			public override string Prefix => "apin";

			internal AnalogAxes(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region mask
			private readonly BoardCommand<byte> _mask = new BoardCommand<byte>("mask", 0x0, "Enabled pins", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Enabled pins
			/// </summary>
			/// <returns></returns>
			public byte GetMask()
			{
				return _mask.GetValue(_board, this);
			}

			/// <summary>
			/// Enabled pins
			/// </summary>
			/// <returns></returns>
			public bool SetMask(byte newMask)
			{
				var query = _mask.SetValue(_board, this, newMask);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _mask;
			}

			#endregion

			#region autocal
			private readonly BoardCommand<bool> _autocal = new BoardCommand<bool>("autocal", 0x1, "Autoranging", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Autoranging
			/// </summary>
			/// <returns></returns>
			public bool GetAutocal()
			{
				return _autocal.GetValue(_board, this);
			}

			/// <summary>
			/// Autoranging
			/// </summary>
			/// <returns></returns>
			public bool SetAutocal(bool newAutocal)
			{
				var query = _autocal.SetValue(_board, this, newAutocal);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _autocal;
			}

			#endregion

			#region pins
			private readonly BoardCommand<byte> _pins = new BoardCommand<byte>("pins", 0x2, "Available pins", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Available pins
			/// </summary>
			/// <returns></returns>
			public byte GetPins()
			{
				return _pins.GetValue(_board, this);
			}

			/// <summary>
			/// Available pins
			/// </summary>
			/// <returns></returns>
			public bool SetPins(byte newPins)
			{
				var query = _pins.SetValue(_board, this, newPins);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _pins;
			}

			#endregion

			#region values
			private readonly BoardCommand<string> _values = new BoardCommand<string>("values", 0x3, "Analog values", CmdTypes.Get);

			/// <summary>
			/// Analog values
			/// </summary>
			/// <returns></returns>
			public string GetValues()
			{
				return _values.GetValue(_board, this);
			}
			#endregion
		}
		public class AnalogShifter : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0x23;
			public override string Prefix => "shifter";

			internal AnalogShifter(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region mode
			private readonly BoardCommand<byte> _mode = new BoardCommand<byte>("mode", 0x0, "Shifter mode", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// Shifter mode
			/// </summary>
			/// <returns></returns>
			public byte GetMode()
			{
				return _mode.GetValue(_board, this);
			}

			/// <summary>
			/// Shifter mode
			/// </summary>
			/// <returns></returns>
			public bool SetMode(byte newMode)
			{
				var query = _mode.SetValue(_board, this, newMode);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _mode;
			}


			/// <summary>
			/// Shifter mode
			/// </summary>
			/// <returns></returns>
			public string GetModeInfo()
			{
				return _mode.GetInfo(_board, this);
			}
			#endregion

			#region x12
			private readonly BoardCommand<uint> _x12 = new BoardCommand<uint>("x12", 0x1, "X-threshold for 1&2 gears", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// X-threshold for 1&2 gears
			/// </summary>
			/// <returns></returns>
			public uint GetX12()
			{
				return _x12.GetValue(_board, this);
			}

			/// <summary>
			/// X-threshold for 1&2 gears
			/// </summary>
			/// <returns></returns>
			public bool SetX12(uint newX12)
			{
				var query = _x12.SetValue(_board, this, newX12);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _x12;
			}

			#endregion

			#region x56
			private readonly BoardCommand<uint> _x56 = new BoardCommand<uint>("x56", 0x2, "X-threshold for 5&6 gears", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// X-threshold for 5&6 gears
			/// </summary>
			/// <returns></returns>
			public uint GetX56()
			{
				return _x56.GetValue(_board, this);
			}

			/// <summary>
			/// X-threshold for 5&6 gears
			/// </summary>
			/// <returns></returns>
			public bool SetX56(uint newX56)
			{
				var query = _x56.SetValue(_board, this, newX56);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _x56;
			}

			#endregion

			#region y135
			private readonly BoardCommand<uint> _y135 = new BoardCommand<uint>("y135", 0x3, "Y-threshold for 1&3&5 gears", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Y-threshold for 1&3&5 gears
			/// </summary>
			/// <returns></returns>
			public uint GetY135()
			{
				return _y135.GetValue(_board, this);
			}

			/// <summary>
			/// Y-threshold for 1&3&5 gears
			/// </summary>
			/// <returns></returns>
			public bool SetY135(uint newY135)
			{
				var query = _y135.SetValue(_board, this, newY135);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _y135;
			}

			#endregion

			#region y246
			private readonly BoardCommand<uint> _y246 = new BoardCommand<uint>("y246", 0x4, "Y-threshold for 2&4&6 gears", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Y-threshold for 2&4&6 gears
			/// </summary>
			/// <returns></returns>
			public uint GetY246()
			{
				return _y246.GetValue(_board, this);
			}

			/// <summary>
			/// Y-threshold for 2&4&6 gears
			/// </summary>
			/// <returns></returns>
			public bool SetY246(uint newY246)
			{
				var query = _y246.SetValue(_board, this, newY246);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _y246;
			}

			#endregion

			#region revbtn
			private readonly BoardCommand<byte> _revbtn = new BoardCommand<byte>("revbtn", 0x5, "Pin for R signal", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Pin for R signal
			/// </summary>
			/// <returns></returns>
			public byte GetRevbtn()
			{
				return _revbtn.GetValue(_board, this);
			}

			/// <summary>
			/// Pin for R signal
			/// </summary>
			/// <returns></returns>
			public bool SetRevbtn(byte newRevbtn)
			{
				var query = _revbtn.SetValue(_board, this, newRevbtn);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _revbtn;
			}

			#endregion

			#region cspin
			private readonly BoardCommand<byte> _cspin = new BoardCommand<byte>("cspin", 0x6, "CS pin for SPI modes", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// CS pin for SPI modes
			/// </summary>
			/// <returns></returns>
			public byte GetCspin()
			{
				return _cspin.GetValue(_board, this);
			}

			/// <summary>
			/// CS pin for SPI modes
			/// </summary>
			/// <returns></returns>
			public bool SetCspin(byte newCspin)
			{
				var query = _cspin.SetValue(_board, this, newCspin);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _cspin;
			}

			#endregion

			#region xchan
			private readonly BoardCommand<byte> _xchan = new BoardCommand<byte>("xchan", 0x7, "X signal analog pin", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// X signal analog pin
			/// </summary>
			/// <returns></returns>
			public byte GetXchan()
			{
				return _xchan.GetValue(_board, this);
			}

			/// <summary>
			/// X signal analog pin
			/// </summary>
			/// <returns></returns>
			public bool SetXchan(byte newXchan)
			{
				var query = _xchan.SetValue(_board, this, newXchan);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _xchan;
			}

			#endregion

			#region ychan
			private readonly BoardCommand<byte> _ychan = new BoardCommand<byte>("ychan", 0x8, "Y signal analog pin", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Y signal analog pin
			/// </summary>
			/// <returns></returns>
			public byte GetYchan()
			{
				return _ychan.GetValue(_board, this);
			}

			/// <summary>
			/// Y signal analog pin
			/// </summary>
			/// <returns></returns>
			public bool SetYchan(byte newYchan)
			{
				var query = _ychan.SetValue(_board, this, newYchan);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _ychan;
			}

			#endregion

			#region vals
			private readonly BoardCommand<string> _vals = new BoardCommand<string>("vals", 0x9, "Analog values", CmdTypes.Get);

			/// <summary>
			/// Analog values
			/// </summary>
			/// <returns></returns>
			public string GetVals()
			{
				return _vals.GetValue(_board, this);
			}
			#endregion

			#region gear
			private readonly BoardCommand<string> _gear = new BoardCommand<string>("gear", 0xA, "Decoded gear", CmdTypes.Get);

			/// <summary>
			/// Decoded gear
			/// </summary>
			/// <returns></returns>
			public string GetGear()
			{
				return _gear.GetValue(_board, this);
			}
			#endregion
		}
		public class Axis : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0xA01;
			public override string Prefix => "axis";

			internal Axis(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region power
			private readonly BoardCommand<ushort> _power = new BoardCommand<ushort>("power", 0x0, "Overall force strength", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Overall force strength
			/// </summary>
			/// <returns></returns>
			public ushort GetPower()
			{
				return _power.GetValue(_board, this);
			}

			/// <summary>
			/// Overall force strength
			/// </summary>
			/// <returns></returns>
			public bool SetPower(ushort newPower)
			{
				var query = _power.SetValue(_board, this, newPower);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _power;
			}

			#endregion

			#region degrees
			private readonly BoardCommand<ushort> _degrees = new BoardCommand<ushort>("degrees", 0x1, "Rotation range in deg", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Rotation range in deg
			/// </summary>
			/// <returns></returns>
			public ushort GetDegrees()
			{
				return _degrees.GetValue(_board, this);
			}

			/// <summary>
			/// Rotation range in deg
			/// </summary>
			/// <returns></returns>
			public bool SetDegrees(ushort newDegrees)
			{
				var query = _degrees.SetValue(_board, this, newDegrees);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _degrees;
			}

			#endregion

			#region esgain
			private readonly BoardCommand<byte> _esgain = new BoardCommand<byte>("esgain", 0x2, "Endstop stiffness", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Endstop stiffness
			/// </summary>
			/// <returns></returns>
			public byte GetEsgain()
			{
				return _esgain.GetValue(_board, this);
			}

			/// <summary>
			/// Endstop stiffness
			/// </summary>
			/// <returns></returns>
			public bool SetEsgain(byte newEsgain)
			{
				var query = _esgain.SetValue(_board, this, newEsgain);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _esgain;
			}

			#endregion

			#region zeroenc
			private readonly BoardCommand<bool> _zeroenc = new BoardCommand<bool>("zeroenc", 0x3, "Zero axis", CmdTypes.Get);

			/// <summary>
			/// Zero axis
			/// </summary>
			/// <returns></returns>
			public bool GetZeroenc()
			{
				return _zeroenc.GetValue(_board, this);
			}
			#endregion

			#region invert
			private readonly BoardCommand<bool> _invert = new BoardCommand<bool>("invert", 0x4, "Invert axis", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Invert axis
			/// </summary>
			/// <returns></returns>
			public bool GetInvert()
			{
				return _invert.GetValue(_board, this);
			}

			/// <summary>
			/// Invert axis
			/// </summary>
			/// <returns></returns>
			public bool SetInvert(bool newInvert)
			{
				var query = _invert.SetValue(_board, this, newInvert);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _invert;
			}

			#endregion

			#region idlespring
			private readonly BoardCommand<byte> _idlespring = new BoardCommand<byte>("idlespring", 0x5, "Idle spring strength", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Idle spring strength
			/// </summary>
			/// <returns></returns>
			public byte GetIdlespring()
			{
				return _idlespring.GetValue(_board, this);
			}

			/// <summary>
			/// Idle spring strength
			/// </summary>
			/// <returns></returns>
			public bool SetIdlespring(byte newIdlespring)
			{
				var query = _idlespring.SetValue(_board, this, newIdlespring);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _idlespring;
			}

			#endregion

			#region axisdamper
			private readonly BoardCommand<byte> _axisdamper = new BoardCommand<byte>("axisdamper", 0x6, "Independent damper effect", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Independent damper effect
			/// </summary>
			/// <returns></returns>
			public byte GetAxisdamper()
			{
				return _axisdamper.GetValue(_board, this);
			}

			/// <summary>
			/// Independent damper effect
			/// </summary>
			/// <returns></returns>
			public bool SetAxisdamper(byte newAxisdamper)
			{
				var query = _axisdamper.SetValue(_board, this, newAxisdamper);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _axisdamper;
			}

			#endregion

			#region enctype
			private readonly BoardCommand<string> _enctype = new BoardCommand<string>("enctype", 0x7, "Encoder type get/set/list", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// Encoder type get/set/list
			/// </summary>
			/// <returns></returns>
			public string GetEnctype()
			{
				return _enctype.GetValue(_board, this);
			}

			/// <summary>
			/// Encoder type get/set/list
			/// </summary>
			/// <returns></returns>
			public bool SetEnctype(string newEnctype)
			{
				var query = _enctype.SetValue(_board, this, newEnctype);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _enctype;
			}


			/// <summary>
			/// Encoder type get/set/list
			/// </summary>
			/// <returns></returns>
			public string GetEnctypeInfo()
			{
				return _enctype.GetInfo(_board, this);
			}
			#endregion

			#region drvtype
			private readonly BoardCommand<string> _drvtype = new BoardCommand<string>("drvtype", 0x8, "Motor driver type get/set/list", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// Motor driver type get/set/list
			/// </summary>
			/// <returns></returns>
			public string GetDrvtype()
			{
				return _drvtype.GetValue(_board, this);
			}

			/// <summary>
			/// Motor driver type get/set/list
			/// </summary>
			/// <returns></returns>
			public bool SetDrvtype(string newDrvtype)
			{
				var query = _drvtype.SetValue(_board, this, newDrvtype);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _drvtype;
			}


			/// <summary>
			/// Motor driver type get/set/list
			/// </summary>
			/// <returns></returns>
			public string GetDrvtypeInfo()
			{
				return _drvtype.GetInfo(_board, this);
			}
			#endregion

			#region pos
			private readonly BoardCommand<long> _pos = new BoardCommand<long>("pos", 0x9, "Encoder position", CmdTypes.Get);

			/// <summary>
			/// Encoder position
			/// </summary>
			/// <returns></returns>
			public long GetPos()
			{
				return _pos.GetValue(_board, this);
			}
			#endregion

			#region maxspeed
			private readonly BoardCommand<long> _maxspeed = new BoardCommand<long>("maxspeed", 0xA, "Speed limit in deg/s", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Speed limit in deg/s
			/// </summary>
			/// <returns></returns>
			public long GetMaxspeed()
			{
				return _maxspeed.GetValue(_board, this);
			}

			/// <summary>
			/// Speed limit in deg/s
			/// </summary>
			/// <returns></returns>
			public bool SetMaxspeed(long newMaxspeed)
			{
				var query = _maxspeed.SetValue(_board, this, newMaxspeed);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _maxspeed;
			}

			#endregion

			#region maxtorquerate
			private readonly BoardCommand<long> _maxtorquerate = new BoardCommand<long>("maxtorquerate", 0xB, "Torque rate limit in counts/ms", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Torque rate limit in counts/ms
			/// </summary>
			/// <returns></returns>
			public long GetMaxtorquerate()
			{
				return _maxtorquerate.GetValue(_board, this);
			}

			/// <summary>
			/// Torque rate limit in counts/ms
			/// </summary>
			/// <returns></returns>
			public bool SetMaxtorquerate(long newMaxtorquerate)
			{
				var query = _maxtorquerate.SetValue(_board, this, newMaxtorquerate);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _maxtorquerate;
			}

			#endregion

			#region fxratio
			private readonly BoardCommand<byte> _fxratio = new BoardCommand<byte>("fxratio", 0xC, "Effect ratio. Reduces effects excluding endstop. 255=100%", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Effect ratio. Reduces effects excluding endstop. 255=100%
			/// </summary>
			/// <returns></returns>
			public byte GetFxratio()
			{
				return _fxratio.GetValue(_board, this);
			}

			/// <summary>
			/// Effect ratio. Reduces effects excluding endstop. 255=100%
			/// </summary>
			/// <returns></returns>
			public bool SetFxratio(byte newFxratio)
			{
				var query = _fxratio.SetValue(_board, this, newFxratio);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _fxratio;
			}

			#endregion

			#region curtorque
			private readonly BoardCommand<long> _curtorque = new BoardCommand<long>("curtorque", 0xD, "Axis torque", CmdTypes.Get);

			/// <summary>
			/// Axis torque
			/// </summary>
			/// <returns></returns>
			public long GetCurtorque()
			{
				return _curtorque.GetValue(_board, this);
			}
			#endregion

			#region curpos
			private readonly BoardCommand<long> _curpos = new BoardCommand<long>("curpos", 0xE, "Axis position", CmdTypes.Get);

			/// <summary>
			/// Axis position
			/// </summary>
			/// <returns></returns>
			public long GetCurpos()
			{
				return _curpos.GetValue(_board, this);
			}
			#endregion
		}
		public class CANAnalogAxes : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0x42;
			public override string Prefix => "cananalog";

			internal CANAnalogAxes(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region canid
			private readonly BoardCommand<uint> _canid = new BoardCommand<uint>("canid", 0x0, "CAN frame ID of first packet. Next packet ID+1", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// CAN frame ID of first packet. Next packet ID+1
			/// </summary>
			/// <returns></returns>
			public uint GetCanid()
			{
				return _canid.GetValue(_board, this);
			}

			/// <summary>
			/// CAN frame ID of first packet. Next packet ID+1
			/// </summary>
			/// <returns></returns>
			public bool SetCanid(uint newCanid)
			{
				var query = _canid.SetValue(_board, this, newCanid);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _canid;
			}

			#endregion

			#region amount
			private readonly BoardCommand<byte> _amount = new BoardCommand<byte>("amount", 0x1, "Amount of analog axes", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Amount of analog axes
			/// </summary>
			/// <returns></returns>
			public byte GetAmount()
			{
				return _amount.GetValue(_board, this);
			}

			/// <summary>
			/// Amount of analog axes
			/// </summary>
			/// <returns></returns>
			public bool SetAmount(byte newAmount)
			{
				var query = _amount.SetValue(_board, this, newAmount);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _amount;
			}

			#endregion

			#region maxamount
			private readonly BoardCommand<byte> _maxamount = new BoardCommand<byte>("maxamount", 0x2, "Maxmimum amount of analog axes", CmdTypes.Get);

			/// <summary>
			/// Maxmimum amount of analog axes
			/// </summary>
			/// <returns></returns>
			public byte GetMaxamount()
			{
				return _maxamount.GetValue(_board, this);
			}
			#endregion
		}
		public class CANButtons : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0x25;
			public override string Prefix => "canbtn";

			internal CANButtons(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region btnnum
			private readonly BoardCommand<byte> _btnnum = new BoardCommand<byte>("btnnum", 0x0, "Amount of buttons", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Amount of buttons
			/// </summary>
			/// <returns></returns>
			public byte GetBtnnum()
			{
				return _btnnum.GetValue(_board, this);
			}

			/// <summary>
			/// Amount of buttons
			/// </summary>
			/// <returns></returns>
			public bool SetBtnnum(byte newBtnnum)
			{
				var query = _btnnum.SetValue(_board, this, newBtnnum);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _btnnum;
			}

			#endregion

			#region invert
			private readonly BoardCommand<bool> _invert = new BoardCommand<bool>("invert", 0x1, "Invert buttons", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Invert buttons
			/// </summary>
			/// <returns></returns>
			public bool GetInvert()
			{
				return _invert.GetValue(_board, this);
			}

			/// <summary>
			/// Invert buttons
			/// </summary>
			/// <returns></returns>
			public bool SetInvert(bool newInvert)
			{
				var query = _invert.SetValue(_board, this, newInvert);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _invert;
			}

			#endregion

			#region canid
			private readonly BoardCommand<uint> _canid = new BoardCommand<uint>("canid", 0x2, "CAN frame ID", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// CAN frame ID
			/// </summary>
			/// <returns></returns>
			public uint GetCanid()
			{
				return _canid.GetValue(_board, this);
			}

			/// <summary>
			/// CAN frame ID
			/// </summary>
			/// <returns></returns>
			public bool SetCanid(uint newCanid)
			{
				var query = _canid.SetValue(_board, this, newCanid);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _canid;
			}

			#endregion
		}
		public class CANPort : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0xC01;
			public override string Prefix => "can";

			internal CANPort(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region speed
			private readonly BoardCommand<byte> _speed = new BoardCommand<byte>("speed", 0x0, "CAN speed preset (0:50k;1:100k;2:125k;3:250k;4:500k;5:1M)", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// CAN speed preset (0:50k;1:100k;2:125k;3:250k;4:500k;5:1M)
			/// </summary>
			/// <returns></returns>
			public byte GetSpeed()
			{
				return _speed.GetValue(_board, this);
			}

			/// <summary>
			/// CAN speed preset (0:50k;1:100k;2:125k;3:250k;4:500k;5:1M)
			/// </summary>
			/// <returns></returns>
			public bool SetSpeed(byte newSpeed)
			{
				var query = _speed.SetValue(_board, this, newSpeed);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _speed;
			}


			/// <summary>
			/// CAN speed preset (0:50k;1:100k;2:125k;3:250k;4:500k;5:1M)
			/// </summary>
			/// <returns></returns>
			public string GetSpeedInfo()
			{
				return _speed.GetInfo(_board, this);
			}
			#endregion

			#region send
			private readonly BoardCommand<string> _send = new BoardCommand<string>("send", 0x1, "Send CAN frame. Adr&Value required", CmdTypes.SetAddress);

			/// <summary>
			/// Send CAN frame. Adr&Value required
			/// </summary>
			/// <returns></returns>
			public bool SetSend(string newSend, ulong address)
			{
				var query = _send.SetValue(_board, this, newSend, address);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _send;
			}
			#endregion

			#region len
			private readonly BoardCommand<byte> _len = new BoardCommand<byte>("len", 0x2, "Set length of next frames", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Set length of next frames
			/// </summary>
			/// <returns></returns>
			public byte GetLen()
			{
				return _len.GetValue(_board, this);
			}

			/// <summary>
			/// Set length of next frames
			/// </summary>
			/// <returns></returns>
			public bool SetLen(byte newLen)
			{
				var query = _len.SetValue(_board, this, newLen);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _len;
			}

			#endregion
		}
		public class DigitalButtons : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0x21;
			public override string Prefix => "dpin";

			internal DigitalButtons(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region mask
			private readonly BoardCommand<byte> _mask = new BoardCommand<byte>("mask", 0x0, "Enabled pins", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Enabled pins
			/// </summary>
			/// <returns></returns>
			public byte GetMask()
			{
				return _mask.GetValue(_board, this);
			}

			/// <summary>
			/// Enabled pins
			/// </summary>
			/// <returns></returns>
			public bool SetMask(byte newMask)
			{
				var query = _mask.SetValue(_board, this, newMask);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _mask;
			}

			#endregion

			#region polarity
			private readonly BoardCommand<bool> _polarity = new BoardCommand<bool>("polarity", 0x1, "Pin polarity", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Pin polarity
			/// </summary>
			/// <returns></returns>
			public bool GetPolarity()
			{
				return _polarity.GetValue(_board, this);
			}

			/// <summary>
			/// Pin polarity
			/// </summary>
			/// <returns></returns>
			public bool SetPolarity(bool newPolarity)
			{
				var query = _polarity.SetValue(_board, this, newPolarity);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _polarity;
			}

			#endregion

			#region pins
			private readonly BoardCommand<byte> _pins = new BoardCommand<byte>("pins", 0x2, "Available pins", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Available pins
			/// </summary>
			/// <returns></returns>
			public byte GetPins()
			{
				return _pins.GetValue(_board, this);
			}

			/// <summary>
			/// Available pins
			/// </summary>
			/// <returns></returns>
			public bool SetPins(byte newPins)
			{
				var query = _pins.SetValue(_board, this, newPins);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _pins;
			}

			#endregion

			#region values
			private readonly BoardCommand<byte> _values = new BoardCommand<byte>("values", 0x3, "pin values", CmdTypes.Get);

			/// <summary>
			/// pin values
			/// </summary>
			/// <returns></returns>
			public byte GetValues()
			{
				return _values.GetValue(_board, this);
			}
			#endregion
		}
		public class FX : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0xA02;
			public override string Prefix => "fx";

			internal FX(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region filterCfFreq
			private readonly BoardCommand<ushort> _filterCfFreq = new BoardCommand<ushort>("filterCfFreq", 0x0, "Constant force filter frequency", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Constant force filter frequency
			/// </summary>
			/// <returns></returns>
			public ushort GetFiltercffreq()
			{
				return _filterCfFreq.GetValue(_board, this);
			}

			/// <summary>
			/// Constant force filter frequency
			/// </summary>
			/// <returns></returns>
			public bool SetFiltercffreq(ushort newFiltercffreq)
			{
				var query = _filterCfFreq.SetValue(_board, this, newFiltercffreq);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _filterCfFreq;
			}

			#endregion

			#region filterCfQ
			private readonly BoardCommand<byte> _filterCfQ = new BoardCommand<byte>("filterCfQ", 0x1, "Constant force filter Q-factor", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Constant force filter Q-factor
			/// </summary>
			/// <returns></returns>
			public byte GetFiltercfq()
			{
				return _filterCfQ.GetValue(_board, this);
			}

			/// <summary>
			/// Constant force filter Q-factor
			/// </summary>
			/// <returns></returns>
			public bool SetFiltercfq(byte newFiltercfq)
			{
				var query = _filterCfQ.SetValue(_board, this, newFiltercfq);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _filterCfQ;
			}

			#endregion

			#region spring
			private readonly BoardCommand<byte> _spring = new BoardCommand<byte>("spring", 0x3, "Spring gain", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// Spring gain
			/// </summary>
			/// <returns></returns>
			public byte GetSpring()
			{
				return _spring.GetValue(_board, this);
			}

			/// <summary>
			/// Spring gain
			/// </summary>
			/// <returns></returns>
			public bool SetSpring(byte newSpring)
			{
				var query = _spring.SetValue(_board, this, newSpring);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _spring;
			}


			/// <summary>
			/// Spring gain
			/// </summary>
			/// <returns></returns>
			public string GetSpringInfo()
			{
				return _spring.GetInfo(_board, this);
			}
			#endregion

			#region friction
			private readonly BoardCommand<byte> _friction = new BoardCommand<byte>("friction", 0x4, "Friction gain", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// Friction gain
			/// </summary>
			/// <returns></returns>
			public byte GetFriction()
			{
				return _friction.GetValue(_board, this);
			}

			/// <summary>
			/// Friction gain
			/// </summary>
			/// <returns></returns>
			public bool SetFriction(byte newFriction)
			{
				var query = _friction.SetValue(_board, this, newFriction);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _friction;
			}


			/// <summary>
			/// Friction gain
			/// </summary>
			/// <returns></returns>
			public string GetFrictionInfo()
			{
				return _friction.GetInfo(_board, this);
			}
			#endregion

			#region damper
			private readonly BoardCommand<byte> _damper = new BoardCommand<byte>("damper", 0x5, "Damper gain", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// Damper gain
			/// </summary>
			/// <returns></returns>
			public byte GetDamper()
			{
				return _damper.GetValue(_board, this);
			}

			/// <summary>
			/// Damper gain
			/// </summary>
			/// <returns></returns>
			public bool SetDamper(byte newDamper)
			{
				var query = _damper.SetValue(_board, this, newDamper);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _damper;
			}


			/// <summary>
			/// Damper gain
			/// </summary>
			/// <returns></returns>
			public string GetDamperInfo()
			{
				return _damper.GetInfo(_board, this);
			}
			#endregion

			#region inertia
			private readonly BoardCommand<byte> _inertia = new BoardCommand<byte>("inertia", 0x6, "Inertia gain", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// Inertia gain
			/// </summary>
			/// <returns></returns>
			public byte GetInertia()
			{
				return _inertia.GetValue(_board, this);
			}

			/// <summary>
			/// Inertia gain
			/// </summary>
			/// <returns></returns>
			public bool SetInertia(byte newInertia)
			{
				var query = _inertia.SetValue(_board, this, newInertia);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _inertia;
			}


			/// <summary>
			/// Inertia gain
			/// </summary>
			/// <returns></returns>
			public string GetInertiaInfo()
			{
				return _inertia.GetInfo(_board, this);
			}
			#endregion

			#region effects
			private readonly BoardCommand<string> _effects = new BoardCommand<string>("effects", 0x2, "List effects. set 0 to reset", CmdTypes.Get | CmdTypes.Set | CmdTypes.String);

			/// <summary>
			/// List effects. set 0 to reset
			/// </summary>
			/// <returns></returns>
			public string GetEffects()
			{
				return _effects.GetValue(_board, this);
			}

			/// <summary>
			/// List effects. set 0 to reset
			/// </summary>
			/// <returns></returns>
			public bool SetEffects(string newEffects)
			{
				var query = _effects.SetValue(_board, this, newEffects);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _effects;
			}

			#endregion
		}
		public class I2CPort : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0xC02;
			public override string Prefix => "i2c";

			internal I2CPort(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region speed
			private readonly BoardCommand<byte> _speed = new BoardCommand<byte>("speed", 0x0, "I2C speed preset (0:100k;1:400k)", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// I2C speed preset (0:100k;1:400k)
			/// </summary>
			/// <returns></returns>
			public byte GetSpeed()
			{
				return _speed.GetValue(_board, this);
			}

			/// <summary>
			/// I2C speed preset (0:100k;1:400k)
			/// </summary>
			/// <returns></returns>
			public bool SetSpeed(byte newSpeed)
			{
				var query = _speed.SetValue(_board, this, newSpeed);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _speed;
			}


			/// <summary>
			/// I2C speed preset (0:100k;1:400k)
			/// </summary>
			/// <returns></returns>
			public string GetSpeedInfo()
			{
				return _speed.GetInfo(_board, this);
			}
			#endregion
		}
		public class Main : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0x1;
			public override string Prefix => "main.0";

			internal Main(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region ffbactive
			private readonly BoardCommand<bool> _ffbactive = new BoardCommand<bool>("ffbactive", 0x0, "FFB status", CmdTypes.Get);

			/// <summary>
			/// FFB status
			/// </summary>
			/// <returns></returns>
			public bool GetFfbactive()
			{
				return _ffbactive.GetValue(_board, this);
			}
			#endregion

			#region btntypes
			private readonly BoardCommand<byte> _btntypes = new BoardCommand<byte>("btntypes", 0x2, "Enabled button sources", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Enabled button sources
			/// </summary>
			/// <returns></returns>
			public byte GetBtntypes()
			{
				return _btntypes.GetValue(_board, this);
			}

			/// <summary>
			/// Enabled button sources
			/// </summary>
			/// <returns></returns>
			public bool SetBtntypes(byte newBtntypes)
			{
				var query = _btntypes.SetValue(_board, this, newBtntypes);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _btntypes;
			}

			#endregion

			#region addbtn
			private readonly BoardCommand<byte> _addbtn = new BoardCommand<byte>("addbtn", 0x4, "Enable button source", CmdTypes.Set);

			/// <summary>
			/// Enable button source
			/// </summary>
			/// <returns></returns>
			public bool SetAddbtn(byte newAddbtn)
			{
				var query = _addbtn.SetValue(_board, this, newAddbtn);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _addbtn;
			}

			#endregion

			#region lsbtn
			private readonly BoardCommand<string> _lsbtn = new BoardCommand<string>("lsbtn", 0x3, "Get available button sources", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// Get available button sources
			/// </summary>
			/// <returns></returns>
			public string GetLsbtn()
			{
				return _lsbtn.GetValue(_board, this);
			}
			#endregion

			#region aintypes
			private readonly BoardCommand<byte> _aintypes = new BoardCommand<byte>("aintypes", 0x5, "Enabled analog sources", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Enabled analog sources
			/// </summary>
			/// <returns></returns>
			public byte GetAintypes()
			{
				return _aintypes.GetValue(_board, this);
			}

			/// <summary>
			/// Enabled analog sources
			/// </summary>
			/// <returns></returns>
			public bool SetAintypes(byte newAintypes)
			{
				var query = _aintypes.SetValue(_board, this, newAintypes);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _aintypes;
			}

			#endregion

			#region lsain
			private readonly BoardCommand<string> _lsain = new BoardCommand<string>("lsain", 0x6, "Get available analog sources", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// Get available analog sources
			/// </summary>
			/// <returns></returns>
			public string GetLsain()
			{
				return _lsain.GetValue(_board, this);
			}
			#endregion

			#region addain
			private readonly BoardCommand<byte> _addain = new BoardCommand<byte>("addain", 0x7, "Enable analog source", CmdTypes.Set);

			/// <summary>
			/// Enable analog source
			/// </summary>
			/// <returns></returns>
			public bool SetAddain(byte newAddain)
			{
				var query = _addain.SetValue(_board, this, newAddain);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _addain;
			}

			#endregion

			#region hidrate
			private readonly BoardCommand<ushort> _hidrate = new BoardCommand<ushort>("hidrate", 0x8, "Get estimated effect update speed", CmdTypes.Get);

			/// <summary>
			/// Get estimated effect update speed
			/// </summary>
			/// <returns></returns>
			public ushort GetHidrate()
			{
				return _hidrate.GetValue(_board, this);
			}
			#endregion

			#region hidsendspd
			private readonly BoardCommand<ushort> _hidsendspd = new BoardCommand<ushort>("hidsendspd", 0x9, "Change HID gamepad update rate", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// Change HID gamepad update rate
			/// </summary>
			/// <returns></returns>
			public ushort GetHidsendspd()
			{
				return _hidsendspd.GetValue(_board, this);
			}

			/// <summary>
			/// Change HID gamepad update rate
			/// </summary>
			/// <returns></returns>
			public bool SetHidsendspd(ushort newHidsendspd)
			{
				var query = _hidsendspd.SetValue(_board, this, newHidsendspd);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _hidsendspd;
			}


			/// <summary>
			/// Change HID gamepad update rate
			/// </summary>
			/// <returns></returns>
			public string GetHidsendspdInfo()
			{
				return _hidsendspd.GetInfo(_board, this);
			}
			#endregion
		}
		public class MTSPI : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0x62;
			public override string Prefix => "mtenc";

			internal MTSPI(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region cs
			private readonly BoardCommand<byte> _cs = new BoardCommand<byte>("cs", 0x0, "CS pin", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// CS pin
			/// </summary>
			/// <returns></returns>
			public byte GetCs()
			{
				return _cs.GetValue(_board, this);
			}

			/// <summary>
			/// CS pin
			/// </summary>
			/// <returns></returns>
			public bool SetCs(byte newCs)
			{
				var query = _cs.SetValue(_board, this, newCs);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _cs;
			}

			#endregion

			#region pos
			private readonly BoardCommand<long> _pos = new BoardCommand<long>("pos", 0x1, "Position", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Position
			/// </summary>
			/// <returns></returns>
			public long GetPos()
			{
				return _pos.GetValue(_board, this);
			}

			/// <summary>
			/// Position
			/// </summary>
			/// <returns></returns>
			public bool SetPos(long newPos)
			{
				var query = _pos.SetValue(_board, this, newPos);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _pos;
			}

			#endregion

			#region errors
			private readonly BoardCommand<uint> _errors = new BoardCommand<uint>("errors", 0x2, "Parity error count", CmdTypes.Get);

			/// <summary>
			/// Parity error count
			/// </summary>
			/// <returns></returns>
			public uint GetErrors()
			{
				return _errors.GetValue(_board, this);
			}
			#endregion
		}
		public class ODriveDriver : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0x85;
			public override string Prefix => "odrv";

			internal ODriveDriver(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region canid
			private readonly BoardCommand<uint> _canid = new BoardCommand<uint>("canid", 0x0, "CAN id of ODrive", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// CAN id of ODrive
			/// </summary>
			/// <returns></returns>
			public uint GetCanid()
			{
				return _canid.GetValue(_board, this);
			}

			/// <summary>
			/// CAN id of ODrive
			/// </summary>
			/// <returns></returns>
			public bool SetCanid(uint newCanid)
			{
				var query = _canid.SetValue(_board, this, newCanid);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _canid;
			}

			#endregion

			#region canspd
			private readonly BoardCommand<byte> _canspd = new BoardCommand<byte>("canspd", 0x1, "CAN baudrate", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// CAN baudrate
			/// </summary>
			/// <returns></returns>
			public byte GetCanspd()
			{
				return _canspd.GetValue(_board, this);
			}

			/// <summary>
			/// CAN baudrate
			/// </summary>
			/// <returns></returns>
			public bool SetCanspd(byte newCanspd)
			{
				var query = _canspd.SetValue(_board, this, newCanspd);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _canspd;
			}

			#endregion

			#region errors
			private readonly BoardCommand<string> _errors = new BoardCommand<string>("errors", 0x2, "ODrive error flags", CmdTypes.Get);

			/// <summary>
			/// ODrive error flags
			/// </summary>
			/// <returns></returns>
			public string GetErrors()
			{
				return _errors.GetValue(_board, this);
			}
			#endregion

			#region state
			private readonly BoardCommand<string> _state = new BoardCommand<string>("state", 0x3, "ODrive state", CmdTypes.Get);

			/// <summary>
			/// ODrive state
			/// </summary>
			/// <returns></returns>
			public string GetState()
			{
				return _state.GetValue(_board, this);
			}
			#endregion

			#region maxtorque
			private readonly BoardCommand<uint> _maxtorque = new BoardCommand<uint>("maxtorque", 0x4, "Max torque to send for scaling", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Max torque to send for scaling
			/// </summary>
			/// <returns></returns>
			public uint GetMaxtorque()
			{
				return _maxtorque.GetValue(_board, this);
			}

			/// <summary>
			/// Max torque to send for scaling
			/// </summary>
			/// <returns></returns>
			public bool SetMaxtorque(uint newMaxtorque)
			{
				var query = _maxtorque.SetValue(_board, this, newMaxtorque);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _maxtorque;
			}

			#endregion

			#region vbus
			private readonly BoardCommand<uint> _vbus = new BoardCommand<uint>("vbus", 0x5, "ODrive Vbus", CmdTypes.Get);

			/// <summary>
			/// ODrive Vbus
			/// </summary>
			/// <returns></returns>
			public uint GetVbus()
			{
				return _vbus.GetValue(_board, this);
			}
			#endregion

			#region anticogging
			private readonly BoardCommand<bool> _anticogging = new BoardCommand<bool>("anticogging", 0x6, "Set 1 to start anticogging calibration", CmdTypes.Set);

			/// <summary>
			/// Set 1 to start anticogging calibration
			/// </summary>
			/// <returns></returns>
			public bool SetAnticogging(bool newAnticogging)
			{
				var query = _anticogging.SetValue(_board, this, newAnticogging);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _anticogging;
			}

			#endregion

			#region connected
			private readonly BoardCommand<bool> _connected = new BoardCommand<bool>("connected", 0x7, "ODrive connection state", CmdTypes.Get);

			/// <summary>
			/// ODrive connection state
			/// </summary>
			/// <returns></returns>
			public bool GetConnected()
			{
				return _connected.GetValue(_board, this);
			}
			#endregion
		}
		public class PCF8574 : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0x24;
			public override string Prefix => "pcfbtn";

			internal PCF8574(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region btnnum
			private readonly BoardCommand<byte> _btnnum = new BoardCommand<byte>("btnnum", 0x0, "Amount of buttons", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Amount of buttons
			/// </summary>
			/// <returns></returns>
			public byte GetBtnnum()
			{
				return _btnnum.GetValue(_board, this);
			}

			/// <summary>
			/// Amount of buttons
			/// </summary>
			/// <returns></returns>
			public bool SetBtnnum(byte newBtnnum)
			{
				var query = _btnnum.SetValue(_board, this, newBtnnum);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _btnnum;
			}

			#endregion

			#region invert
			private readonly BoardCommand<bool> _invert = new BoardCommand<bool>("invert", 0x1, "Invert buttons", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Invert buttons
			/// </summary>
			/// <returns></returns>
			public bool GetInvert()
			{
				return _invert.GetValue(_board, this);
			}

			/// <summary>
			/// Invert buttons
			/// </summary>
			/// <returns></returns>
			public bool SetInvert(bool newInvert)
			{
				var query = _invert.SetValue(_board, this, newInvert);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _invert;
			}

			#endregion

			#region speed
			private readonly BoardCommand<bool> _speed = new BoardCommand<bool>("speed", 0x2, "400kb/s mode", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// 400kb/s mode
			/// </summary>
			/// <returns></returns>
			public bool GetSpeed()
			{
				return _speed.GetValue(_board, this);
			}

			/// <summary>
			/// 400kb/s mode
			/// </summary>
			/// <returns></returns>
			public bool SetSpeed(bool newSpeed)
			{
				var query = _speed.SetValue(_board, this, newSpeed);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _speed;
			}

			#endregion
		}
		public class PWMDriver : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0x84;
			public override string Prefix => "pwmdrv";

			internal PWMDriver(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region freq
			private readonly BoardCommand<byte> _freq = new BoardCommand<byte>("freq", 0x1, "PWM period selection", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// PWM period selection
			/// </summary>
			/// <returns></returns>
			public byte GetFreq()
			{
				return _freq.GetValue(_board, this);
			}

			/// <summary>
			/// PWM period selection
			/// </summary>
			/// <returns></returns>
			public bool SetFreq(byte newFreq)
			{
				var query = _freq.SetValue(_board, this, newFreq);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _freq;
			}


			/// <summary>
			/// PWM period selection
			/// </summary>
			/// <returns></returns>
			public string GetFreqInfo()
			{
				return _freq.GetInfo(_board, this);
			}
			#endregion

			#region mode
			private readonly BoardCommand<byte> _mode = new BoardCommand<byte>("mode", 0x0, "PWM mode", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// PWM mode
			/// </summary>
			/// <returns></returns>
			public byte GetMode()
			{
				return _mode.GetValue(_board, this);
			}

			/// <summary>
			/// PWM mode
			/// </summary>
			/// <returns></returns>
			public bool SetMode(byte newMode)
			{
				var query = _mode.SetValue(_board, this, newMode);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _mode;
			}


			/// <summary>
			/// PWM mode
			/// </summary>
			/// <returns></returns>
			public string GetModeInfo()
			{
				return _mode.GetInfo(_board, this);
			}
			#endregion
		}
		public class SPIButtons : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0x22;
			public override string Prefix => "spibtn";

			internal SPIButtons(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region mode
			private readonly BoardCommand<byte> _mode = new BoardCommand<byte>("mode", 0x0, "SPI mode", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// SPI mode
			/// </summary>
			/// <returns></returns>
			public byte GetMode()
			{
				return _mode.GetValue(_board, this);
			}

			/// <summary>
			/// SPI mode
			/// </summary>
			/// <returns></returns>
			public bool SetMode(byte newMode)
			{
				var query = _mode.SetValue(_board, this, newMode);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _mode;
			}


			/// <summary>
			/// SPI mode
			/// </summary>
			/// <returns></returns>
			public string GetModeInfo()
			{
				return _mode.GetInfo(_board, this);
			}
			#endregion

			#region btncut
			private readonly BoardCommand<byte> _btncut = new BoardCommand<byte>("btncut", 0x1, "Cut buttons right", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Cut buttons right
			/// </summary>
			/// <returns></returns>
			public byte GetBtncut()
			{
				return _btncut.GetValue(_board, this);
			}

			/// <summary>
			/// Cut buttons right
			/// </summary>
			/// <returns></returns>
			public bool SetBtncut(byte newBtncut)
			{
				var query = _btncut.SetValue(_board, this, newBtncut);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _btncut;
			}

			#endregion

			#region btnpol
			private readonly BoardCommand<bool> _btnpol = new BoardCommand<bool>("btnpol", 0x2, "Invert", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Invert
			/// </summary>
			/// <returns></returns>
			public bool GetBtnpol()
			{
				return _btnpol.GetValue(_board, this);
			}

			/// <summary>
			/// Invert
			/// </summary>
			/// <returns></returns>
			public bool SetBtnpol(bool newBtnpol)
			{
				var query = _btnpol.SetValue(_board, this, newBtnpol);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _btnpol;
			}

			#endregion

			#region btnnum
			private readonly BoardCommand<byte> _btnnum = new BoardCommand<byte>("btnnum", 0x3, "Number of buttons", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Number of buttons
			/// </summary>
			/// <returns></returns>
			public byte GetBtnnum()
			{
				return _btnnum.GetValue(_board, this);
			}

			/// <summary>
			/// Number of buttons
			/// </summary>
			/// <returns></returns>
			public bool SetBtnnum(byte newBtnnum)
			{
				var query = _btnnum.SetValue(_board, this, newBtnnum);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _btnnum;
			}

			#endregion

			#region cs
			private readonly BoardCommand<byte> _cs = new BoardCommand<byte>("cs", 0x4, "SPI CS pin", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// SPI CS pin
			/// </summary>
			/// <returns></returns>
			public byte GetCs()
			{
				return _cs.GetValue(_board, this);
			}

			/// <summary>
			/// SPI CS pin
			/// </summary>
			/// <returns></returns>
			public bool SetCs(byte newCs)
			{
				var query = _cs.SetValue(_board, this, newCs);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _cs;
			}

			#endregion
		}
		public class System : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0x0;
			public override string Prefix => "sys";

			internal System(Board board)
			{
				_board = board;
			}


			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x0, "Print system help", CmdTypes.String);
			#endregion

			#region save
			private readonly BoardCommand<bool> _save = new BoardCommand<bool>("save", 0x1, "Write all settings to flash", CmdTypes.Get);

			/// <summary>
			/// Write all settings to flash
			/// </summary>
			/// <returns></returns>
			public bool GetSave()
			{
				return _save.GetValue(_board, this);
			}
			#endregion

			#region reboot
			private readonly BoardCommand<bool> _reboot = new BoardCommand<bool>("reboot", 0x2, "Reset chip", CmdTypes.Get);

			/// <summary>
			/// Reset chip
			/// </summary>
			/// <returns></returns>
			public bool GetReboot()
			{
				return _reboot.GetValue(_board, this);
			}
			#endregion

			#region dfu
			private readonly BoardCommand<bool> _dfu = new BoardCommand<bool>("dfu", 0x3, "reboot into DFU bootloader", CmdTypes.Get);

			/// <summary>
			/// reboot into DFU bootloader
			/// </summary>
			/// <returns></returns>
			public bool GetDfu()
			{
				return _dfu.GetValue(_board, this);
			}
			#endregion

			#region lsmain
			private readonly BoardCommand<string> _lsmain = new BoardCommand<string>("lsmain", 0x6, "List available mainclasses", CmdTypes.Get);

			/// <summary>
			/// List available mainclasses
			/// </summary>
			/// <returns></returns>
			public string GetLsmain()
			{
				return _lsmain.GetValue(_board, this);
			}
			#endregion

			#region lsactive
			private readonly BoardCommand<string> _lsactive = new BoardCommand<string>("lsactive", 0x8, "List active classes (Fullname:clsname:inst:clsid:idx)", CmdTypes.Get);

			/// <summary>
			/// List active classes (Fullname:clsname:inst:clsid:idx)
			/// </summary>
			/// <returns></returns>
			public string GetLsactive()
			{
				return _lsactive.GetValue(_board, this);
			}
			#endregion

			#region vint
			private readonly BoardCommand<uint> _vint = new BoardCommand<uint>("vint", 0xE, "Internal voltage(mV)", CmdTypes.Get);

			/// <summary>
			/// Internal voltage(mV)
			/// </summary>
			/// <returns></returns>
			public uint GetVint()
			{
				return _vint.GetValue(_board, this);
			}
			#endregion

			#region vext
			private readonly BoardCommand<uint> _vext = new BoardCommand<uint>("vext", 0xF, "External voltage(mV)", CmdTypes.Get);

			/// <summary>
			/// External voltage(mV)
			/// </summary>
			/// <returns></returns>
			public uint GetVext()
			{
				return _vext.GetValue(_board, this);
			}
			#endregion

			#region main
			private readonly BoardCommand<byte> _main = new BoardCommand<byte>("main", 0x7, "Query or change mainclass", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Query or change mainclass
			/// </summary>
			/// <returns></returns>
			public byte GetMain()
			{
				return _main.GetValue(_board, this);
			}

			/// <summary>
			/// Query or change mainclass
			/// </summary>
			/// <returns></returns>
			public bool SetMain(byte newMain)
			{
				var query = _main.SetValue(_board, this, newMain);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _main;
			}

			#endregion

			#region swver
			private readonly BoardCommand<string> _swver = new BoardCommand<string>("swver", 0x4, "Firmware version", CmdTypes.Get);

			/// <summary>
			/// Firmware version
			/// </summary>
			/// <returns></returns>
			public string GetSwver()
			{
				return _swver.GetValue(_board, this);
			}
			#endregion

			#region hwtype
			private readonly BoardCommand<string> _hwtype = new BoardCommand<string>("hwtype", 0x5, "Hardware type", CmdTypes.Get);

			/// <summary>
			/// Hardware type
			/// </summary>
			/// <returns></returns>
			public string GetHwtype()
			{
				return _hwtype.GetValue(_board, this);
			}
			#endregion

			#region flashraw
			private readonly BoardCommand<ulong> _flashraw = new BoardCommand<ulong>("flashraw", 0xD, "Write value to flash address", CmdTypes.SetAddress);

			/// <summary>
			/// Write value to flash address
			/// </summary>
			/// <returns></returns>
			public bool SetFlashraw(ulong newFlashraw, ulong address)
			{
				var query = _flashraw.SetValue(_board, this, newFlashraw, address);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _flashraw;
			}
			#endregion

			#region flashdump
			private readonly BoardCommand<string> _flashdump = new BoardCommand<string>("flashdump", 0xC, "Read all flash variables (val:adr)", CmdTypes.Get);

			/// <summary>
			/// Read all flash variables (val:adr)
			/// </summary>
			/// <returns></returns>
			public string GetFlashdump()
			{
				return _flashdump.GetValue(_board, this);
			}
			#endregion

			#region errors
			private readonly BoardCommand<string> _errors = new BoardCommand<string>("errors", 0xA, "Read error states", CmdTypes.Get);

			/// <summary>
			/// Read error states
			/// </summary>
			/// <returns></returns>
			public string GetErrors()
			{
				return _errors.GetValue(_board, this);
			}
			#endregion

			#region errorsclr
			private readonly BoardCommand<bool> _errorsclr = new BoardCommand<bool>("errorsclr", 0xB, "Reset errors", CmdTypes.Get);

			/// <summary>
			/// Reset errors
			/// </summary>
			/// <returns></returns>
			public bool GetErrorsclr()
			{
				return _errorsclr.GetValue(_board, this);
			}
			#endregion

			#region heapfree
			private readonly BoardCommand<string> _heapfree = new BoardCommand<string>("heapfree", 0x11, "Memory info", CmdTypes.Get);

			/// <summary>
			/// Memory info
			/// </summary>
			/// <returns></returns>
			public string GetHeapfree()
			{
				return _heapfree.GetValue(_board, this);
			}
			#endregion

			#region format
			private readonly BoardCommand<bool> _format = new BoardCommand<bool>("format", 0x9, "set format=1 to erase all stored values", CmdTypes.Set);

			/// <summary>
			/// set format=1 to erase all stored values
			/// </summary>
			/// <returns></returns>
			public bool SetFormat(bool newFormat)
			{
				var query = _format.SetValue(_board, this, newFormat);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _format;
			}

			#endregion

			#region debug
			private readonly BoardCommand<bool> _debug = new BoardCommand<bool>("debug", 0x13, "Enable or disable debug commands", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Enable or disable debug commands
			/// </summary>
			/// <returns></returns>
			public bool GetDebug()
			{
				return _debug.GetValue(_board, this);
			}

			/// <summary>
			/// Enable or disable debug commands
			/// </summary>
			/// <returns></returns>
			public bool SetDebug(bool newDebug)
			{
				var query = _debug.SetValue(_board, this, newDebug);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _debug;
			}

			#endregion

			#region devid
			private readonly BoardCommand<string> _devid = new BoardCommand<string>("devid", 0x14, "Get chip dev id and rev id", CmdTypes.Get);

			/// <summary>
			/// Get chip dev id and rev id
			/// </summary>
			/// <returns></returns>
			public string GetDevid()
			{
				return _devid.GetValue(_board, this);
			}
			#endregion
		}
		public class TMC4671Driver : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0x81;
			public override string Prefix => "tmc";

			internal TMC4671Driver(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region cpr
			private readonly BoardCommand<ulong> _cpr = new BoardCommand<ulong>("cpr", 0x0, "CPR in TMC", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// CPR in TMC
			/// </summary>
			/// <returns></returns>
			public ulong GetCpr()
			{
				return _cpr.GetValue(_board, this);
			}

			/// <summary>
			/// CPR in TMC
			/// </summary>
			/// <returns></returns>
			public bool SetCpr(ulong newCpr)
			{
				var query = _cpr.SetValue(_board, this, newCpr);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _cpr;
			}

			#endregion

			#region mtype
			private readonly BoardCommand<byte> _mtype = new BoardCommand<byte>("mtype", 0x1, "Motor type", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// Motor type
			/// </summary>
			/// <returns></returns>
			public byte GetMtype()
			{
				return _mtype.GetValue(_board, this);
			}

			/// <summary>
			/// Motor type
			/// </summary>
			/// <returns></returns>
			public bool SetMtype(byte newMtype)
			{
				var query = _mtype.SetValue(_board, this, newMtype);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _mtype;
			}


			/// <summary>
			/// Motor type
			/// </summary>
			/// <returns></returns>
			public string GetMtypeInfo()
			{
				return _mtype.GetInfo(_board, this);
			}
			#endregion

			#region encsrc
			private readonly BoardCommand<byte> _encsrc = new BoardCommand<byte>("encsrc", 0x2, "Encoder source", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// Encoder source
			/// </summary>
			/// <returns></returns>
			public byte GetEncsrc()
			{
				return _encsrc.GetValue(_board, this);
			}

			/// <summary>
			/// Encoder source
			/// </summary>
			/// <returns></returns>
			public bool SetEncsrc(byte newEncsrc)
			{
				var query = _encsrc.SetValue(_board, this, newEncsrc);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _encsrc;
			}


			/// <summary>
			/// Encoder source
			/// </summary>
			/// <returns></returns>
			public string GetEncsrcInfo()
			{
				return _encsrc.GetInfo(_board, this);
			}
			#endregion

			#region tmcHwType
			private readonly BoardCommand<byte> _tmcHwType = new BoardCommand<byte>("tmcHwType", 0x3, "Version of TMC board", CmdTypes.Get | CmdTypes.Set | CmdTypes.Info);

			/// <summary>
			/// Version of TMC board
			/// </summary>
			/// <returns></returns>
			public byte GetTmchwtype()
			{
				return _tmcHwType.GetValue(_board, this);
			}

			/// <summary>
			/// Version of TMC board
			/// </summary>
			/// <returns></returns>
			public bool SetTmchwtype(byte newTmchwtype)
			{
				var query = _tmcHwType.SetValue(_board, this, newTmchwtype);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _tmcHwType;
			}


			/// <summary>
			/// Version of TMC board
			/// </summary>
			/// <returns></returns>
			public string GetTmchwtypeInfo()
			{
				return _tmcHwType.GetInfo(_board, this);
			}
			#endregion

			#region encalign
			private readonly BoardCommand<bool> _encalign = new BoardCommand<bool>("encalign", 0x4, "Align encoder", CmdTypes.Get);

			/// <summary>
			/// Align encoder
			/// </summary>
			/// <returns></returns>
			public bool GetEncalign()
			{
				return _encalign.GetValue(_board, this);
			}
			#endregion

			#region poles
			private readonly BoardCommand<byte> _poles = new BoardCommand<byte>("poles", 0x5, "Motor pole pairs", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Motor pole pairs
			/// </summary>
			/// <returns></returns>
			public byte GetPoles()
			{
				return _poles.GetValue(_board, this);
			}

			/// <summary>
			/// Motor pole pairs
			/// </summary>
			/// <returns></returns>
			public bool SetPoles(byte newPoles)
			{
				var query = _poles.SetValue(_board, this, newPoles);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _poles;
			}

			#endregion

			#region acttrq
			private readonly BoardCommand<string> _acttrq = new BoardCommand<string>("acttrq", 0x6, "Measure torque and flux", CmdTypes.Get);

			/// <summary>
			/// Measure torque and flux
			/// </summary>
			/// <returns></returns>
			public string GetActtrq()
			{
				return _acttrq.GetValue(_board, this);
			}
			#endregion

			#region pwmlim
			private readonly BoardCommand<ulong> _pwmlim = new BoardCommand<ulong>("pwmlim", 0x7, "PWM limit", CmdTypes.Get | CmdTypes.Set | CmdTypes.Debug);

			/// <summary>
			/// PWM limit
			/// </summary>
			/// <returns></returns>
			public ulong GetPwmlim()
			{
				return _pwmlim.GetValue(_board, this);
			}

			/// <summary>
			/// PWM limit
			/// </summary>
			/// <returns></returns>
			public bool SetPwmlim(ulong newPwmlim)
			{
				var query = _pwmlim.SetValue(_board, this, newPwmlim);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _pwmlim;
			}

			#endregion

			#region torqueP
			private readonly BoardCommand<ulong> _torqueP = new BoardCommand<ulong>("torqueP", 0x8, "Torque P", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Torque P
			/// </summary>
			/// <returns></returns>
			public ulong GetTorquep()
			{
				return _torqueP.GetValue(_board, this);
			}

			/// <summary>
			/// Torque P
			/// </summary>
			/// <returns></returns>
			public bool SetTorquep(ulong newTorquep)
			{
				var query = _torqueP.SetValue(_board, this, newTorquep);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _torqueP;
			}

			#endregion

			#region torqueI
			private readonly BoardCommand<ulong> _torqueI = new BoardCommand<ulong>("torqueI", 0x9, "Torque I", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Torque I
			/// </summary>
			/// <returns></returns>
			public ulong GetTorquei()
			{
				return _torqueI.GetValue(_board, this);
			}

			/// <summary>
			/// Torque I
			/// </summary>
			/// <returns></returns>
			public bool SetTorquei(ulong newTorquei)
			{
				var query = _torqueI.SetValue(_board, this, newTorquei);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _torqueI;
			}

			#endregion

			#region fluxP
			private readonly BoardCommand<ulong> _fluxP = new BoardCommand<ulong>("fluxP", 0xA, "Flux P", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Flux P
			/// </summary>
			/// <returns></returns>
			public ulong GetFluxp()
			{
				return _fluxP.GetValue(_board, this);
			}

			/// <summary>
			/// Flux P
			/// </summary>
			/// <returns></returns>
			public bool SetFluxp(ulong newFluxp)
			{
				var query = _fluxP.SetValue(_board, this, newFluxp);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _fluxP;
			}

			#endregion

			#region fluxI
			private readonly BoardCommand<ulong> _fluxI = new BoardCommand<ulong>("fluxI", 0xB, "Flux I", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Flux I
			/// </summary>
			/// <returns></returns>
			public ulong GetFluxi()
			{
				return _fluxI.GetValue(_board, this);
			}

			/// <summary>
			/// Flux I
			/// </summary>
			/// <returns></returns>
			public bool SetFluxi(ulong newFluxi)
			{
				var query = _fluxI.SetValue(_board, this, newFluxi);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _fluxI;
			}

			#endregion

			#region velocityP
			private readonly BoardCommand<ulong> _velocityP = new BoardCommand<ulong>("velocityP", 0xC, "Velocity P", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Velocity P
			/// </summary>
			/// <returns></returns>
			public ulong GetVelocityp()
			{
				return _velocityP.GetValue(_board, this);
			}

			/// <summary>
			/// Velocity P
			/// </summary>
			/// <returns></returns>
			public bool SetVelocityp(ulong newVelocityp)
			{
				var query = _velocityP.SetValue(_board, this, newVelocityp);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _velocityP;
			}

			#endregion

			#region velocityI
			private readonly BoardCommand<ulong> _velocityI = new BoardCommand<ulong>("velocityI", 0xD, "Velocity I", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Velocity I
			/// </summary>
			/// <returns></returns>
			public ulong GetVelocityi()
			{
				return _velocityI.GetValue(_board, this);
			}

			/// <summary>
			/// Velocity I
			/// </summary>
			/// <returns></returns>
			public bool SetVelocityi(ulong newVelocityi)
			{
				var query = _velocityI.SetValue(_board, this, newVelocityi);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _velocityI;
			}

			#endregion

			#region posP
			private readonly BoardCommand<ulong> _posP = new BoardCommand<ulong>("posP", 0xE, "Pos P", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Pos P
			/// </summary>
			/// <returns></returns>
			public ulong GetPosp()
			{
				return _posP.GetValue(_board, this);
			}

			/// <summary>
			/// Pos P
			/// </summary>
			/// <returns></returns>
			public bool SetPosp(ulong newPosp)
			{
				var query = _posP.SetValue(_board, this, newPosp);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _posP;
			}

			#endregion

			#region posI
			private readonly BoardCommand<ulong> _posI = new BoardCommand<ulong>("posI", 0xF, "Pos I", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Pos I
			/// </summary>
			/// <returns></returns>
			public ulong GetPosi()
			{
				return _posI.GetValue(_board, this);
			}

			/// <summary>
			/// Pos I
			/// </summary>
			/// <returns></returns>
			public bool SetPosi(ulong newPosi)
			{
				var query = _posI.SetValue(_board, this, newPosi);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _posI;
			}

			#endregion

			#region tmctype
			private readonly BoardCommand<string> _tmctype = new BoardCommand<string>("tmctype", 0x10, "Version of TMC chip", CmdTypes.Get);

			/// <summary>
			/// Version of TMC chip
			/// </summary>
			/// <returns></returns>
			public string GetTmctype()
			{
				return _tmctype.GetValue(_board, this);
			}
			#endregion

			#region pidPrec
			private readonly BoardCommand<string> _pidPrec = new BoardCommand<string>("pidPrec", 0x11, "PID precision bit0=I bit1=P. 0=Q8.8 1= Q4.12", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// PID precision bit0=I bit1=P. 0=Q8.8 1= Q4.12
			/// </summary>
			/// <returns></returns>
			public string GetPidprec()
			{
				return _pidPrec.GetValue(_board, this);
			}

			/// <summary>
			/// PID precision bit0=I bit1=P. 0=Q8.8 1= Q4.12
			/// </summary>
			/// <returns></returns>
			public bool SetPidprec(string newPidprec)
			{
				var query = _pidPrec.SetValue(_board, this, newPidprec);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _pidPrec;
			}

			#endregion

			#region phiesrc
			private readonly BoardCommand<string> _phiesrc = new BoardCommand<string>("phiesrc", 0x12, "PhiE source", CmdTypes.Get | CmdTypes.Set | CmdTypes.Debug);

			/// <summary>
			/// PhiE source
			/// </summary>
			/// <returns></returns>
			public string GetPhiesrc()
			{
				return _phiesrc.GetValue(_board, this);
			}

			/// <summary>
			/// PhiE source
			/// </summary>
			/// <returns></returns>
			public bool SetPhiesrc(string newPhiesrc)
			{
				var query = _phiesrc.SetValue(_board, this, newPhiesrc);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _phiesrc;
			}

			#endregion

			#region fluxoffset
			private readonly BoardCommand<ulong> _fluxoffset = new BoardCommand<ulong>("fluxoffset", 0x13, "Offset flux scale for field weakening", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Offset flux scale for field weakening
			/// </summary>
			/// <returns></returns>
			public ulong GetFluxoffset()
			{
				return _fluxoffset.GetValue(_board, this);
			}

			/// <summary>
			/// Offset flux scale for field weakening
			/// </summary>
			/// <returns></returns>
			public bool SetFluxoffset(ulong newFluxoffset)
			{
				var query = _fluxoffset.SetValue(_board, this, newFluxoffset);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _fluxoffset;
			}

			#endregion

			#region seqpi
			private readonly BoardCommand<bool> _seqpi = new BoardCommand<bool>("seqpi", 0x14, "Sequential PI", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Sequential PI
			/// </summary>
			/// <returns></returns>
			public bool GetSeqpi()
			{
				return _seqpi.GetValue(_board, this);
			}

			/// <summary>
			/// Sequential PI
			/// </summary>
			/// <returns></returns>
			public bool SetSeqpi(bool newSeqpi)
			{
				var query = _seqpi.SetValue(_board, this, newSeqpi);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _seqpi;
			}

			#endregion

			#region iScale
			private readonly BoardCommand<string> _iScale = new BoardCommand<string>("iScale", 0x15, "Counts per A", CmdTypes.Get);

			/// <summary>
			/// Counts per A
			/// </summary>
			/// <returns></returns>
			public string GetIscale()
			{
				return _iScale.GetValue(_board, this);
			}
			#endregion

			#region encdir
			private readonly BoardCommand<byte> _encdir = new BoardCommand<byte>("encdir", 0x16, "Encoder dir", CmdTypes.Get | CmdTypes.Set | CmdTypes.Debug);

			/// <summary>
			/// Encoder dir
			/// </summary>
			/// <returns></returns>
			public byte GetEncdir()
			{
				return _encdir.GetValue(_board, this);
			}

			/// <summary>
			/// Encoder dir
			/// </summary>
			/// <returns></returns>
			public bool SetEncdir(byte newEncdir)
			{
				var query = _encdir.SetValue(_board, this, newEncdir);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _encdir;
			}

			#endregion

			#region abnpol
			private readonly BoardCommand<ulong> _abnpol = new BoardCommand<ulong>("abnpol", 0x1F, "Encoder polarity", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Encoder polarity
			/// </summary>
			/// <returns></returns>
			public ulong GetAbnpol()
			{
				return _abnpol.GetValue(_board, this);
			}

			/// <summary>
			/// Encoder polarity
			/// </summary>
			/// <returns></returns>
			public bool SetAbnpol(ulong newAbnpol)
			{
				var query = _abnpol.SetValue(_board, this, newAbnpol);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _abnpol;
			}

			#endregion

			#region temp
			private readonly BoardCommand<float> _temp = new BoardCommand<float>("temp", 0x17, "Temperature in C", CmdTypes.Get);

			/// <summary>
			/// Temperature in C
			/// </summary>
			/// <returns></returns>
			public float GetTemp()
			{
				return _temp.GetValue(_board, this);
			}
			#endregion

			#region reg
			private readonly BoardCommand<string> _reg = new BoardCommand<string>("reg", 0x18, "Read or write a TMC register at adr", CmdTypes.SetAddress | CmdTypes.GetAddress | CmdTypes.Debug);

			/// <summary>
			/// Read or write a TMC register at adr
			/// </summary>
			/// <returns></returns>
			public string GetReg(ulong address)
			{
				return _reg.GetValue(_board, this, address);
			}

			/// <summary>
			/// Read or write a TMC register at adr
			/// </summary>
			/// <returns></returns>
			public bool SetReg(string newReg, ulong address)
			{
				var query = _reg.SetValue(_board, this, newReg, address);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _reg;
			}
			#endregion

			#region svpwm
			private readonly BoardCommand<string> _svpwm = new BoardCommand<string>("svpwm", 0x19, "Space-vector PWM", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Space-vector PWM
			/// </summary>
			/// <returns></returns>
			public string GetSvpwm()
			{
				return _svpwm.GetValue(_board, this);
			}

			/// <summary>
			/// Space-vector PWM
			/// </summary>
			/// <returns></returns>
			public bool SetSvpwm(string newSvpwm)
			{
				var query = _svpwm.SetValue(_board, this, newSvpwm);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _svpwm;
			}

			#endregion

			#region autohome
			private readonly BoardCommand<bool> _autohome = new BoardCommand<bool>("autohome", 0x1D, "Find abn index", CmdTypes.Get);

			/// <summary>
			/// Find abn index
			/// </summary>
			/// <returns></returns>
			public bool GetAutohome()
			{
				return _autohome.GetValue(_board, this);
			}
			#endregion

			#region abnindex
			private readonly BoardCommand<bool> _abnindex = new BoardCommand<bool>("abnindex", 0x1C, "Enable ABN index", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Enable ABN index
			/// </summary>
			/// <returns></returns>
			public bool GetAbnindex()
			{
				return _abnindex.GetValue(_board, this);
			}

			/// <summary>
			/// Enable ABN index
			/// </summary>
			/// <returns></returns>
			public bool SetAbnindex(bool newAbnindex)
			{
				var query = _abnindex.SetValue(_board, this, newAbnindex);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _abnindex;
			}

			#endregion

			#region calibrate
			private readonly BoardCommand<bool> _calibrate = new BoardCommand<bool>("calibrate", 0x1A, "Full calibration", CmdTypes.Get);

			/// <summary>
			/// Full calibration
			/// </summary>
			/// <returns></returns>
			public bool GetCalibrate()
			{
				return _calibrate.GetValue(_board, this);
			}
			#endregion

			#region calibrated
			private readonly BoardCommand<bool> _calibrated = new BoardCommand<bool>("calibrated", 0x1B, "Calibration valid", CmdTypes.Get);

			/// <summary>
			/// Calibration valid
			/// </summary>
			/// <returns></returns>
			public bool GetCalibrated()
			{
				return _calibrated.GetValue(_board, this);
			}
			#endregion

			#region state
			private readonly BoardCommand<byte> _state = new BoardCommand<byte>("state", 0x1E, "Get state", CmdTypes.Get);

			/// <summary>
			/// Get state
			/// </summary>
			/// <returns></returns>
			public byte GetState()
			{
				return _state.GetValue(_board, this);
			}
			#endregion

			#region combineEncoder
			private readonly BoardCommand<bool> _combineEncoder = new BoardCommand<bool>("combineEncoder", 0x20, "Use TMC for movement. External encoder for position", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Use TMC for movement. External encoder for position
			/// </summary>
			/// <returns></returns>
			public bool GetCombineencoder()
			{
				return _combineEncoder.GetValue(_board, this);
			}

			/// <summary>
			/// Use TMC for movement. External encoder for position
			/// </summary>
			/// <returns></returns>
			public bool SetCombineencoder(bool newCombineencoder)
			{
				var query = _combineEncoder.SetValue(_board, this, newCombineencoder);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _combineEncoder;
			}

			#endregion

			#region invertForce
			private readonly BoardCommand<bool> _invertForce = new BoardCommand<bool>("invertForce", 0x21, "Invert incoming forces", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Invert incoming forces
			/// </summary>
			/// <returns></returns>
			public bool GetInvertforce()
			{
				return _invertForce.GetValue(_board, this);
			}

			/// <summary>
			/// Invert incoming forces
			/// </summary>
			/// <returns></returns>
			public bool SetInvertforce(bool newInvertforce)
			{
				var query = _invertForce.SetValue(_board, this, newInvertforce);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _invertForce;
			}

			#endregion

			#region vm
			private readonly BoardCommand<ushort> _vm = new BoardCommand<ushort>("vm", 0x22, "VM in mV", CmdTypes.Get);

			/// <summary>
			/// VM in mV
			/// </summary>
			/// <returns></returns>
			public ushort GetVm()
			{
				return _vm.GetValue(_board, this);
			}
			#endregion

			#region extphie
			private readonly BoardCommand<bool> _extphie = new BoardCommand<bool>("extphie", 0x23, "external phie", CmdTypes.Get);

			/// <summary>
			/// external phie
			/// </summary>
			/// <returns></returns>
			public bool GetExtphie()
			{
				return _extphie.GetValue(_board, this);
			}
			#endregion
		}
		public class VESCDriver : BoardClass
		{

			private readonly Board _board;
			public override ushort ClassId => 0x87;
			public override string Prefix => "vesc";

			internal VESCDriver(Board board)
			{
				_board = board;
			}


			#region id
			private readonly BoardCommand<long> _id = new BoardCommand<long>("id", 0x80000001, "ID of class", CmdTypes.Get);

			/// <summary>
			/// ID of class
			/// </summary>
			/// <returns></returns>
			public long GetId()
			{
				return _id.GetValue(_board, this);
			}
			#endregion

			#region name
			private readonly BoardCommand<string> _name = new BoardCommand<string>("name", 0x80000002, "name of class", CmdTypes.Get | CmdTypes.String);

			/// <summary>
			/// name of class
			/// </summary>
			/// <returns></returns>
			public string GetName()
			{
				return _name.GetValue(_board, this);
			}
			#endregion

			#region help
			private readonly BoardCommand<string> _help = new BoardCommand<string>("help", 0x80000003, "Prints help for commands", CmdTypes.Get | CmdTypes.Info | CmdTypes.String);

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelp()
			{
				return _help.GetValue(_board, this);
			}

			/// <summary>
			/// Prints help for commands
			/// </summary>
			/// <returns></returns>
			public string GetHelpInfo()
			{
				return _help.GetInfo(_board, this);
			}
			#endregion

			#region cmduid
			private readonly BoardCommand<long> _cmduid = new BoardCommand<long>("cmduid", 0x80000005, "Command handler index", CmdTypes.Get);

			/// <summary>
			/// Command handler index
			/// </summary>
			/// <returns></returns>
			public long GetCmduid()
			{
				return _cmduid.GetValue(_board, this);
			}
			#endregion

			#region instance
			private readonly BoardCommand<long> _instance = new BoardCommand<long>("instance", 0x80000004, "Command handler instance number", CmdTypes.Get);

			/// <summary>
			/// Command handler instance number
			/// </summary>
			/// <returns></returns>
			public long GetInstance()
			{
				return _instance.GetValue(_board, this);
			}
			#endregion

			#region offbcanid
			private readonly BoardCommand<uint> _offbcanid = new BoardCommand<uint>("offbcanid", 0x0, "CAN id of OpenFFBoard Axis", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// CAN id of OpenFFBoard Axis
			/// </summary>
			/// <returns></returns>
			public uint GetOffbcanid()
			{
				return _offbcanid.GetValue(_board, this);
			}

			/// <summary>
			/// CAN id of OpenFFBoard Axis
			/// </summary>
			/// <returns></returns>
			public bool SetOffbcanid(uint newOffbcanid)
			{
				var query = _offbcanid.SetValue(_board, this, newOffbcanid);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _offbcanid;
			}

			#endregion

			#region vesccanid
			private readonly BoardCommand<uint> _vesccanid = new BoardCommand<uint>("vesccanid", 0x1, "CAN id of VESC", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// CAN id of VESC
			/// </summary>
			/// <returns></returns>
			public uint GetVesccanid()
			{
				return _vesccanid.GetValue(_board, this);
			}

			/// <summary>
			/// CAN id of VESC
			/// </summary>
			/// <returns></returns>
			public bool SetVesccanid(uint newVesccanid)
			{
				var query = _vesccanid.SetValue(_board, this, newVesccanid);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _vesccanid;
			}

			#endregion

			#region canspd
			private readonly BoardCommand<byte> _canspd = new BoardCommand<byte>("canspd", 0x2, "CAN baud (3=250k 4=500k 5=1M)", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// CAN baud (3=250k 4=500k 5=1M)
			/// </summary>
			/// <returns></returns>
			public byte GetCanspd()
			{
				return _canspd.GetValue(_board, this);
			}

			/// <summary>
			/// CAN baud (3=250k 4=500k 5=1M)
			/// </summary>
			/// <returns></returns>
			public bool SetCanspd(byte newCanspd)
			{
				var query = _canspd.SetValue(_board, this, newCanspd);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _canspd;
			}

			#endregion

			#region errorflags
			private readonly BoardCommand<string> _errorflags = new BoardCommand<string>("errorflags", 0x3, "VESC error state", CmdTypes.Get);

			/// <summary>
			/// VESC error state
			/// </summary>
			/// <returns></returns>
			public string GetErrorflags()
			{
				return _errorflags.GetValue(_board, this);
			}
			#endregion

			#region vescstate
			private readonly BoardCommand<string> _vescstate = new BoardCommand<string>("vescstate", 0x4, "VESC state", CmdTypes.Get);

			/// <summary>
			/// VESC state
			/// </summary>
			/// <returns></returns>
			public string GetVescstate()
			{
				return _vescstate.GetValue(_board, this);
			}
			#endregion

			#region voltage
			private readonly BoardCommand<uint> _voltage = new BoardCommand<uint>("voltage", 0x5, "VESC supply voltage (mV)", CmdTypes.Get);

			/// <summary>
			/// VESC supply voltage (mV)
			/// </summary>
			/// <returns></returns>
			public uint GetVoltage()
			{
				return _voltage.GetValue(_board, this);
			}
			#endregion

			#region encrate
			private readonly BoardCommand<uint> _encrate = new BoardCommand<uint>("encrate", 0x6, "Encoder update rate", CmdTypes.Get);

			/// <summary>
			/// Encoder update rate
			/// </summary>
			/// <returns></returns>
			public uint GetEncrate()
			{
				return _encrate.GetValue(_board, this);
			}
			#endregion

			#region pos
			private readonly BoardCommand<long> _pos = new BoardCommand<long>("pos", 0x7, "VESC position", CmdTypes.Get);

			/// <summary>
			/// VESC position
			/// </summary>
			/// <returns></returns>
			public long GetPos()
			{
				return _pos.GetValue(_board, this);
			}
			#endregion

			#region torque
			private readonly BoardCommand<long> _torque = new BoardCommand<long>("torque", 0x8, "Current VESC torque", CmdTypes.Get);

			/// <summary>
			/// Current VESC torque
			/// </summary>
			/// <returns></returns>
			public long GetTorque()
			{
				return _torque.GetValue(_board, this);
			}
			#endregion

			#region forceposread
			private readonly BoardCommand<bool> _forceposread = new BoardCommand<bool>("forceposread", 0x9, "Force a position update", CmdTypes.Get);

			/// <summary>
			/// Force a position update
			/// </summary>
			/// <returns></returns>
			public bool GetForceposread()
			{
				return _forceposread.GetValue(_board, this);
			}
			#endregion

			#region useencoder
			private readonly BoardCommand<bool> _useencoder = new BoardCommand<bool>("useencoder", 0xA, "Enable VESC encoder", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Enable VESC encoder
			/// </summary>
			/// <returns></returns>
			public bool GetUseencoder()
			{
				return _useencoder.GetValue(_board, this);
			}

			/// <summary>
			/// Enable VESC encoder
			/// </summary>
			/// <returns></returns>
			public bool SetUseencoder(bool newUseencoder)
			{
				var query = _useencoder.SetValue(_board, this, newUseencoder);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _useencoder;
			}

			#endregion

			#region offset
			private readonly BoardCommand<long> _offset = new BoardCommand<long>("offset", 0xB, "Get or set encoder offset", CmdTypes.Get | CmdTypes.Set);

			/// <summary>
			/// Get or set encoder offset
			/// </summary>
			/// <returns></returns>
			public long GetOffset()
			{
				return _offset.GetValue(_board, this);
			}

			/// <summary>
			/// Get or set encoder offset
			/// </summary>
			/// <returns></returns>
			public bool SetOffset(long newOffset)
			{
				var query = _offset.SetValue(_board, this, newOffset);
				return query.Type == CmdType.Acknowledgment && query.ClassId == ClassId && query.Cmd == _offset;
			}

			#endregion
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
	}

	public abstract class BoardClass
	{
		public abstract ushort ClassId { get; }
		public abstract string Prefix { get; }
		[Flags]
		public enum CmdTypes
		{
			Get = 0,
			GetAddress = 1,
			Set = 2,
			SetAddress = 4,
			Info = 8,
			Debug = 16,
			String = 32
		}
	}

	public class BoardCommand<T> : BoardCommand
	{
		public override string Name { get; }
		public override ulong Id { get; }
		public override string Description { get; }

		public override BoardClass.CmdTypes Types { get; set; }

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
				Commands.BoardResponse response = board.GetBoardData(boardClass, null, this, null);
				if (response.Type == Commands.CmdType.Error || response.Type == Commands.CmdType.NotFound)
					return default;
				if (Convert.ToString(response.Data) == "OK")
					return (T)Convert.ChangeType(true, typeof(T));

				if (typeof(T) == typeof(bool))
					return (T)Convert.ChangeType(Convert.ToString(response.Data) == "1", typeof(T));

				return (T)Convert.ChangeType(response.Data, typeof(T));
			}

			throw new Exception("Command does not support get request");
		}

		public T GetValue(Board board, BoardClass boardClass, ulong? address)
		{
			if (Types.HasFlag(BoardClass.CmdTypes.Get))
			{
				Commands.BoardResponse response = board.GetBoardData(boardClass, null, this, address);
				return (T)Convert.ChangeType(response.Data, typeof(T));
			}

			throw new Exception("Command does not support get address request");
		}

		public Commands.BoardResponse SetValue(Board board, BoardClass boardClass, T value)
		{
			if (Types.HasFlag(BoardClass.CmdTypes.Set))
			{
				return board.SetBoardData(boardClass, 0, this, value, null);
			}

			throw new Exception("Command does not support set request");
		}

		public Commands.BoardResponse SetValue(Board board, BoardClass boardClass, T value, ulong address)
		{
			if (Types.HasFlag(BoardClass.CmdTypes.Set) || Types.HasFlag(BoardClass.CmdTypes.SetAddress))
			{
				return board.SetBoardData(boardClass, 0, this, value, address);
			}

			throw new Exception("Command does not support set address request");
		}

		public string GetInfo(Board board, BoardClass boardClass)
		{
			if (Types.HasFlag(BoardClass.CmdTypes.Info))
			{
				Commands.BoardResponse response = board.GetBoardData(boardClass, null, this, null, true);
				return Convert.ToString(response.Data);
			}

			throw new Exception("Command does not support info request");
		}
	}

	public abstract class BoardCommand
	{
		public abstract string Name { get; }
		public abstract ulong Id { get; }
		public abstract string Description { get; }
		public abstract BoardClass.CmdTypes Types { get; set; }
	}
}

