using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenFFBoard;

namespace OpenFFBSharpTests
{
    [TestClass]
    public class Connections
    {
        [TestMethod]
        public void SerialConnection()
        {
            var boards = Serial.GetBoards();
            Board openFFBoard = new Serial(Serial.GetBoards()[1], 500000);
            openFFBoard.Connect();
            Assert.IsTrue(openFFBoard.IsConnected);
            openFFBoard.Disconnect();
        }

        [TestMethod]
        public void HIDConnection()
        {
            var boards = OpenFFBoard.Hid.GetBoardsAsync().Result;
            Board openFFBoard = new OpenFFBoard.Hid(boards[0]);
            openFFBoard.Connect();
            Assert.IsTrue(openFFBoard.IsConnected);
            openFFBoard.Disconnect();
        }
    }
}
