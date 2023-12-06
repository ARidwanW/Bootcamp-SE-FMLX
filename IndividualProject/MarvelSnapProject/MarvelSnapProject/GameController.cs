using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;
using NLog;

namespace MarvelSnapProject;

public class GameController
{
    private static readonly Logger logger;
    private GameStatus _gameStatus;
    private int _round;
    private Dictionary<IPlayer, PlayerInfo> _players;
    private Dictionary<AbstractLocation, LocationInfo> _locations;
    private List<AbstractLocation> _allLocations;
    private List<AbstractCard> _allCards;


}
