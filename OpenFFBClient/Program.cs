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

            //openFFBoard.System.SetDebug(true);

            #region AXIS
            Console.WriteLine("---FFB AXIS---");
            Console.WriteLine("ID: {0}", openFFBoard.Axis.GetId());
            Console.WriteLine("Name: {0}", openFFBoard.Axis.GetName());
            //Console.WriteLine("Help: {0}", openFFBoard.Axis.GetHelp());
            Console.WriteLine("CMDUID: {0}", openFFBoard.Axis.GetCmduid());
            Console.WriteLine("Instance: {0}", openFFBoard.Axis.GetInstance());
            Console.WriteLine("Power: {0}", openFFBoard.Axis.GetPower());
            Console.WriteLine("Rotation Degrees: {0}°", openFFBoard.Axis.GetDegrees());
            Console.WriteLine("Endstop Gain: {0}", openFFBoard.Axis.GetEsgain());
            Console.WriteLine("Zero encoder: {0}", openFFBoard.Axis.GetZeroenc());
            Console.WriteLine("Inverted: {0}", openFFBoard.Axis.GetInvert());
            Console.WriteLine("Idle spring: {0}", openFFBoard.Axis.GetIdlespring());
            Console.WriteLine("Damper: {0}", openFFBoard.Axis.GetAxisdamper());
            Console.WriteLine("Encoder type: {0}", openFFBoard.Axis.GetEnctype());
            Console.WriteLine("Driver type: {0}", openFFBoard.Axis.GetDrvtype());
            Console.WriteLine("Encoder position: {0}", openFFBoard.Axis.GetPos());
            Console.WriteLine("Max Speed: {0}", openFFBoard.Axis.GetMaxspeed());
            Console.WriteLine("Max Torque Rate: {0}", openFFBoard.Axis.GetMaxtorquerate());
            Console.WriteLine("Axis Position: {0}", openFFBoard.Axis.GetPos());
            Console.WriteLine("Effects Ratio: {0}", openFFBoard.Axis.GetFxratio());
            Console.WriteLine("Current torque: {0}", openFFBoard.Axis.GetCurtorque());
            Console.WriteLine("Current position: {0}", openFFBoard.Axis.GetCurpos());
            #endregion

            #region SYSTEM
            Console.WriteLine("---SYSTEM---");
            //Console.WriteLine("Help: {0}", openFFBoard.System.GetHelp());
            //Console.WriteLine("Reboot: {0}", openFFBoard.System.GetReboot());
            //Console.WriteLine("DFU: {0}", openFFBoard.System.GetDfu());
            Console.WriteLine("List mainclasses: {0}", openFFBoard.System.GetLsmain());
            Console.WriteLine("List active classes: {0}", openFFBoard.System.GetLsactive());
            Console.WriteLine("Internal Voltage: {0}", (float)openFFBoard.System.GetVint() / 1000);
            Console.WriteLine("External Voltage: {0}", (float)openFFBoard.System.GetVext() / 1000);
            Console.WriteLine("Main class: {0}", openFFBoard.System.GetMain());
            Console.WriteLine("Firmware version: {0}", openFFBoard.System.GetSwver());
            Console.WriteLine("Hardware type: {0}", openFFBoard.System.GetHwtype());
            //Console.WriteLine("Flash raw: {0}", openFFBoard.System.SetFlashRaw());
            Console.WriteLine("Flash dump: {0}", openFFBoard.System.GetFlashdump());
            Console.WriteLine("Errors: {0}", openFFBoard.System.GetErrors());
            Console.WriteLine("Clear errors: {0}", openFFBoard.System.GetErrorsclr());
            Console.WriteLine("Heap free: {0}", openFFBoard.System.GetHeapfree());
            //Console.WriteLine("Format: {0}", openFFBoard.System.SetFormat(true));
            Console.WriteLine("Debug: {0}", openFFBoard.System.GetDebug());
            Console.WriteLine("Device ID: {0}", openFFBoard.System.GetDevid());
            #endregion

            #region FFB EFFECTS
            Console.WriteLine("---FFB EFFECTS---");
            Console.WriteLine("ID: {0}", openFFBoard.FX.GetId());
            Console.WriteLine("Name: {0}", openFFBoard.FX.GetName());
            //Console.WriteLine("Help: {0}", openFFBoard.FX.GetHelp());
            Console.WriteLine("CMDUID: {0}", openFFBoard.FX.GetCmduid());
            Console.WriteLine("Instance: {0}", openFFBoard.FX.GetInstance());
            Console.WriteLine("CF Filter Freq: {0}", openFFBoard.FX.GetFiltercffreq());
            Console.WriteLine("CF Filter Q: {0}", openFFBoard.FX.GetFiltercfq());
            Console.WriteLine("Spring: {0}", openFFBoard.FX.GetSpring());
            Console.WriteLine("Friction: {0}", openFFBoard.FX.GetFriction());
            Console.WriteLine("Damper: {0}", openFFBoard.FX.GetDamper());
            Console.WriteLine("Inertia: {0}", openFFBoard.FX.GetInertia());
            Console.WriteLine("Effects: {0}", openFFBoard.FX.GetEffects());
            #endregion

            #region MAIN
            Console.WriteLine("---MAIN---");
            Console.WriteLine("ID: {0}", openFFBoard.Main.GetId());
            Console.WriteLine("Name: {0}", openFFBoard.Main.GetName());
            //Console.WriteLine("Help: {0}", openFFBoard.Main.GetHelp());
            Console.WriteLine("CMDUID: {0}", openFFBoard.Main.GetCmduid());
            Console.WriteLine("Instance: {0}", openFFBoard.Main.GetInstance());
            Console.WriteLine("FFB Active: {0}", openFFBoard.Main.GetFfbactive());
            Console.WriteLine("Enabled button sources: {0}", openFFBoard.Main.GetBtntypes());
            Console.WriteLine("Enable button source: {0}", openFFBoard.Main.GetAddbtn());
            Console.WriteLine("List available button sources: {0}", openFFBoard.Main.GetLsbtn());
            Console.WriteLine("Enabled analog sources: {0}", openFFBoard.Main.GetAintypes());
            Console.WriteLine("Enable analog source: {0}", openFFBoard.Main.GetAddain());
            Console.WriteLine("List available analog sources: {0}", openFFBoard.Main.GetLsbtn());
            Console.WriteLine("HID rate: {0}", openFFBoard.Main.GetHidrate());
            Console.WriteLine("HID send speed: {0}", openFFBoard.Main.GetHidsendspd());
            #endregion

            #region TMC
            Console.WriteLine("---TMC4671---");
            Console.WriteLine("ID: {0}", openFFBoard.TMC.GetId());
            Console.WriteLine("Name: {0}", openFFBoard.TMC.GetName());
            //Console.WriteLine("Help: {0}", openFFBoard.TMC.GetHelp());
            Console.WriteLine("CMDUID: {0}", openFFBoard.TMC.GetCmduid());
            Console.WriteLine("Instance: {0}", openFFBoard.TMC.GetInstance());
            Console.WriteLine("Encoder CPR: {0}", openFFBoard.TMC.GetCpr());
            Console.WriteLine("Motor type: {0}", openFFBoard.TMC.GetMtype());
            Console.WriteLine("Encoder source: {0}", openFFBoard.TMC.GetEncsrc());
            Console.WriteLine("Hardware version: {0}", openFFBoard.TMC.GetTmchwtype());
            //Console.WriteLine("Align encoder: {0}", openFFBoard.TMC.GetEncalign());
            Console.WriteLine("Motor pole pairs: {0}", openFFBoard.TMC.GetPoles());
            Console.WriteLine("Torque and flux: {0}", openFFBoard.TMC.GetActtrq());
            try
            {
                Console.WriteLine("PWM Limit: {0}", openFFBoard.TMC.GetPwmlim());
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("PWM Limit: Board is not in debug mode");
            }
            Console.WriteLine("Torque P: {0}", openFFBoard.TMC.GetTorquep());
            Console.WriteLine("Torque I: {0}", openFFBoard.TMC.GetTorquei());
            Console.WriteLine("Flux P: {0}", openFFBoard.TMC.GetFluxp());
            Console.WriteLine("Flux I: {0}", openFFBoard.TMC.GetFluxi());
            Console.WriteLine("Velocity P: {0}", openFFBoard.TMC.GetVelocityp());
            Console.WriteLine("Velocity I: {0}", openFFBoard.TMC.GetVelocityi());
            Console.WriteLine("Pos P: {0}", openFFBoard.TMC.GetPosp());
            Console.WriteLine("Pos I: {0}", openFFBoard.TMC.GetPosi());
            Console.WriteLine("TMC Type: {0}", openFFBoard.TMC.GetTmctype());
            Console.WriteLine("PID precision: {0}", openFFBoard.TMC.GetPidprec());
            try
            {
                Console.WriteLine("PhiE Source: {0}", openFFBoard.TMC.GetPhiesrc());
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("PhiE Source: Board is not in debug mode");
            }
            Console.WriteLine("Offset flux scale: {0}", openFFBoard.TMC.GetFluxoffset());
            Console.WriteLine("Sequential PI: {0}", openFFBoard.TMC.GetSeqpi());
            Console.WriteLine("Counts per A: {0}", openFFBoard.TMC.GetIscale());
            try
            {
                Console.WriteLine("Encoder Direction: {0}", openFFBoard.TMC.GetEncdir());
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Encoder Direction: Board is not in debug mode");
            }
            Console.WriteLine("Encoder polarity: {0}", openFFBoard.TMC.GetAbnpol());
            Console.WriteLine("TMC Temperature: {0}", openFFBoard.TMC.GetTemp());
            try
            {
                Console.WriteLine("TMC Register: {0}", openFFBoard.TMC.GetReg(0));
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("TMC Register: Board is not in debug mode");
            }
            //Console.WriteLine("Space-vector PWM: {0}", openFFBoard.TMC.GetSvpwm());
            //Console.WriteLine("Auto home: {0}", openFFBoard.TMC.GetAutohome());
            //Console.WriteLine("ABN Index: {0}", openFFBoard.TMC.GetAbnindex());
            Console.WriteLine("Perform Calibration: {0}", openFFBoard.TMC.GetCalibrate());
            Console.WriteLine("Calibrated: {0}", openFFBoard.TMC.GetCalibrated());
            Console.WriteLine("State: {0}", openFFBoard.TMC.GetState());
            Console.WriteLine("Combine encoder: {0}", openFFBoard.TMC.GetCombineencoder());
            Console.WriteLine("Invert forces: {0}", openFFBoard.TMC.GetInvertforce());
            Console.WriteLine("VM (mV): {0}", openFFBoard.TMC.GetVm());
            #endregion

            Console.ReadKey();
            
        }

    }
}
