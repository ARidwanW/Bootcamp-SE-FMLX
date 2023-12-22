using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using NLog.Extensions.Logging;

namespace _08_ExampleInGameController;

partial class Program
{
    static void ManualCreation()
    {
        IPlayer player = new Player("player1");
        IBoard board = new Board(2);
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.ClearProviders();
            builder.SetMinimumLevel(LogLevel.Trace);
            builder.AddNLog("nlog.config");
        });
        ILogger<GameController> logger = loggerFactory.CreateLogger<GameController>();
        GameController game = new GameController(player, board, logger);
    }
}
