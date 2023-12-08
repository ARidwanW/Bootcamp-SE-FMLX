using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;
using NLog;

namespace MarvelSnapProject;

public class GameController
{
    private readonly Logger? _logger;
    private GameStatus _gameStatus;
    private int _round;
    private Dictionary<IPlayer, PlayerInfo>? _players;
    private List<AbstractLocation>? _locations;
    private List<AbstractCard>? _allCards;
    private IPlayer? _winner;
    private Action<AbstractCard, CardStatus>? OnCardStatusUpdate;
    private Action<AbstractLocation, LocationStatus>? OnLocationStatusUpdate;
    private Action<AbstractLocation>? OnLocationUpdate;
    private Action<IPlayer, PlayerStatus>? OnPlayerStatusUpdate;
    private Action<IPlayer, PlayerInfo>? OnPlayerUpdate;
    private Action<GameController, IPlayer, AbstractLocation>? OnRevealCardAbilityCall;        // invoke every round, chek apakah ada sub, jika iya bakal di invoke dan chek apakah roundnya sudah selanjutnya
    private Action<GameController>? OnRevealLocationAbilityCall;
    private Action<GameController, IPlayer, AbstractLocation>? OnGoingCardAbilityCall;
    private Action<GameController>? OnGoingLocationAbilityCall;


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

    public int CheckCurrentRound()
    {
        return _round;
    }

    public bool NextRound()
    {
        _round += 1;
        return true;
    }

    public bool AssignPlayer(params IPlayer[] player)
    {
        return true;
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

    public List<AbstractLocation> GetAllLocations()
    {
        return _locations;
    }

    public List<AbstractCard> GetAllCards()
    {
        return _allCards;
    }

    public IPlayer GetWinner()
    {
        return _winner;
    }






}
