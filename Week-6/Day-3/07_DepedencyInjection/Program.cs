//* add package Microsoft.Extensions.DependencyInjection
//* add package Microsoft.Extensions.Logging
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        //* di setting sebelum runtime
        //* data diambil dari semisal json file / config file
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IBoard>(board => new Board(2, 3));
        serviceCollection.AddTransient<GameController>();

        IServiceProvider services = serviceCollection.BuildServiceProvider();

        // Board board = new Board();
        GameController game = services.GetRequiredService<GameController>();
        Console.WriteLine(game.GetBoard());
        Console.WriteLine(game.GetSizeX());
        Console.WriteLine(game.GetSizeY());
    }
}

class GameController
{
    private IBoard _board;

    public GameController(IBoard board)
    {
        _board = board;
    }

    public IBoard GetBoard()
    {
        return _board;
    }

    public int GetSizeX()
    {
        return _board.X;
    }
    public int GetSizeY()
    {
        return _board.Y;
    }
}

interface IBoard
{
    int X { get; }
    int Y { get; }
}

class Board : IBoard
{
    public int X {get; private set;}

    public int Y {get; private set;}

    public Board(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void SetX(int x)
    {
        this.X = x;
    }

    public void SetY(int y)
    {
        this.Y = y;
    }
}