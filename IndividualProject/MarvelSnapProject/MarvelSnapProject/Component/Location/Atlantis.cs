using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public class Atlantis : AbstractLocation
{
    public Atlantis() : base(2, "Atlantis", "If you only have one card here, it has +5 Power.", 
    LocationAbility.Atlantis, LocationStatus.Hidden, true, false)
    {
    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        foreach(var playersCards in GetAllPlayersCards())
        {
            if(playersCards.Value.Count != 1)
            {
                continue;
            }
            
            var card = playersCards.Value[0];
            card.SetPower(card.GetPower() + 5);
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
}
