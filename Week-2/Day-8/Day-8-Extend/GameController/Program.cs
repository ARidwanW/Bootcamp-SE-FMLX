using GameControllerLib;
class Program 
{
	static void Main() 
	{
		UI ui = new();
		Database db = new();
		
		Player player1 = new(1001, "Kinara");
		Player player2 = new(1002, "Yusuf");
		GameController game = new(player1,player2);

		game.onCardUpdate += ui.CardUpdated;
		game.onCardUpdate += db.LogToDb;
		game.onCardUpdate += SMS.SendSms;
		
		Card card = new Card(11, 1, 3);
		Card card2 = new Card(12,3, 4);
		game.AddCard(player1, card, card2);
	}
}
