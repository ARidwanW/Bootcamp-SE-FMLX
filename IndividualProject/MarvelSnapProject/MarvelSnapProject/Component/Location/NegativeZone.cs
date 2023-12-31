using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public class NegativeZone : AbstractLocation
{
    public NegativeZone() : base(8, "Negative Zone", "Cards here have -3 Power.", LocationAbility.NegativeZone, LocationStatus.Hidden, true, false)
    {
    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        foreach (var player in GetAllPlayersCards())
        {
            foreach (var card in GetPlayerCards(player.Key))
            {
                if (card.GetCardStatus() != CardStatus.OnReveal)
                {
                    card.SetPower(card.GetPower() - 3);
                    card.SetCardStatus(CardStatus.OnReveal);
                }
            }
        }
        return true;
    }

    public override bool SpecialAbilityOnReveal(GameController game)
    {
        return false;
    }

    public void RegisterSpecialAbilityOnGoing(GameController game)
    {
        if (this.GetLocationStatus() == LocationStatus.Revealed)
        {
            game.OnGoingLocationAbilityCall += SpecialAbilityOnGoing;
        }
    }

    public override bool RegisterAbility(GameController game)
    {
        RegisterSpecialAbilityOnGoing(game);
        return true;
    }
}
