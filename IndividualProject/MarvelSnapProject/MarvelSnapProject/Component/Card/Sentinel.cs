using System.Runtime.InteropServices;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public class Sentinel : AbstractCard
{
    private int _roundDeployed;
    private IPlayer _deployer;
    public Sentinel() : base(11, "Sentinel", "On Reveal: Add another Sentinel to your hand.",
                            2, 3, CardAbility.OnReveal, CardStatus.None, false, true)
    {
    }

    public override AbstractCard Clone()
    {
        return new Sentinel();
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
            return game.AssignCardToPlayerHand(_deployer, false, false, true, false, new Sentinel());
            //?? set card status on hand here
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

    public int GetRoundDeployed()
    {
        return _roundDeployed;
    }

    public bool SetRoundDeployed(int round)
    {
        _roundDeployed = round;
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
