namespace MarvelSnapProject.Component.Location;

public interface ILocation
{
    /// <summary>
    /// Readonly property Id of location
    /// </summary>
    /// <value>int</value>
    public int Id { get; }

    /// <summary>
    /// Readonly property Name of location
    /// </summary>
    /// <value>string</value>
    public string Name { get; }

    /// <summary>
    /// Readonly property Description of location
    /// </summary>
    /// <value>string</value>
    public string Description { get; }
}
