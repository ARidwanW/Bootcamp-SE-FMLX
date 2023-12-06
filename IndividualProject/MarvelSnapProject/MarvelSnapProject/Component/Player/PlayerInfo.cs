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
        if(_deck.Count < _maxDeck)
        {
            return false;
        }
        return true;
    }

    public bool AssignCardToDeck(AbstractCard card)
    {
        IsDeckFull();
        if (_deck.Contains(card))
        {
            return false;
        }

        _deck.Add(card);
        return true;
    }

    public bool AssignCardToDeck(params AbstractCard[] cards)
    {
        IsDeckFull();
        int status = 0;
        foreach (var card in cards)
        {
            if (_deck.Contains(card))
            {
                continue;
            }
            status++;
            _deck.Add(card);
            IsDeckFull();
        }
        return (status > 0) ? true : false;
    }

    public bool RetrieveCardFromDeck(AbstractCard card)
    {
        if (!_deck.Contains(card))
        {
            return false;
        }
        _deck.Remove(card);
        return true;
    }

    public bool RetrieveCardFromDeck(params AbstractCard[] cards)
    {
        int status = 0;
        foreach (var card in cards)
        {
            if (!_deck.Contains(card))
            {
                continue;
            }
            status++;
            _deck.Remove(card);
        }
        return (status > 0) ? true : false;
    }

    public List<AbstractCard> GetHandCards()
    {
        return _handCards;
    }

    public bool AssignCardToHand(AbstractCard card)
    {
        if (_handCards.Contains(card))
        {
            return false;
        }
        _handCards.Add(card);
        return true;
    }

    public bool AssignCardToHand(params AbstractCard[] cards)
    {
        int status = 0;
        foreach (var card in cards)
        {
            if (_handCards.Contains(card))
            {
                continue;
            }
            status++;
            _handCards.Add(card);
        }
        return (status > 0) ? true : false;
    }

    public bool RetrieveCardFromHand(AbstractCard card)
    {
        if (!_handCards.Contains(card))
        {
            return false;
        }
        _handCards.Remove(card);
        return true;
    }

    public bool RetrieveCardFromHand(params AbstractCard[] cards)
    {
        int status = 0;
        foreach (var card in cards)
        {
            if (!_handCards.Contains(card))
            {
                continue;
            }
            status++;
            _handCards.Remove(card);
        }
        return (status > 0) ? true : false;
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
