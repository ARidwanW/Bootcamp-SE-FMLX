using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class Howkeye : AbstractCard
{
    public Howkeye() : base(3, "Hawkeye", "On Reveal: if you play a card at this location next turn, +3 power.", 
                            1, 1, CardAbility.OnReveal, CardStatus.None, false, true)
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
