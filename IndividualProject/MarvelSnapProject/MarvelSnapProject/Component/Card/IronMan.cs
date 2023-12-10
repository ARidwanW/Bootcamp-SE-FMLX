using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class IronMan : AbstractCard
{
    public IronMan() : base(5, "Iron Man", "On Going: Your total Power is doubled at this location.", 
                            5, 0, CardAbility.OnGoing, CardStatus.None, true, false)
    {
    }

    public override bool SpecialAbilityOnGoing(GameController game, IPlayer player, AbstractLocation location)
    {
        return true;
    }

    public override bool SpecialAbilityOnReveal(GameController game, IPlayer player, AbstractLocation location)
    {
        return false;
    }
}
