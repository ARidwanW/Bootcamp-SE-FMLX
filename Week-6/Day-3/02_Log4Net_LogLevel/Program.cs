using System;
using log4net;
using log4net.Config;

namespace LoggingLevelsExample
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));

            // Log a DEBUG message
            log.Debug("This is a DEBUG message.");

            // Log an INFO message
            log.Info("This is an INFO message.");

            // Log a WARN message
            log.Warn("This is a WARN message.");

            // Log an ERROR message
            log.Error("This is an ERROR message.");

            // Log a FATAL message
            log.Fatal("This is a FATAL message.");
        }
    }
}