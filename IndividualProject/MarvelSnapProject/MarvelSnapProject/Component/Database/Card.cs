using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Database;

public class Card
{
    public int CardId { get; set; }
    public string CardName { get; set; }
    public string Description { get; set; }
    public CardAbility Ability { get; set; }
    public bool IsOnGoing { get; set; }
    public bool IsOnReveal { get; set; }
}
