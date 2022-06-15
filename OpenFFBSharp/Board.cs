using static OpenFFBoard.Commands;

namespace OpenFFBoard
{
	public abstract class Board
	{
		public bool IsConnected { get; internal set; }
		protected Board()
		{
			AnalogAxes = new Commands.AnalogAxes(this);
			AnalogShifter = new Commands.AnalogShifter(this);
			Axis = new Commands.Axis(this);
			CANAnalogAxes = new Commands.CANAnalogAxes(this);
			CANButtons = new Commands.CANButtons(this);
			CANPort = new Commands.CANPort(this);
			DigitalButtons = new Commands.DigitalButtons(this);
			FX = new Commands.FX(this);
			I2CPort = new Commands.I2CPort(this);
			Main = new Commands.Main(this);
			MTSPI = new Commands.MTSPI(this);
			ODriveDriver = new Commands.ODriveDriver(this);
			PCF8574 = new Commands.PCF8574(this);
			PWMDriver = new Commands.PWMDriver(this);
			SPIButtons = new Commands.SPIButtons(this);
			System = new Commands.System(this);
			TMC4671Driver = new Commands.TMC4671Driver(this);
			VESCDriver = new Commands.VESCDriver(this);
		}

		public Commands.AnalogAxes AnalogAxes { get; }
		public Commands.AnalogShifter AnalogShifter { get; }
		public Commands.Axis Axis { get; }
		public Commands.CANAnalogAxes CANAnalogAxes { get; }
		public Commands.CANButtons CANButtons { get; }
		public Commands.CANPort CANPort { get; }
		public Commands.DigitalButtons DigitalButtons { get; }
		public Commands.FX FX { get; }
		public Commands.I2CPort I2CPort { get; }
		public Commands.Main Main { get; }
		public Commands.MTSPI MTSPI { get; }
		public Commands.ODriveDriver ODriveDriver { get; }
		public Commands.PCF8574 PCF8574 { get; }
		public Commands.PWMDriver PWMDriver { get; }
		public Commands.SPIButtons SPIButtons { get; }
		public Commands.System System { get; }
		public Commands.TMC4671Driver TMC4671Driver { get; }
		public Commands.VESCDriver VESCDriver { get; }


		public abstract void Connect();
		public abstract void Disconnect();
		internal abstract Commands.BoardResponse GetBoardData(BoardClass boardClass, byte? instance, BoardCommand cmd, ulong? address, bool info = false);
		internal abstract Commands.BoardResponse SetBoardData<T>(BoardClass boardClass, byte instance, BoardCommand<T> cmd, T value, ulong? address);
	}
}
