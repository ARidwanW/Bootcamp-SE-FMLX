using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace _08_ExampleInGameController;

partial class Program
{
    IPlayer player = new Player("player1");
    IBoard Board = new Board(2);
    VariantType loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.ClearProviders();
        builder.SetMinimumLevel(LogLevel.Trace);
        builder.AddNLog("nlog.config");
    });
    ILogger<GameController> logger = loggerFactory.CreateLogger<GameController>();
    GameController game = new GameController(player, board, logger);
}
