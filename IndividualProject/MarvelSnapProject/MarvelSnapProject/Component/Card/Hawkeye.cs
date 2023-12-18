using System.Diagnostics;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;
using NLog.Targets;

namespace MarvelSnapProject.Component.Card;

public class Hawkeye : AbstractCard
{
    private int _roundDeployed;
    private AbstractLocation _locationDeployed;
    private IPlayer _deployer;
    public Hawkeye() : base(3, "Hawkeye", "On Reveal: if you play a card at this location next turn, +3 power.",
                            1, 1, CardAbility.OnReveal, CardStatus.None, false, true)
    {
    }

    public override AbstractCard Clone()
    {
        return new Hawkeye();
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

            var location = game.GetDeployedLocation(_locationDeployed);
            bool anotherCard = location.GetPlayerCards(_deployer).Count > 1;
            if (anotherCard)
            {
                game.OnRevealCardAbilityCall -= SpecialAbilityOnGoing;
                return this.SetPower(this.GetPower() + 3);
            }
            game.OnRevealCardAbilityCall -= SpecialAbilityOnGoing;
        }
        return false;
    }

    public override bool DeployCard(GameController game, IPlayer player, AbstractLocation location)
    {
        if ((!IsDeployed()) && (GetCardStatus() == CardStatus.OnHand))
        {
            this.SetCardStatus(CardStatus.OnLocation);
            this.SetRoundDeployed(game.GetCurrentRound());
            this.SetDeployer(player);
            this.SetLocationDeployed(location);
            this.RegisterSpecialAbilityOnReveal(game);
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

    public IPlayer GetDeployer()
    {
        return _deployer;
    }

    public bool SetDeployer(IPlayer player)
    {
        _deployer = player;
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
