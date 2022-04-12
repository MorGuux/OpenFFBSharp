using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFFBoard
{
    public abstract class Board
    {
        protected Board()
        {
            Axis = new Commands.FFBAxis(this);
            System = new Commands.System(this);
        }

        public Commands.FFBAxis Axis { get; }
        public Commands.System System { get; }
        public abstract void Connect();
        public abstract void Disconnect();
        public abstract Commands.BoardResponse GetBoardData(ushort classId, byte instance, uint cmd);
        public abstract Commands.BoardResponse SetBoardData(ushort classId, byte instance, uint cmd, ulong data, ulong address = 0);
    }
}
