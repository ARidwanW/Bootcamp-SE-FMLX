using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public class Asgard : AbstractLocation
{

    public Asgard() : base(1, "Asgard", "After turn 4, whoever is winning here draws 2.", LocationAbility.Asgard, LocationStatus.Hidden, false, true)
    {
        
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
