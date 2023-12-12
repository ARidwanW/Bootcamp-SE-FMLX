using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public class Asgard : AbstractLocation
{
    public Asgard() : base(1, "Asgard", "After turn 4, whoever is winning here draws 2.", 
                        LocationAbility.Asgard, LocationStatus.Hidden, false, true)
    {

    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        return false;
    }

    public override bool SpecialAbilityOnReveal(GameController game)
    {
        //* NextRound --> invoke --> round + 1
        if (game.GetCurrentRound() != 4)
        {
            return false;
        }

        var allPlayersPower = GetAllPlayersPower();
        List<IPlayer> locationWinners = new List<IPlayer>();
        int maxPower = 0;

        if (allPlayersPower.Count < 0)
        {
            return false;
        }

        foreach (var playerPower in allPlayersPower)
        {
            if (playerPower.Value > maxPower)
            {
                maxPower = playerPower.Value;
            }
        }

        foreach (var playerPower in allPlayersPower)
        {
            if (playerPower.Value == maxPower)
            {
                locationWinners.Add(playerPower.Key);
            }
        }

        var randomCard = game.GetShuffleCard();

        foreach(var winner in locationWinners)
        {
            game.AssignCardToPlayerHand(winner, randomCard);
        }
        return true;
    }

    public void RegisterSpecialAbilityOnReveal(GameController game)
    {
        if (this.GetLocationStatus() == LocationStatus.Revealed)
        {
            game.OnRevealLocationAbilityCall += SpecialAbilityOnReveal;
        }
    }
}
