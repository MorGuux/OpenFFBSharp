namespace OpenFFBoard
{
    public abstract class Board
    {
        public bool IsConnected { get; internal set; }
        protected Board()
        {
            Axis = new Commands.FFBAxis(this);
            System = new Commands.System(this);
        }

        public Commands.FFBAxis Axis { get; }
        public Commands.System System { get; }
        public abstract void Connect();
        public abstract void Disconnect();
        public abstract Commands.BoardResponse GetBoardData(BoardClass boardClass, byte instance, BoardCommand cmd);
        public abstract Commands.BoardResponse GetBoardData(BoardClass boardClass, byte instance, BoardCommand cmd, ulong address);
        public abstract Commands.BoardResponse GetBoardData(BoardClass boardClass, BoardCommand cmd);
        public abstract Commands.BoardResponse GetBoardData(BoardClass boardClass, BoardCommand cmd, ulong address);
        public abstract Commands.BoardResponse SetBoardData<T>(BoardClass boardClass, byte instance, BoardCommand<T> cmd, T value, ulong address = 0);
    }
}
