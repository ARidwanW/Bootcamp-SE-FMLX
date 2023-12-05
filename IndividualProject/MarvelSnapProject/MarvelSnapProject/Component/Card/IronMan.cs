using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Component.Location;

namespace MarvelSnapProject.Component.Card;

public class IronMan : AbstractCard
{
    public IronMan() : base(1, "Iron Man", "Manusia Logam", 5, 0, Enum.CardTimeAbility.OnGoing, Enum.CardAbility.OnGoing)
    {
        
    }
    public override bool DoAbility(GameController game, IPlayer player, AbstractLocation location)
    {
        return true;
    }
}
