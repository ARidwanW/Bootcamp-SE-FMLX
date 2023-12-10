using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public class Ruins : AbstractLocation
{
    public Ruins() : base(9, "Ruins", "", LocationAbility.Ruins, LocationStatus.Hidden, false, false)
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
