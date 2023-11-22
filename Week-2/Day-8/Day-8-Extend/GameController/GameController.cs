namespace GameControllerLib;


public class GameController
{
	public delegate void ListenerPost(IPlayer card, int post);
	private Dictionary<IPlayer, HashSet<ICard>> _players;
	private HashSet<ICard> _deckCards;
	// * using Action -> delegate void with parameter
	// * public delegate void Action<T1,T2>(T1 args1, T2 args2)
	public event Action<ICard,CardStatus>  onCardUpdate;
	
	// * There is another one called Func
	// * Func is delegate with return type and can use parameter
	// * public delegate TResult Func<T1,T2,TResult>(T1 args1, T2 args2)
	public event ListenerPost onChangePosition;
	public GameController(IPlayer player1, IPlayer player2) 
	{
		_players = new();
		_deckCards = new();
		_players.Add(player1, new HashSet<ICard>());
		_players.Add(player2, new HashSet<ICard>());
	}
	public GameController(IPlayer player1, IPlayer player2, 
						params ICard[] cards) 
	{
		_players = new();
		_deckCards = new();
		_players.Add(player1, new HashSet<ICard>());
		_players.Add(player2, new HashSet<ICard>());
		foreach (var i in cards)
		{
			_deckCards.Add(i);
		}
	}
	public bool AddCard(IPlayer player, params ICard[] cards) 
	{
		if(!_players.ContainsKey(player)) 
		{
			return false;
		}
		foreach(var i in cards) 
		{
			_players[player].Add(i);
			ChangeCardStatus(i, CardStatus.OnPlayer);
		}
		return true;
	}
	private void ChangeCardStatus(ICard card, CardStatus status) 
	{
		card.cardStatus = status;
		onCardUpdate?.Invoke(card, status);
	}
}
