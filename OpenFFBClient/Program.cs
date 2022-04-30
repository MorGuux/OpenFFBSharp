using System;
using System.Threading.Tasks;
using OpenFFBoard;

namespace OpenFFBClient
{
    class Program
    {

        static void Main(string[] args)
        {
            //--SERIAL--//
            var boards = OpenFFBoard.Serial.GetBoards();
            Board openFFBoard = new Serial(Serial.GetBoards()[1], 500000);

            //--HID--//
            //var boards = OpenFFBoard.Hid.GetBoardsAsync().Result;
            //Board openFFBoard = new OpenFFBoard.Hid(boards[0]);

            openFFBoard.Connect();

            Console.WriteLine("Power: {0}", openFFBoard.Axis.GetPower());
            Console.WriteLine("Rotation Degrees: {0}°", openFFBoard.Axis.GetDegrees());
            Console.WriteLine("Max Speed: {0}", openFFBoard.Axis.GetMaxspeed());
            Console.WriteLine("Max Torque Rate: {0}", openFFBoard.Axis.GetMaxtorquerate());
            Console.WriteLine("Damper: {0}", openFFBoard.Axis.GetAxisdamper());
            Console.WriteLine("Endstop Gain: {0}", openFFBoard.Axis.GetEsgain());
            Console.WriteLine("Effects Ratio: {0}", openFFBoard.Axis.GetFxratio());
            Console.WriteLine("Axis Position: {0}", openFFBoard.Axis.GetPos());

            Console.WriteLine("Device ID: {0}", openFFBoard.System.GetDevid());
            Console.WriteLine("Internal Voltage: {0}", openFFBoard.System.GetVint());
            Console.WriteLine("External Voltage: {0}", openFFBoard.System.GetVext());

            Console.ReadKey();
            
        }

    }
}
