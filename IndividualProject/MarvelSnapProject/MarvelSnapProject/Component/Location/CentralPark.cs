using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public class CentralPark : AbstractLocation
{
    public CentralPark() : base(5, "Central Park", "Add a Squirrel to each location.", LocationAbility.CentralPark, LocationStatus.Hidden, true, false)
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
