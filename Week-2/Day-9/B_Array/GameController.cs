namespace B_Array;

public class GameController
{
	Player[] players;
	int count = 0;
	public GameController() 
	{
		players = new Player[4];
	}
	public bool AddPlayer(Player p) 
	{
		//... check if player already added before
		players[count] = p;
		count++;
		return true;
	}
	public Player GetPlayer(int index) 
	{
		return players[index];
	}
}
