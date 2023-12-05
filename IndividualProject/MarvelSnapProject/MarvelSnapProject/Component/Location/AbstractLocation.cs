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
    private LocationStatus _locationStatus;

    public AbstractLocation(int id, string name, string description, LocationAbility ability, LocationStatus status = LocationStatus.Hidden)
    {
        Id = id;
        Name = name;
        Description = description;
        LocationAbility = ability;
        _locationStatus = status;
    }

    public abstract bool DoAbility(GameController game);
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
