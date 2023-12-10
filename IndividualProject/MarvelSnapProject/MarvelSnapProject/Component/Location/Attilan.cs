using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public class Attilan : AbstractLocation
{
    public Attilan() : base(3, "Attilan", "After turn 3, shuffle your hand into your deck. Draw cards.", LocationAbility.Attilan, LocationStatus.Hidden, true, false)
    {
        //?? card on hand go to deck, then shuffle the deck
        //?? after shuffle, player get 3 random card, even before has 4 or more
    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        return true;
    }

    public override bool SpecialAbilityOnReveal(GameController game)
    {
        return false;
    }
}
