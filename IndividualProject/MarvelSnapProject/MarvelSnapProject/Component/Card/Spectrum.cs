using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class Spectrum : AbstractCard
{
    public Spectrum() : base(12, "Spectrum", "On Reveal: Give your Ongoing cards +2 Power.", 
                            6, 7, CardAbility.OnReveal, CardStatus.None, false, true)
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
