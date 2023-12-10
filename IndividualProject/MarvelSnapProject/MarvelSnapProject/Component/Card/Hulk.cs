using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class Hulk : AbstractCard
{
    public Hulk() : base(4, "Hulk", "HULK SMASH!", 
                        6, 12, CardAbility.None, CardStatus.None, false, false)
    {
    }

    public override AbstractCard Clone()
    {
        return new Hulk();
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
