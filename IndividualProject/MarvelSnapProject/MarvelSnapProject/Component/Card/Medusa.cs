using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class Medusa : AbstractCard
{
    public Medusa() : base(7, "Medusa", "On Reveal: if this at the middle location, +3 Power.", 
                            2, 2, CardAbility.OnReveal, CardStatus.None, false, true)
    {
    }

    public override bool SpecialAbilityOnGoing(GameController game, IPlayer player, AbstractLocation location)
    {
        return false;
    }

    public override bool SpecialAbilityOnReveal(GameController game, IPlayer player, AbstractLocation location)
    {
        return true;
    }
}
