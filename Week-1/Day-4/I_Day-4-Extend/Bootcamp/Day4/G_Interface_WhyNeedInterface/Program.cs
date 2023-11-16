//Interface on GameController
class Program {
	static void Main() {
		Player player = new Player();
		MLPlayer mlplayer = new MLPlayer();
		PBPlayer pbplayer = new PBPlayer();
		GameController game = new GameController(pbplayer);
	}
}

class GameController {
	public IPlayer player;
	public GameController(IPlayer p) {
		player = p;
	}
}
public interface IPlayer
{
	string GetName();
	int GetId();
}
class Player : IPlayer {
	private int _id;
	private string _name;

	public int GetId()
	{
		return _id;
	}
	public string GetName()
	{
		return _name;
	}
}
class MLPlayer : IPlayer {
	private int _id;
	private string _name;
	private string _username;
	private int _level;
	
	public bool ConnectToServer() {
		return true;
	}
	public int GetId()
	{
		return _id;
	}
	public string GetName()
	{
		return _name;
	}
}
class CODPlayer : IPlayer
{
	private int _id;
	private string _name;
	private string _username;
	private int _level;

	public bool ConnectToServer()
	{
		return true;
	}
	public int GetId()
	{
		return _id;
	}
	public string GetName()
	{
		return _name;
	}
}
class PBPlayer : IPlayer
{
	private int _id;
	private string _name;
	private string _username;
	private int _level;

	public bool ConnectToServer()
	{
		return true;
	}
	public int GetId()
	{
		return _id;
	}
	public string GetName()
	{
		return _name;
	}
}