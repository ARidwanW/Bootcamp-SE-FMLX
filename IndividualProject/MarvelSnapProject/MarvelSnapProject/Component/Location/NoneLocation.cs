using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public class NoneLocation : AbstractLocation
{
    public NoneLocation() : base(0, "NONE", "None", LocationAbility.None, LocationStatus.Hidden, false, false, false)
    {
    }


    public override bool SpecialAbilityOnGoing(GameController game)
    {
        throw new NotImplementedException();
    }

    public override bool SpecialAbilityOnReveal(GameController game)
    {
        throw new NotImplementedException();
    }

}
