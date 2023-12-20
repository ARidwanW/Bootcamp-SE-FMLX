using log4net;
using log4net.Config;

namespace RobotArms;
public class Program
{
	private static readonly ILog log = LogManager.GetLogger(typeof(Program));

	static void Main()
	{
		XmlConfigurator.Configure(new FileInfo("log4net.config"));

		log.Info("Starting robot arm program");
		int i = 0;
		RobotArm arm = new RobotArm();
		while (i < 100000000)
		{
			arm.Connect();
			arm.MoveTo(0, 0, 0);
			arm.Grab();
			arm.MoveTo(10, 10, 10);
			arm.Release();
			arm.Disconnect();
            i++;
        }
		log.Info("Robot arm program finished");
	}
}