namespace B_Array;

public class Player
{
	public string Name { get; }
	public int Id { get; }
	public Player(int id, string name) 
	{
		Name = name;
		Id = id;
	}
}