using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class IronMan : AbstractCard
{
    public IronMan() : base(1, "Iron Man", "Manusia Logam", 5, 0, CardAbility.OnGoing, true, false)
    {
    }

    public override bool SpecialAbilityOnGoing(GameController game, IPlayer player, AbstractLocation location)
    {
        throw new NotImplementedException();
    }

    public override bool SpecialAbilityOnReveal(GameController game, IPlayer player, AbstractLocation location)
    {
        return false;
    }
}
