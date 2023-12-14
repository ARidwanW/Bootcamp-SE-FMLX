using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class NoneCard : AbstractCard
{
    public NoneCard() : base(0, "NONE", "None", 0, 0, CardAbility.None, CardStatus.None, false, false)
    {
    }


    public override AbstractCard Clone()
    {
        throw new NotImplementedException();
    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        throw new NotImplementedException();
    }

    public override bool SpecialAbilityOnReveal(GameController game)
    {
        throw new NotImplementedException();
    }

}
