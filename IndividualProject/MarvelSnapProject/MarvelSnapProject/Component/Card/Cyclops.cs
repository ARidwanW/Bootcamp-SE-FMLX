using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class Cyclops : AbstractCard
{
    public Cyclops() : base(2, "Cyclops", "Lets move, X-men.", 
                            3, 4, CardAbility.None, CardStatus.None, false, false)
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
