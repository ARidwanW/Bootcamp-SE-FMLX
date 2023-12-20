public class Logger
{
    private string logFilePath = "./log.txt";

    public void Log(string message)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine($"{DateTime.Now} - {message}");
        }
    }
}

public static class myProgram
{
    static void Main()
    {
        Logger logger = new Logger();
        logger.Log("Starting the program...");
        logger.Log("Program completed.");
    }
}