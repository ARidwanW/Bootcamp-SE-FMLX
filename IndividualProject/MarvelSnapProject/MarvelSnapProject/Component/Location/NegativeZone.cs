using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public class NegativeZone : AbstractLocation
{
    public NegativeZone() : base(8, "Negative Zone", "Cards here have -3 Power.", LocationAbility.NegativeZone, LocationStatus.Hidden, true, false)
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
