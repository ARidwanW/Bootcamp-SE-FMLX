using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Player;

public class PlayerInfo
{
    private List<AbstractCard> _deck;
    private List<AbstractCard> _handCards;
    private int _energy;
    private int _maxDeck = 12;
    private int _totalWin;
    private PlayerStatus _playerStatus;

    public PlayerInfo()
    {
        _deck = new List<AbstractCard>();
        _handCards = new List<AbstractCard>();
    }

    public List<AbstractCard> GetDeck()
    {
        return _deck;
    }

    public bool IsDeckFull()
    {
        if (_deck.Count < _maxDeck)
        {
            return false;
        }
        return true;
    }

    public bool AssignCardToDeck(params AbstractCard[] cards)
    {
        int status = 0;
        foreach (var card in cards)
        {
            if (IsDeckFull())
            {
                return false;
            }

            if (_deck.Contains(card))
            {
                status++;
                continue;
            }
            _deck.Add(card);            
        }
        return (status > 0) ? false : true;     // ?? if deck contain any card in cards, it will continue to the next card, but return false (means one or more card cannot be assign)
    }

    public bool RetrieveCardFromDeck(params AbstractCard[] cards)
    {
        int status = 0;
        foreach (var card in cards)
        {
            if (!_deck.Contains(card))
            {
                status++;
                continue;
            }
            _deck.Remove(card);
        }
        return (status > 0) ? false : true;
    }

    public List<AbstractCard> GetHandCards()
    {
        return _handCards;
    }

    public bool AssignCardToHand(params AbstractCard[] cards)
    {
        int status = 0;
        foreach (var card in cards)
        {
            if (_handCards.Contains(card))
            {
                status++;
                continue;
            }
            _handCards.Add(card);
        }
        return (status > 0) ? false : true;
    }

    public bool RetrieveCardFromHand(params AbstractCard[] cards)
    {
        int status = 0;
        foreach (var card in cards)
        {
            if (!_handCards.Contains(card))
            {
                status++;
                continue;
            }
            _handCards.Remove(card);
        }
        return (status > 0) ? false : true;
    }

    public int GetEnergy()
    {
        return _energy;
    }

    public bool SetEnergy(int energy)
    {
        _energy = energy;
        return true;
    }

    public int GetMaxDeck()
    {
        return _maxDeck;
    }

    public bool SetMaxDeck(int maxDeck)
    {
        _maxDeck = maxDeck;
        return true;
    }
}
