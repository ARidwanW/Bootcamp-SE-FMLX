using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class MistyKnight : AbstractCard
{
    public MistyKnight() : base(9, "Misty Knight", "We've got to save this city.", 
                                1, 2, CardAbility.None, CardStatus.None, false, false)
    {
    }

    public override AbstractCard Clone()
    {
        return new MistyKnight();
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
