namespace MarvelSnapProject.Component.Player;

public interface IPlayer
{
    /// <summary>
    /// Readonly property Id of player
    /// </summary>
    /// <value>int</value>
    public int Id { get; }

    /// <summary>
    /// Readonly property Name of player
    /// </summary>
    /// <value>string</value>
    public string Name { get; }
}
