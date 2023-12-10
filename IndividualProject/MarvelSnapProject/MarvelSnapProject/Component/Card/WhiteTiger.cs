using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class WhiteTiger : AbstractCard
{
    public WhiteTiger() : base(16, "White Tiger", "On Reveal: Add a 8-Power Tiger to another location", 
                                5, 1, CardAbility.OnReveal, CardStatus.None, false, true)
    {
    }

    public override AbstractCard Clone()
    {
        return new WhiteTiger();
    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        return false;
    }

    public override bool SpecialAbilityOnReveal(GameController game)
    {
        return true;
    }
}
