using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public class KunLun : AbstractLocation
{
    public KunLun() : base(7, "K'un-Lun", "When a card moves here, give it +2 Power.", LocationAbility.KunLun, LocationStatus.Hidden, true, false)
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
