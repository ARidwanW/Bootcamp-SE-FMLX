using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class IronMan : AbstractCard
{
    private AbstractLocation _locationDeployed;
    private IPlayer _deployer;

    public IronMan() : base(5, "Iron Man", "On Going: Your total Power is doubled at this location.",
                            5, 0, CardAbility.OnGoing, CardStatus.None, true, false)
    {
    }

    public override AbstractCard Clone()
    {
        return new IronMan();
    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        if (IsDeployed())
        {
            AbstractLocation cardLocation = game.GetDeployedLocation(_locationDeployed);
            int totalPower = cardLocation.GetPlayerPower(_deployer);
            return cardLocation.AssignPlayerPower(_deployer, totalPower * 2); ;
        }
        return false;
    }

    public override bool SpecialAbilityOnReveal(GameController game)
    {
        return false;
    }

    public override bool DeployCard(GameController game, IPlayer player, AbstractLocation location)
    {
        if (!IsDeployed() && GetCardStatus() == CardStatus.OnHand)
        {
            SetCardStatus(CardStatus.OnLocation);
            SetDeployer(player);
            SetLocationDeployed(location);
            RegisterSpecialAbilityOnGoing(game);
            return true;
        }
        return false;
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

    public void RegisterSpecialAbilityOnGoing(GameController game)
    {
        if (IsDeployed())
        {
            game.OnGoingCardAbilityCall += SpecialAbilityOnGoing;
        }
    }
}
