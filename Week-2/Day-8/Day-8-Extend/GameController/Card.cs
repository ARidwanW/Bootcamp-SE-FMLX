namespace GameControllerLib;

public class Card : ICard
{
	public int Id { get; private set; }

	public int SideA  { get; private set; }

	public int SideB  { get; private set; }

	public CardStatus cardStatus  { get; set; }
	public override int GetHashCode()
	{
		return Id;
	}
	public Card(int id, int sideA, int sideB) 
	{
		Id = id;
		SideA = sideA;
		SideB = sideB;
		cardStatus = CardStatus.OnDeck;
	}

}
