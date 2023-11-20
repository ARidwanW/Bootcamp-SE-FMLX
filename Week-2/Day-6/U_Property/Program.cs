//Properties
class GameController {
	//1 public readonly
	public readonly int totalPlayer;
	//2 private variable with Get and Set method
	private int _totalPlayer;
	public int GetTotalPlayer(){
		return _totalPlayer;
	}
	public bool SetTotalPlayer(int total) {
		if(total > 0) {
			_totalPlayer = total;
			return true;
		}
		return false;
	}
	//3 General Properties
	public int MyProperties {get; private set;}
	//4 Custom Properties
	private int _totalPlayer2;
	public int TotalPlayer
	{
		get
		{
			return _totalPlayer2 * 20;
		}
		set 
		{
			if (value > 0) {
				_totalPlayer2 = value;
			}
		}
	}
	public int TotalPlayer2 {get;}
}


class Program {
	static void Main() {
		GameController game = new();
		game.TotalPlayer2.Dump();
		game.TotalPlayer = 200;
		game.TotalPlayer.Dump();
	}
}