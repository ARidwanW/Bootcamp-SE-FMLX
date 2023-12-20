using System.Diagnostics;

namespace Debugging
{
    public class Program
    {
        static void Main()
        {
            string logPath = "myDebuglog.log";
            Trace.Listeners.Add(new TextWriterTraceListener(logPath));
            Trace.AutoFlush = true;
            Trace.Listeners.Remove("Default"); // remove default listener

            Trace.WriteLine("Starting robot arm program");

            int i = 0;
            RobotArm arm = new RobotArm();
            while (i < 10000)
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