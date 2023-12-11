using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class Hawkeye : AbstractCard
{
    private int _roundDeployed;
    private AbstractLocation? _locationDeployed;
    private IPlayer _deployer;
    // private IPlayer _deployer;
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
        //?? how to implemen the ability :')
        // if player 1:
        // - card deployed -> end turn -> invoke -> false
        // - player 2 -> end turn -> invoke -> false
        // - next round -> player 1 turn -> invoke -> false (another card deployed yet)
        // - end turn -> player 2 turn -> invoke -> true (if another card is deployed)
        // if player 2:
        // - card deployed -> next round -> player 1 turn -> invoke -> false
        // - end turn -> player 2 turn -> invoke -> false (another card deployed yet)
        // - next round -> player 1 turn -> invoke -> false (coz it's round + 2)
        //! - next turn must be called before next round
        //! or in next round must invoke before adding the round
        if (IsDeployed())
        {
            if (game.GetCurrentRound() != _roundDeployed + 1)
            {
                return false;
            }

            bool anotherCard = game.GetLocation(_locationDeployed).GetPlayerCards(_deployer).Count > 1;
            if (anotherCard)
            {
                return SetPower(GetPower() + 3);
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
