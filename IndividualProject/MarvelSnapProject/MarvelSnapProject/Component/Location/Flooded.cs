using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public class Flooded : AbstractLocation
{
    public Flooded() : base(6, "Flooded", "Cards can't be played here.", LocationAbility.Flooded, LocationStatus.Hidden, false, false, false)
    {
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
