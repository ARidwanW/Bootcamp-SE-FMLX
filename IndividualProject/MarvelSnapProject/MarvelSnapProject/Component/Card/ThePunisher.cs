using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class ThePunisher : AbstractCard
{
    public ThePunisher() : base(14, "The Punisher", "On Going: +1 Power for each opposing card at this location.", 
                                3, 2, CardAbility.OnGoing, CardStatus.None, true, false)
    {
    }

    public override AbstractCard Clone()
    {
        return new ThePunisher();
    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        return true;
    }

    public override bool SpecialAbilityOnReveal(GameController game)
    {
        return false;
    }
}
