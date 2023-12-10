using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class Sentinel : AbstractCard
{
    public Sentinel() : base(11, "Sentinel", "On Reveal: Add another Sentinel to your hand.", 
                            2, 3, CardAbility.OnReveal, CardStatus.None, false, true)
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
