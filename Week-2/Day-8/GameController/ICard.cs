namespace GameControllerLib;

public interface ICard
{
    // * get id card, sideA, sideB, and Status
    public int Id { get; }
    public int SideA { get; }
    public int SideB {get;}
    public CardStatus cardStatus {get; set;}
}
