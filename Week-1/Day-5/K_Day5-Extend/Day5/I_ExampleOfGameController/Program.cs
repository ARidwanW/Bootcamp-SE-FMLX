//GameController
class Program {
	static void Main() {
		
	}
}
public interface IPlayer {
	string GetName();
	int GetId();
	string GetPlayerType();
}
public class OnlinePlayer : IPlayer
{
	private int _id;
	private string _name;
	public OnlinePlayer(int id, string name)
	{
		_id = id;
		_name = name;
	}
	public int GetId()
	{
		return _id;
	}

	public string GetName()
	{
		return _name;
	}
	public string GetPlayerType()
	{
		return "online";
	}
	public string GetOnlineId() {
		return "yusuf123";
	}
}
public class OfflinePlayer : IPlayer
{
	private int _id;
	private string _name;
	public OfflinePlayer(int id, string name) {
		_id = id;
		_name = name;
	}
	public int GetId()
	{
		return _id;
	}
	public string GetPlayerType() {
		return "offline";
	}
	public string GetName()
	{
		return _name;
	}
}
class GameController {
	public IPlayer player;
	public GameController(IPlayer p) {
		player = p;
	}
	public void PlayerChecker() {
		if(player.GetPlayerType() == "online") {
			OnlinePlayer online = (OnlinePlayer) player;
			online.GetOnlineId();
		}
		if(player.GetPlayerType() == "offline") {
			
		}
	}
}

