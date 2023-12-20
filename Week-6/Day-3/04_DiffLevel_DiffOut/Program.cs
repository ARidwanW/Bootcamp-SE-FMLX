using System;
using log4net;
using log4net.Config;

namespace Log4NetExample
{
    class Program
    {
        // Create an instance of the logger
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            // Configure log4net using the App.config file
            XmlConfigurator.Configure(new FileInfo("App.config"));

            // Log a message when the program starts
            log.Info("Program started.");

            // Log a message before performing an operation
            log.Debug("Performing a calculation...");

            int x = 5;
            int y = 10;
            int result = x * y;

            // Log the result of the operation
            log.Debug($"The result of the calculation is: {result}");

            // Log a message when the program ends
            log.Info("Program finished.");
        }
    }
}