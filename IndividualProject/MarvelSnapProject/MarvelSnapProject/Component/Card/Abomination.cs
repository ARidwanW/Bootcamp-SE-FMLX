using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class Abomination : AbstractCard
{
    public Abomination() : base(1, "Abomination", "Foolish rabble! You are beneath me!", 
                                5, 9, CardAbility.None, CardStatus.None, false, false)
    {
    }

    public override bool SpecialAbilityOnGoing(GameController game, IPlayer player, AbstractLocation location)
    {
        return false;
    }

    public override bool SpecialAbilityOnReveal(GameController game, IPlayer player, AbstractLocation location)
    {
        return false;
    }
}
