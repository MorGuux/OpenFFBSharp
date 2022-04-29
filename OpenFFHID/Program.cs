using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OpenFFBoard;

namespace OpenFFBClient
{
    class Program
    {

        static async Task Main(string[] args)
        {

            /*
            //Get list of OpenFFBoards
            var boards = OpenFFBoard.Serial.GetBoards();

            var offbDevice = boards[1];

            OpenFFBoard.Board openFFBoard = new OpenFFBoard.Serial(offbDevice, 500000);

            //Initialize the device
            openFFBoard.Connect();

            Console.WriteLine("Power: {0}", openFFBoard.Axis.GetPower());
            Console.WriteLine("Rotation Degrees: {0}°", openFFBoard.Axis.GetRotationDegrees());
            Console.WriteLine("Max Speed: {0}", openFFBoard.Axis.GetMaxSpeed());
            Console.WriteLine("Max Torque Rate: {0}", openFFBoard.Axis.GetMaxTorqueRate());
            Console.WriteLine("Damper: {0}", openFFBoard.Axis.GetAxisDamper());
            Console.WriteLine("Endstop Gain: {0}", openFFBoard.Axis.GetEndstopGain());
            Console.WriteLine("Effects Ratio: {0}", openFFBoard.Axis.GetEffectsRatio());
            Console.WriteLine("Axis Position: {0}", openFFBoard.Axis.GetAxisPosition());
            Console.WriteLine("Zeroed Encoder: {0}", openFFBoard.Axis.ZeroEncoder().ToString());
            //Console.WriteLine("Main class: {0}", openFFBoard.System.GetActiveMainClass());

            openFFBoard.Disconnect();

            Console.ReadKey();

            */

            //--SERIAL--//
            var boards = OpenFFBoard.Serial.GetBoards();
            Board openFFBoard = new Serial(Serial.GetBoards()[1], 500000);

            //--HID--//
            //var boards = OpenFFBoard.Hid.GetBoardsAsync().Result;
            //Board openFFBoard = new OpenFFBoard.Hid(boards[0]);

            openFFBoard.Connect();

            Console.WriteLine("Power: {0}", openFFBoard.Axis.GetPower());
            Console.WriteLine("Rotation Degrees: {0}°", openFFBoard.Axis.GetRotationDegrees());
            Console.WriteLine("Max Speed: {0}", openFFBoard.Axis.GetMaxSpeed());
            Console.WriteLine("Max Torque Rate: {0}", openFFBoard.Axis.GetMaxTorqueRate());
            Console.WriteLine("Damper: {0}", openFFBoard.Axis.GetAxisDamper());
            Console.WriteLine("Endstop Gain: {0}", openFFBoard.Axis.GetEndstopGain());
            Console.WriteLine("Effects Ratio: {0}", openFFBoard.Axis.GetEffectsRatio());
            Console.WriteLine("Axis Position: {0}", openFFBoard.Axis.GetAxisPosition());

            Console.WriteLine("Device ID: {0}", openFFBoard.System.GetDeviceId());

            Console.ReadKey();
            
        }

    }
}
