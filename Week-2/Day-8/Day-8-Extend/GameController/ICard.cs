namespace GameControllerLib;

public interface ICard
{
	public int Id { get; }
	public int SideA { get; }
	public int SideB { get; }
	public CardStatus cardStatus { get; set; }
}
