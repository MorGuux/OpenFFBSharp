using static OpenFFBoard.Commands;

namespace OpenFFBoard
{
    public abstract class Board
    {
        public bool IsConnected { get; internal set; }
        protected Board()
        {
            Axis = new Commands.Axis(this);
            FX = new Commands.FX(this);
            Main = new Commands.Main(this);
            System = new Commands.System(this);
            TMC = new Commands.TMC(this);
        }

        public Commands.Axis Axis { get; }
        public Commands.FX FX { get; }
        public Commands.Main Main { get; }
        public Commands.System System { get; }
        public Commands.TMC TMC { get; }


        public abstract void Connect();
        public abstract void Disconnect();
        public abstract Commands.BoardResponse GetBoardData(BoardClass boardClass, byte? instance, BoardCommand cmd, ulong? address, bool info = false);
        public abstract Commands.BoardResponse SetBoardData<T>(BoardClass boardClass, byte instance, BoardCommand<T> cmd, T value, ulong? address);
    }
}