using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class JessicaJones : AbstractCard
{
    private int _roundDeployed;
    private AbstractLocation _locationDeployed;
    private IPlayer _deployer;
    public JessicaJones() : base(6, "Jessica Jones", "On Reveal: if you don't play a card at this location next turn, +4 Power.",
                                4, 5, CardAbility.OnReveal, CardStatus.None, false, true)
    {
    }

    public override AbstractCard Clone()
    {
        return new JessicaJones();
    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        return false;
    }

    public override bool SpecialAbilityOnReveal(GameController game)
    {
        if (IsDeployed())
        {
            if (game.GetCurrentRound() != _roundDeployed + 1)
            {
                return false;
            }

            AbstractLocation location = game.GetLocation(_locationDeployed);
            bool anotherCard = location.GetPlayerCards(_deployer).Count == 1;
            if (anotherCard)
            {
                return SetPower(GetPower() + 4);
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
            SetDeployer(player);
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
