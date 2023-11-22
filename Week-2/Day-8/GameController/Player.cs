namespace GameControllerLib;

// * class player implement Interface IPlayer
public class Player : IPlayer
{
    // * pada IPlayer ada get id dan get name
    public int Id { get; }
    public string Name { get; }

    // * mari kita inisialisasi playernya
    public Player(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
