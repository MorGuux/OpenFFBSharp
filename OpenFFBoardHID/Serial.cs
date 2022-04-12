using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFFBoard
{
    public class Serial : Board
    {
        public override void Connect()
        {
            throw new NotImplementedException();
        }

        public override void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void GetBoards()
        {
            throw new NotImplementedException();
        }

        public override Commands.BoardResponse GetBoardData(ushort classId, byte instance, uint cmd)
        {
            throw new NotImplementedException();
        }

        public override Commands.BoardResponse SetBoardData(ushort classId, byte instance, uint cmd, ulong data, ulong address = 0)
        {
            throw new NotImplementedException();
        }
    }
}
