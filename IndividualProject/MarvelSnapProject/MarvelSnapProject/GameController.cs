using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;
using NLog;
using NLog.Config;

namespace MarvelSnapProject;

public class GameController
{
    private readonly Logger? _logger;
    private GameStatus _gameStatus;
    private int _round;
    private Dictionary<IPlayer, PlayerInfo>? _players;
    private List<AbstractLocation>? _locations;
    private List<AbstractCard>? _allCards;
    private IPlayer _currentTurn;
    private IPlayer? _winner;
    public Action<AbstractCard, CardStatus>? OnCardStatusUpdate;
    public Action<AbstractLocation, LocationStatus>? OnLocationStatusUpdate;
    public Action<AbstractLocation>? OnLocationUpdate;
    public Action<IPlayer, PlayerStatus>? OnPlayerStatusUpdate;
    public Action<IPlayer, PlayerInfo>? OnPlayerUpdate;
    public event Func<GameController, bool>? OnRevealCardAbilityCall;        // invoke every round, chek apakah ada sub, jika iya bakal di invoke dan chek apakah roundnya sudah selanjutnya
    public event Func<GameController, bool>? OnRevealLocationAbilityCall;
    public event Func<GameController, bool>? OnGoingCardAbilityCall;
    public event Func<GameController, bool>? OnGoingLocationAbilityCall;


    public GameController(Logger? log = null)
    {
        _logger = log;
        _gameStatus = GameStatus.None;
        _players = new Dictionary<IPlayer, PlayerInfo>();
        _locations = new List<AbstractLocation>();
        _allCards = new List<AbstractCard>();
        _round = 0;
    }

    public GameStatus GetCurrentGameStatus()
    {
        return _gameStatus;
    }

    public bool SetGameStatus(GameStatus status)
    {
        _gameStatus = status;
        return true;
    }

    public int GetCurrentRound()
    {
        return _round;
    }

    public bool NextRound()
    {
        _round += 1;
        return true;
    }

    public bool AssignPlayer(params IPlayer[] players)
    {
        int status = 0;
        foreach (IPlayer player in players)
        {
            if (_players.ContainsKey(player))
            {
                status++;
                continue;
            }
            _players.Add(player, new PlayerInfo());
        }
        return (status > 0) ? false : true;
    }

    public bool RemovePlayer(params IPlayer[] players)
    {
        return true;
    }

    public List<IPlayer> GetAllPlayers()
    {
        List<IPlayer> players = _players.Keys.ToList();
        return players;
    }

    public List<AbstractCard> GetPlayerDeck(IPlayer player)
    {
        return _players[player].GetDeck();
    }

    public List<AbstractCard> GetPlayerHand(IPlayer player)
    {
        return _players[player].GetHandCards();
    }

    public List<AbstractLocation> GetAllLocations()
    {
        return _locations;
    }

    public AbstractLocation GetLocation(AbstractLocation location)
    {
        return _locations.Find(loc => loc == location);
    }

    public bool AssignLocation(params AbstractLocation[] locations)
    {
        foreach (var location in locations)
        {
            if (!_locations.Contains(location))
            {
                _locations.Add(location);
            }
        }
        return true;
    }

    public List<AbstractCard> GetAllCards()
    {
        return _allCards;
    }

    public bool AssignCardToPlayerDeck(IPlayer player, params AbstractCard[] cards)
    {
        bool status = false;
        if (!_players.ContainsKey(player))
        {
            return false;
        }

        foreach (var card in cards)
        {
            // var cloneCard = card.Clone();
            status = _players[player].AssignCardToDeck(card.Clone());
            // status = _players[player].AssignCardToDeck(card);
            if (status)
            {
                _players[player].GetDeck().Find(c => c.Name == card.Name).SetCardStatus(CardStatus.OnDeck);
                // _players[player].GetDeck().Find(card => card == card).SetCardStatus(CardStatus.OnDeck);
            }   
        }

        return status;
    }

    public bool AssignCardToPlayerHand(IPlayer player, params AbstractCard[] cards)
    {
        // int status = 0;
        bool status = false;
        if (!_players.ContainsKey(player))
        {
            return false;
        }

        foreach (var card in cards)
        {
            //* player hand can have same card
            // var cloneCard = card.Clone();
            // if(_players[player].GetHandCards().Contains(card))
            // {
            //     status++;
            //     continue;
            // }
            var cardInDeck = _players[player].GetDeck().Find(c => c.Name == card.Name);
            status = _players[player].AssignCardToHand(cardInDeck);
            // status = _players[player].AssignCardToHand(card);
            if (status)
            {
                _players[player].GetHandCards().Find(c => c.Name == card.Name).SetCardStatus(CardStatus.OnHand);
                // _players[player].GetHandCards().Find(card => card == card).SetCardStatus(CardStatus.OnHand);
            }

        }

        // return (status > 0) ? false : true;
        return status;
    }



    public IPlayer GetCurrentTurn()
    {
        return _currentTurn;
    }

    public bool SetTurn(IPlayer player)
    {
        _currentTurn = player;
        return true;
    }

    public IPlayer GetWinner()
    {
        return _winner;
    }






}
