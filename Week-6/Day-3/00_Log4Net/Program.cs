using log4net;
using log4net.Config;

namespace LoggingExample
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            logger.Debug("This is a debug message");
            logger.Info("This is an info message");
            logger.Warn("This is a warning message");
            logger.Error("This is an error message");
            logger.Fatal("This is a fatal message");
            GameRunner.Message("This is GAMERUNNER");
        }

    }

    class GameRunner
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(GameRunner));
        public static void Message(string args)
        {
            logger.Info(args);
        }
    }
}