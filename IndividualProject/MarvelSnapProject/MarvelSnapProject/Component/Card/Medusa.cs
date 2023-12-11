using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class Medusa : AbstractCard
{
    private int _roundDeployed;
    private AbstractLocation _locationDeployed;

    public Medusa() : base(7, "Medusa", "On Reveal: if this at the middle location, +3 Power.",
                            2, 2, CardAbility.OnReveal, CardStatus.None, false, true)
    {
    }

    public override AbstractCard Clone()
    {
        return new Medusa();
    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        return false;
    }

    public override bool SpecialAbilityOnReveal(GameController game)
    {
        if (IsDeployed())
        {
            //* NextRound --> invoke --> round + 1
            if (game.GetCurrentRound() != _roundDeployed + 1)
            {
                return false;
            }

            var allLocations = game.GetAllDeployedLocations();
            int locationIndex = allLocations.IndexOf(_locationDeployed);
            bool isLocationMid;
            if (allLocations.Count % 2 == 0)
            {
                isLocationMid = locationIndex == (allLocations.Count / 2) - 1;
            }
            else
            {
                isLocationMid = locationIndex == (allLocations.Count / 2);
            }

            if (isLocationMid)
            {
                return this.SetPower(this.GetPower() + 3);
            }
        }
        return false;
    }

    public override bool DeployCard(GameController game, IPlayer player, AbstractLocation location)
    {
        if (!IsDeployed() && GetCardStatus() == CardStatus.OnHand)
        {
            SetCardStatus(CardStatus.OnLocation);
            SetRoundDeployed(game.GetCurrentRound());
            SetLocationDeployed(location);
            RegisterSpecialAbilityOnReveal(game);
            return true;
        }
        return false;
    }

    public int GetRoundDeployed()
    {
        return _roundDeployed;
    }

    public bool SetRoundDeployed(int round)
    {
        _roundDeployed = round;
        return true;
    }

    public AbstractLocation GetLocationDeployed()
    {
        return _locationDeployed;
    }

    public bool SetLocationDeployed(AbstractLocation location)
    {
        _locationDeployed = location;
        return true;
    }

    public void RegisterSpecialAbilityOnReveal(GameController game)
    {
        if (IsDeployed())
        {
            game.OnRevealCardAbilityCall += SpecialAbilityOnReveal;
        }
    }
}
