class Piece
{
	public Piece() 
	{
		Console.WriteLine("Piece created");
	}
	~Piece()
	{
		Console.WriteLine("Piece destructor called.");
	}
}

class GameController
{
	Piece piece = new Piece();
	public GameController() 
	{
		Console.WriteLine("GameController created");
	}
	~GameController()
	{
		piece = null;
		Console.WriteLine("GameController destructor called.");
	}
}

class Program
{
	static void Main(string[] args)
	{
		InstanceCreator();
		GC.Collect(); // GC mark sweep
		// GC.Collect();
		//GC.WaitForPendingFinalizers(); //GC execute finalizer list
	}
	static void InstanceCreator() {
		GameController game = new GameController();
	}
}
