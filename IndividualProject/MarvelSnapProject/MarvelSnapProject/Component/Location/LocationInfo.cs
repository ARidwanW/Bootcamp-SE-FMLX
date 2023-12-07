using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Player;

namespace MarvelSnapProject.Component.Location;

public class LocationInfo
{
    private List<AbstractCard> _allCards;
    private Dictionary<IPlayer, List<AbstractCard>> _playersCards;
    private Dictionary<IPlayer, int> _playersPower;

    public LocationInfo()
    {
        _allCards = new List<AbstractCard>();
        _playersCards = new Dictionary<IPlayer, List<AbstractCard>>();
        _playersPower = new Dictionary<IPlayer, int>();
    }

    public List<AbstractCard> GetAllCards()
    {
        return _allCards;
    }

    public bool AssignCardToLocation(params AbstractCard[] cards)
    {
        return true;
    }

    public List<AbstractCard> GetPlayerCards(IPlayer player)
    {
        return _playersCards[player];
    }

    public bool AssignPlayerCardToLocation(IPlayer player, AbstractCard card)
    {
        if (!_playersCards.ContainsKey(player))
        {
            _playersCards.Add(player, new List<AbstractCard> { card });
        }
        else
        {
            _playersCards[player].Add(card);
        }
        return true;
    }

    public int GetPlayerPower(IPlayer player)
    {
        return _playersPower[player];
    }

    public bool AssignPlayerPower(IPlayer player, int power)
    {
        bool status = _playersPower.TryAdd(player, power);
        return status;
    }
}
