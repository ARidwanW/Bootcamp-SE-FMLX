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

        // var allPlayersPower = GetAllPlayersPower();
        List<IPlayer> locationWinners = new List<IPlayer>();
        int maxPower = 0;

        if (GetAllPlayersPower().Count < 0)
        {
            return false;
        }

        foreach (var playerPower in GetAllPlayersPower())
        {
            if (playerPower.Value > maxPower)
            {
                maxPower = playerPower.Value;
            }
        }

        foreach (var playerPower in GetAllPlayersPower())
        {
            if (playerPower.Value == maxPower)
            {
                locationWinners.Add(playerPower.Key);
            }
        }



        foreach (var winner in locationWinners)
        {
            for (int i = 0; i < 2; i++)
            {
                var randomCard = game.GetShuffleCard();
                game.AssignCardToPlayerHand(winner, randomCard);
            }
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
