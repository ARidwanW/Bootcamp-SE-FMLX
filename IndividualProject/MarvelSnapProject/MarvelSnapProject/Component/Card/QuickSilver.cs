using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class QuickSilver : AbstractCard
{
    public QuickSilver() : base(10, "Quick Silver", "Starts in your opening hand", 
                                1, 2, CardAbility.None, CardStatus.None, false, false)
    {
    }

    public override AbstractCard Clone()
    {
        return new QuickSilver();
    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        return false;
    }

    public override bool SpecialAbilityOnReveal(GameController game)
    {
        return false;
    }
}
