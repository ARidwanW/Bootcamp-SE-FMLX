using B_Array;

class Program 
{
	static void Main() 
	{
		int[] myArray = new int[10];
		int[] myArray2 = { 1, 2, 3, 4 };

		myArray[0] = 10;
		myArray[1] = 11;

		int sizeOfArray = myArray.Length;

		GameController game = new();
		Player player1 = new(1, "Kinara");
		Player player2 = new(2, "Yusuf");

		game.AddPlayer(player1);
		game.AddPlayer(player2);

		Player playerfirst = game.GetPlayer(0);
		Console.WriteLine(playerfirst.Name);
		Console.WriteLine(game.GetPlayer(0).Name);
	}
}
