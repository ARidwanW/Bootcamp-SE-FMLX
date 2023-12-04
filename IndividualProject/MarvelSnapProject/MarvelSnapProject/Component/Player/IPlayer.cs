namespace MarvelSnapProject.Component.Player;

public interface IPlayer
{
    /// <summary>
    /// Readonly property Id of player.
    /// </summary>
    /// <returns>int Id of player</return>
    public int Id { get; }

    /// <summary>
    /// Readonly property Name of player
    /// </summary>
    /// <returns>string Name of player</returns>
    public string Name { get; }
}
