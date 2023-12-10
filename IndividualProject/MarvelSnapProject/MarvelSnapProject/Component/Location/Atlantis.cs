using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public class Atlantis : AbstractLocation
{
    public Atlantis() : base(2, "Atlantis", "If you only have one card here, it has +5 Power.", LocationAbility.Atlantis, LocationStatus.Hidden, true, true)
    {
    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        return true;
    }

    public override bool SpecialAbilityOnReveal(GameController game)
    {
        return true;
    }
}
