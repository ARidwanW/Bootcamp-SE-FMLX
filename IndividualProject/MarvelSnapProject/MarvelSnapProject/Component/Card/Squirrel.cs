using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class Squirrel : AbstractCard
{
    public Squirrel() : base(17, "Squirrel", "squeak!", 1, 1, CardAbility.None, CardStatus.None, false, false)
    {
    }

    public override AbstractCard Clone()
    {
        return new Squirrel();
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
