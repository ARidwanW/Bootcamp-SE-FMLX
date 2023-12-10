using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public class AvengersCompound : AbstractLocation
{
    public AvengersCompound() : base(4, "Avengers Compound", "On turn 5, all cards must be played here.", LocationAbility.AvengersCompound, LocationStatus.Hidden, true, false)
    {
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
