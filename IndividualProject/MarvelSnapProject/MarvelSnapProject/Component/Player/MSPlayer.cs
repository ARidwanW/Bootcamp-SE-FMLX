namespace MarvelSnapProject.Component.Player;

public class MSPlayer : IPlayer
{
    /// <summary>
/// Gets the unique identifier of the player.
/// </summary>
    public int Id { get; private set; }

    /// <summary>
/// Gets the name of the player.
/// </summary>
    public string Name { get; private set; }

    /// <summary>
/// Initializes a new instance of the MSPlayer class.
/// </summary>
/// <param name="id">The unique identifier to assign to the player.</param>
/// <param name="name">The name to assign to the player.</param>
    public MSPlayer(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is MSPlayer player)
        {
            return Id == player.Id;
        }
        return false;
    }
}
