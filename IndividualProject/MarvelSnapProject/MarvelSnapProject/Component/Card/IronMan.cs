using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class IronMan : AbstractCard
{
    private int _roundDeployed;
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
        if(IsDeployed())
        {
            if(game.GetCurrentRound() != _roundDeployed)
            {
                return false;
            }

            if(game.GetCurrentTurn() != _deployer)  // when enemy turn, this invoke will true
            {
                AbstractLocation cardLocation = game.GetLocation(_locationDeployed);
                int totalPower = cardLocation.GetPlayerPower(_deployer);
                return cardLocation.AssignPlayerPower(_deployer, totalPower * 2);;
            }
        }
        return false;
    }

    public override bool SpecialAbilityOnReveal(GameController game)
    {
        return false;
    }

    public override bool DeployCard(GameController game, IPlayer player, AbstractLocation location)
    {
        if(!IsDeployed() && GetCardStatus() == CardStatus.OnHand)
        {
            SetCardStatus(CardStatus.OnLocation);
            SetRoundDeployed(game.GetCurrentRound());
            SetDeployer(player);
            SetLocationDeployed(location);
            RegisterSpecialAbilityOnGoing(game);
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

    public void RegisterSpecialAbilityOnGoing(GameController game)
    {
        if (IsDeployed())
        {
            game.OnGoingCardAbilityCall += SpecialAbilityOnGoing;
        }
    }
}
