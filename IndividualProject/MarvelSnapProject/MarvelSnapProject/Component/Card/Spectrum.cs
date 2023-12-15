using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class Spectrum : AbstractCard
{
    private IPlayer _deployer;
    private int _roundDeployed;

    public Spectrum() : base(12, "Spectrum", "On Reveal: Give your Ongoing cards +2 Power.",
                            6, 7, CardAbility.OnReveal, CardStatus.None, false, true)
    {
    }

    public override AbstractCard Clone()
    {
        return new Spectrum();
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

            //! you can simply this
            var allDeployedLocations = game.GetAllDeployedLocations();
            List<AbstractCard> playerCards = new List<AbstractCard>();
            foreach (var location in allDeployedLocations)
            {
                playerCards = location.GetPlayerCards(_deployer);
            }

            foreach (var card in playerCards)
            {
                if (card.Name != this.Name)
                {
                    card.SetPower(card.GetPower() + 2);
                }
            }
            return true;
        }
        return false;
    }

    public override bool DeployCard(GameController game, IPlayer player, AbstractLocation location)
    {
        if ((!IsDeployed()) && (GetCardStatus() == CardStatus.OnHand))
        {
            this.SetCardStatus(CardStatus.OnLocation);
            this.SetRoundDeployed(game.GetCurrentRound());
            this.RegisterSpecialAbilityOnReveal(game);
            return true;
        }
        return false;
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

    public int GetRoundDeployed()
    {
        return _roundDeployed;
    }

    public bool SetRoundDeployed(int round)
    {
        _roundDeployed = round;
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
