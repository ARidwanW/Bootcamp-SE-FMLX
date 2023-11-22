class Program {
	static void Main() {
		if(foo.Contain(p) 
		{
			foo.AddCard(p, card);
		}
	}
}
class FooBar {
	private Dictionary<IPlayer, HashSet<ICard>> _players;
	
	public bool Contain(IPlayer p) {
		return _players.ContainsKey(p);
	}
	public bool AddCard(IPlayer p, ICard card) {
		if (!_players.ContainsKey(p)) {
			throw new InvalidDataException("No player was found");
		}
	}
}
public interface IPlayer { }
public interface ICard { }