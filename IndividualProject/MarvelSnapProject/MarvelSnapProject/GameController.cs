using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;
using NLog;

namespace MarvelSnapProject;

public class GameController
{
    private readonly Logger _logger;
    private GameStatus _gameStatus;
    private int _round;
    private Dictionary<IPlayer, PlayerInfo> _players;
    private Dictionary<AbstractLocation, LocationInfo> _locations;
    private List<AbstractLocation> _allLocations;
    private List<AbstractCard> _allCards;
    private IPlayer _winner;
    private Action<AbstractCard, CardStatus> onCardStatusUpdate;
    private Action<AbstractLocation, LocationInfo> onLocationUpdate;
    private Action<IPlayer, PlayerInfo> onPlayerUpdate;


    public GameController(Logger log)
    {
        _logger = log;
        _gameStatus = GameStatus.None;
        _round = 0;
    }

    public bool AddPlayer(IPlayer player)
    {
        return true;
    }

    


}
