using System.IO.IsolatedStorage;
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
    /// Readonly Property OnGoing ability of Location
    /// </summary>
    /// <value>bool</value>
    public bool _isOnReveal { get; private set; }

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
    public AbstractLocation(int id, string name, string description, LocationAbility ability, LocationStatus locationStatus = LocationStatus.Hidden, bool isOnGoing = false, bool isOnReveal = false)
    {
        Id = id;
        Name = name;
        Description = description;
        LocationAbility = ability;
        _locationStatus = locationStatus;
        _isOnGoing = isOnGoing;
        _isOnReveal = isOnReveal;
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
}
