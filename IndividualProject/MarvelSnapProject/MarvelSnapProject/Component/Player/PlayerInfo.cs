using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Player;

public class PlayerInfo
{
    /// <summary>
    /// Private variable list of abstract card in player deck
    /// </summary>
    private List<AbstractCard> _deck;

    /// <summary>
    /// Private variable list of abstract card in player hand
    /// </summary>
    private List<AbstractCard> _handCards;

    /// <summary>
    /// Private variable integer energy of player
    /// </summary>
    private int _energy;

    /// <summary>
    /// Private variable integer max card in player deck
    /// </summary>
    private int _maxDeck = 12;

    /// <summary>
    /// Private variable integer total win location of player
    /// </summary>
    private int _totalWin;

    /// <summary>
    /// Private variabel status of player
    /// </summary>
    private PlayerStatus _playerStatus;

    public PlayerInfo()
    {
        _deck = new List<AbstractCard>();
        _handCards = new List<AbstractCard>();
    }

    /// <summary>
    /// A method to get the list of abstract card in player deck
    /// </summary>
    /// <returns>List of AbstractCard</returns>
    public List<AbstractCard> GetDeck()
    {
        return _deck;
    }

    /// <summary>
    /// A method to check if card in player deck is full
    /// </summary>
    /// <returns>true: if full; otherwise, false</returns>
    public bool IsDeckFull()
    {
        if (_deck.Count < _maxDeck)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// A Method to assign card to deck.
    /// if deck contain any card in cards, it will continue to the next card, 
    /// but return false (means one or more card(s) cannot be assign)
    /// </summary>
    /// <param name="cards">can be one or more card(s) of AbstractCard</param>
    /// <returns>true: if all card successfully assigned to deck; otherwise, false</returns>
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

    /// <summary>
    /// A method to retrieve or remove card from player deck.
    /// if deck NOT contain any card in cards, it will continue to the next card,
    /// but return false (means one or more card(s) cannot be retrieve because there is no card in deck)
    /// </summary>
    /// <param name="cards">can be one or more card(s) of AbstractCard</param>
    /// <returns>true: if all card successfully retrieved from deck; otherwise, false</returns>
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

    /// <summary>
    /// A method to get list of abstract card in player hand
    /// </summary>
    /// <returns>List of AbstractCard</returns>
    public List<AbstractCard> GetHandCards()
    {
        return _handCards;
    }

    /// <summary>
    /// A Method to assign card to player hand.
    /// player hand can have a duplicate cards
    /// </summary>
    /// <param name="cards">can be one or more card(s) of AbstractCard</param>
    /// <returns>true: if all card is successfully assigned to player hand; otherwise, false</returns>
    public bool AssignCardToHand(params AbstractCard[] cards)
    {
        // int status = 0;
        foreach (var card in cards)
        {
            // if (_handCards.Contains(card))
            // {
            //     status++;
            //     continue;
            // }
            if(_deck.Contains(card))
            {
                _handCards.Add(card);
            }
        }
        // return (status > 0) ? false : true;
        return true;
    }

    /// <summary>
    /// A method to retrieve or remove card from player hand.
    /// if player hand NOT contain any card in cards, it will continue to the next card,
    /// but return false (means one or more card(s) cannot be retrieve because there is no card in hand)
    /// </summary>
    /// <param name="cards">can be one or more card(s) of AbstractCard</param>
    /// <returns>true: if all card successfully retrieved from hand; otherwise, false</returns>
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

    /// <summary>
    /// Getter of player energy
    /// </summary>
    /// <returns>Integer of player energy</returns>
    public int GetEnergy()
    {
        return _energy;
    }

    /// <summary>
    /// Setter of player energy
    /// </summary>
    /// <param name="energy"></param>
    /// <returns>true: if successfully set the energy</returns>
    public bool SetEnergy(int energy)
    {
        _energy = energy;
        return true;
    }

    /// <summary>
    /// Getter of player max deck
    /// </summary>
    /// <returns>Integer of player max deck</returns>
    public int GetMaxDeck()
    {
        return _maxDeck;
    }

    /// <summary>
    /// Setter of player max deck
    /// </summary>
    /// <param name="maxDeck"></param>
    /// <returns>true: if successfully set the player max deck</returns>
    public bool SetMaxDeck(int maxDeck)
    {
        _maxDeck = maxDeck;
        return true;
    }

    /// <summary>
    /// A method to get the player total win of location
    /// </summary>
    /// <returns>Integer of total win</returns>
    public int GetTotalWin()
    {
        return _totalWin;
    }

    /// <summary>
    /// A method to add player total win by 1
    /// </summary>
    /// <returns>true: if successfully add player total win by 1 </returns>
    public bool AddTotalWin()
    {
        _totalWin += 1;
        return true;
    }

    /// <summary>
    /// Getter of player status (win, lose, draw)
    /// </summary>
    /// <returns>status player of PlayerStatus</returns>
    public PlayerStatus GetPlayerStatus()
    {
        return _playerStatus;
    }

    /// <summary>
    /// Setter of player status (win, lose, draw)
    /// </summary>
    /// <param name="status">Win, Lose, Draw</param>
    /// <returns>true: if successfully set the player status</returns>
    public bool SetPlayerStatus(PlayerStatus status)
    {
        _playerStatus = status;
        return true;
    }
}
