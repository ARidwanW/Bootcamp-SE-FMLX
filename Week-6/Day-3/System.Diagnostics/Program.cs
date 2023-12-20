using System.Diagnostics;

namespace SystemDiagnostics
{
    public class Program
    {
        static void Main()
        {
            string logPath = "./mylog.log";
            //Trace.Listeners.Add(new ConsoleTraceListener());
            //Trace.AutoFlush = true;

            Trace.WriteLine("Starting robot arm program");

            int i = 0;
            RobotArm arm = new RobotArm();
            while (i < 1)
            {
                arm.Connect();
                arm.MoveTo(0, 0, 0);
                arm.Grab();
                arm.MoveTo(10, 10, 10);
                arm.Release();
                arm.Disconnect();
                i++;
            }

            Trace.WriteLine("Robot arm program finished");

            Trace.Close();
        }
    }
}