using MarvelSnapProject.Enum;
using NLog.LayoutRenderers;

namespace MarvelSnapProject.Component.Location;

public class AvengersCompound : AbstractLocation
{
    public AvengersCompound() : base(4, "Avengers Compound", "On turn 5, all cards must be played here.", 
                            LocationAbility.AvengersCompound, LocationStatus.Hidden, false, true)
    {
    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        return false;
    }

    public override bool SpecialAbilityOnReveal(GameController game)
    {
        //* NextRound --> invoke --> round + 1
        if (game.GetCurrentRound() != 3)
        {
            return false;
        }

        foreach(var location in game.GetAllDeployedLocations())
        {
            if(location.Name == this.Name)
            {
                continue;
            }
            location.SetLocationValid(false);
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

    public override bool RegisterAbility(GameController game)
    {
        RegisterSpecialAbilityOnReveal(game);
        return true;
    }
}
