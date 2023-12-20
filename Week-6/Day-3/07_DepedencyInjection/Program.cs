
class Program
{
    static void Main()
    {
        
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
}

interface IBoard
{
    int x { get; }
    int y { get; }
}

class Board : IBoard
{
    public int x {get; private set;}

    public int y {get; private set;}

    public Board()
    {
        x = 5;
        y = 6;
    }

    public void SetX(int x)
    {
        this.x = x;
    }

    public void SetY(int y)
    {
        this.y = y;
    }
}