using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class JessicaJones : AbstractCard
{
    public JessicaJones() : base(6, "Jessica Jones", "On Reveal: if you don't play a card at this location next turn, +4 Power.", 
                                4, 5, CardAbility.OnReveal, CardStatus.None, false, true)
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
