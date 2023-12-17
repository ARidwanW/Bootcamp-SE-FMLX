namespace MarvelSnapProject.Component.Player;

public class MSPlayer : IPlayer
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    /// <summary>
    /// Class MSPlayer implement IPlayer
    /// </summary>
    /// <param name="id">Assign Id of player</param>
    /// <param name="name">Assign Name of player</param>
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
