using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class ThePunisher : AbstractCard
{
    private IPlayer _deployer;
    private AbstractLocation _locationDeployed;
    public ThePunisher() : base(14, "The Punisher", "On Going: +1 Power for each opposing card at this location.",
                                3, 2, CardAbility.OnGoing, CardStatus.None, true, false)
    {
    }

    public override AbstractCard Clone()
    {
        return new ThePunisher();
    }

    public override bool SpecialAbilityOnGoing(GameController game)
    {
        if (IsDeployed())
        {
            var location = game.GetDeployedLocation(_locationDeployed);
            var allPlayers = game.GetAllPlayers();
            List<AbstractCard> opponentsCards = new List<AbstractCard>();
            foreach (var player in allPlayers)
            {
                if (player == _deployer)
                {
                    continue;
                }
                opponentsCards.AddRange(location.GetPlayerCards(player));
            }

            if (opponentsCards.Count > 0)
            {
                return this.SetPower(this.GetPower() + opponentsCards.Count);
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
        if ((!IsDeployed()) && (GetCardStatus() == CardStatus.OnHand))
        {
            this.SetCardStatus(CardStatus.OnLocation);
            this.SetDeployer(player);
            this.SetLocationDeployed(location);
            this.RegisterSpecialAbilityOnGoing(game);
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
