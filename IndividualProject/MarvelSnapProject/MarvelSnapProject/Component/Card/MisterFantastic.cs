using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class MisterFantastic : AbstractCard
{
    private AbstractLocation _locationDeployed;
    private IPlayer _deployer;

    public MisterFantastic() : base(8, "Mister Fantastic", "On Going: Adjacent locations have +2 Power.",
                                    3, 2, CardAbility.OnGoing, CardStatus.None, true, false)
    {
    }

    public override AbstractCard Clone()
    {
        return new MisterFantastic();
    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        int status = 0;
        var allLocations = game.GetAllLocations();
        int cardLocationIndex = allLocations.IndexOf(_locationDeployed);
        // AbstractLocation adjacentLocationLeft;
        // AbstractLocation adjacentLocationRight;
        if (cardLocationIndex != 0)
        {
            AbstractLocation adjacentLocationLeft = allLocations[cardLocationIndex - 1];
            AbstractLocation locationLeft = game.GetLocation(adjacentLocationLeft);
            locationLeft.AssignPlayerPower(_deployer, locationLeft.GetPlayerPower(_deployer) + 3);
            status++;
        }

        if (cardLocationIndex != (allLocations.Count - 1))
        {
            AbstractLocation adjacentLocationRight = allLocations[cardLocationIndex + 1];
            AbstractLocation locationRight = game.GetLocation(adjacentLocationRight);
            locationRight.AssignPlayerPower(_deployer, locationRight.GetPlayerPower(_deployer) + 3);
            status++;
        }
        return (status > 0) ? true: false;
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
