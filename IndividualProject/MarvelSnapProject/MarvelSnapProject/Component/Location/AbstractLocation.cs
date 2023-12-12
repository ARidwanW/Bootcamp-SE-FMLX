using System.IO.IsolatedStorage;
using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public abstract class AbstractLocation
{
    /// <summary>
    /// Readonly property Id of Location
    /// </summary>
    /// <value>int</value>
    public int Id { get; private set; }

    /// <summary>
    /// Readonly property Name of Location
    /// </summary>
    /// <value>string</value>
    public string Name { get; private set; }

    /// <summary>
    /// Readonly property Description of Location
    /// </summary>
    /// <value>string</value>
    public string Description { get; private set; }

    /// <summary>
    /// Readonly property Ability of Location
    /// </summary>
    /// <value>LocationAbility</value>
    public LocationAbility LocationAbility { get; private set; }

    /// <summary>
    /// Private variable Status of Location
    /// </summary>
    private LocationStatus _locationStatus;

    /// <summary>
    /// Readonly Property OnGoing ability of Location
    /// </summary>
    /// <value>bool</value>
    public bool _isOnGoing { get; private set; }

    /// <summary>
    /// Readonly Property OnReveal ability of Location
    /// </summary>
    /// <value>bool</value>
    public bool _isOnReveal { get; private set; }
    private bool _isValid;
    private List<AbstractCard> _allCards;
    private Dictionary<IPlayer, List<AbstractCard>> _playersCards;
    private Dictionary<IPlayer, int> _playersPower;

    /// <summary>
    /// Abstract Class of Location
    /// </summary>
    /// <param name="id">Id of Location</param>
    /// <param name="name">Name of Location</param>
    /// <param name="description">Description of Location</param>
    /// <param name="ability">Ability (or Name) of Location</param>
    /// <param name="locationStatus">Status (Hidden, Revealed) of Location</param>
    /// <param name="isOnGoing">Boolean: true if ability is OnGoing type</param>
    /// <param name="isOnReveal">Boolean: true if ability is OnReveal type</param>
    public AbstractLocation(int id, string name, string description, LocationAbility ability, LocationStatus locationStatus = LocationStatus.Hidden, bool isOnGoing = false, bool isOnReveal = false, bool isValid = true)
    {
        Id = id;
        Name = name;
        Description = description;
        LocationAbility = ability;
        _locationStatus = locationStatus;
        _isOnGoing = isOnGoing;
        _isOnReveal = isOnReveal;
        _isValid = isValid;
        _allCards = new List<AbstractCard>();
        _playersCards = new Dictionary<IPlayer, List<AbstractCard>>();
        _playersPower = new Dictionary<IPlayer, int>();
    }

    /// <summary>
    /// Abstract method for special ability on going
    /// </summary>
    /// <param name="game">GameController</param>
    /// <returns>true: if card successfully doing its ability on going</returns>
    public abstract bool SpecialAbilityOnGoing(GameController game);

    /// <summary>
    /// Abstract method for special ability on reveal
    /// </summary>
    /// <param name="game">GameController</param>
    /// <returns>true: if card successfully doing its ability on reveal</returns>
    public abstract bool SpecialAbilityOnReveal(GameController game);

    public LocationStatus GetLocationStatus()
    {
        return _locationStatus;
    }

    public bool SetLocationStatus(LocationStatus status)
    {
        _locationStatus = status;
        return true;
    }

    public bool IsLocationValid()
    {
        return _isValid;
    }

    public bool SetLocationValid(bool valid)
    {
        _isValid = valid;
        return true;
    }

     public List<AbstractCard> GetAllCards()
    {
        return _allCards;
    }

    public bool AssignCardToLocation(params AbstractCard[] cards)
    {
        foreach(var card in cards)
        {
            _allCards.Add(card);
        }
        return true;
    }

    public List<AbstractCard> GetPlayerCards(IPlayer player)
    {
        return _playersCards[player];
    }

    public Dictionary<IPlayer, List<AbstractCard>> GetAllPlayersCards()
    {
        return _playersCards;
    }

    public bool AssignPlayerCardToLocation(IPlayer player, AbstractCard card)
    {
        if (!_playersCards.ContainsKey(player))
        {
            _playersCards.Add(player, new List<AbstractCard> { card });
        }
        else
        {
            _playersCards[player].Add(card);
        }
        
        return AssignCardToLocation(card);;
    }

    public int GetPlayerPower(IPlayer player)
    {
        return _playersPower[player];
    }

    public Dictionary<IPlayer, int> GetAllPlayersPower()
    {
        return _playersPower;
    }

    public bool AssignPlayerPower(IPlayer player, int power)
    {
        bool status = _playersPower.TryAdd(player, power);
        return status;
    }
}
