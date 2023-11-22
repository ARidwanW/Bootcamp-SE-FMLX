namespace GameControllerLib;

public class GameController
{
    // * UseCase: domino card
    // * We have player, players have cards
    private Dictionary<IPlayer, HashSet<ICard>> _players;
    
    // * We have cards in deck and must be unique
    private HashSet<ICard> _deckCards;

    // ! We need to update card status
    // * first lets using delegate
    /* public delegate void ListenerPost(IPlayer player, int post);
    public event ListenerPost onChangePosition; */

    // * second using Action
    public event Action<ICard, CardStatus> onCardUpdate;

    // * lets initialize the game
    public GameController(IPlayer player1, IPlayer player2)
    {
        // * we want just 2 players hehe
        // * lets create an player instance dictionary
        // * also the deck card
        _players = new();
        _deckCards = new();

        // * lets add the player and their hand (to collect the card hehe)
        _players.Add(player1, new HashSet<ICard>());
        _players.Add(player2, new HashSet<ICard>());
    }

    // ! wait i think i miss something
    // * i want to add cards on deck when game create
    // * we can overloading, coz maybe we want add cards later
    public GameController(IPlayer player1, IPlayer player2, params ICard[] cards)
    {
        // * we want just 2 players hehe
        // * lets create an player instance dictionary
        // * also the deck card
        _players = new();
        _deckCards = new();

        // * lets add the player and their hand (to collect the card hehe)
        _players.Add(player1, new HashSet<ICard>());
        _players.Add(player2, new HashSet<ICard>());

        // * lets put the cards on deck 1 by 1
        foreach (var card in cards)
        {
            _deckCards.Add(card);
        }
    }

    // ! wait a minute,
    // ?? how players get card
    // * lets add card to player
    // * and check if we add card to real player
    public bool AddCard(IPlayer player, params ICard[] cards)
    {
        // ! we must check the real player
        if (!_players.ContainsKey(player))
        {
            return false;
        }

        // * lets add the card to a player
        foreach (var card in cards)
        {
            _players[player].Add(card);
            // ! update card status to On Player
            ChangeCardStatus(card, CardStatus.OnPlayer);
        }
        return true;
    }

    // !Remember to update card status
    private void ChangeCardStatus(ICard card, CardStatus status)
    {
        card.cardStatus = status;
        // * if not null, tell listener about the update
        onCardUpdate?.Invoke(card, status);
    }

}
