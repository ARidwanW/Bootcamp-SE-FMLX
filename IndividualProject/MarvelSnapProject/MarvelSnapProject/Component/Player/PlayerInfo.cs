using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Player;

public class PlayerInfo
{
    private List<AbstractCard>? _deck;
    private List<AbstractCard>? _handCards;
    private int _energy;
    public int MaxDeck { get; private set; }
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

    public bool AssignCardToDeck(AbstractCard card)
    {
        if (_deck.Contains(card))
        {
            return false;
        }

        _deck.Add(card);
        return true;
    }

    public bool AssignCardToDeck(params AbstractCard[] cards)
    {
        foreach (var card in cards)
        {
            if (_deck.Contains(card))
            {
                return false;
            }
            _deck.Add(card);
        }
        return true;
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
        foreach (var card in cards)
        {
            if (!_deck.Contains(card))
            {
                return false;
            }
            _deck.Remove(card);
        }
        return true;
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
        foreach (var card in cards)
        {
            if (_handCards.Contains(card))
            {
                return false;
            }
            _handCards.Add(card);
        }
        return true;
    }


}
