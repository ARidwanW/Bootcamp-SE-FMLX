using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class MisterFantastic : AbstractCard
{
    public MisterFantastic() : base(8, "Mister Fantastic", "On Going: Adjacent locations have +2 Power.", 
                                    3, 2, CardAbility.OnGoing, CardStatus.None, true, false)
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
