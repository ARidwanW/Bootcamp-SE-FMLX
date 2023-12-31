using System.Diagnostics;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public class KunLun : AbstractLocation
{
    public KunLun() : base(7, "K'un-Lun", "When a card moves here, give it +2 Power.",
                        LocationAbility.KunLun, LocationStatus.Hidden, true, false)
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
                    card.SetPower(card.GetPower() + 2);
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
