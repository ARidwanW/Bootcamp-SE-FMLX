using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class StarLord : AbstractCard
{
    private IPlayer _deployer;
    private AbstractLocation _locationDeployed;
    private int _roundDeployed;
    public StarLord() : base(13, "Star Lord", "On Reveal: If your opponent played a card here this turn, +3 Power.", 
                            2, 2, CardAbility.OnReveal, CardStatus.None, false, true)
    {
    }

    public override AbstractCard Clone()
    {
        return new StarLord();
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
            var allPlayers = game.GetAllPlayers();
            List<AbstractCard> opponentsCards = new List<AbstractCard>();
            foreach( var player in allPlayers)
            {
                if(player == _deployer)
                {
                    continue;
                }
                opponentsCards.AddRange(location.GetPlayerCards(player));
            }

            if(opponentsCards.Count > 0)
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
