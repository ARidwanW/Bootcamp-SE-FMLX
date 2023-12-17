using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Player;

public class PlayerInfo
{
    /// <summary>
    /// Represents the deck of cards held by the player.
    /// </summary>
    private List<AbstractCard> _deck;

    /// <summary>
    /// Represents the cards currently in the player's hand.
    /// </summary>
    private List<AbstractCard> _handCards;

    /// <summary>
    /// Represents the current energy that the player has.
    /// </summary>
    private int _energy;

    /// <summary>
    /// Represents the maximum number of cards allowed in the player's deck.
    /// The default is 12.
    /// </summary>
    private int _maxDeck = 12;

    /// <summary>
    /// Represents the total number of locations won by the player.
    /// </summary>
    private int _totalWin;

    /// <summary>
    /// Represents the current status of the player.
    /// </summary>
    private PlayerStatus _playerStatus;


    /// <summary>
    /// Initializes a new instance of the PlayerInfo class.
    /// </summary>
    public PlayerInfo()
    {
        _deck = new List<AbstractCard>();
        _handCards = new List<AbstractCard>();
    }

    /// <summary>
    /// Retrieves the list of cards in the player's deck.
    /// </summary>
    /// <returns>A list of cards in the player's deck.</returns>
    public List<AbstractCard> GetDeck()
    {
        return _deck;
    }

    /// <summary>
    /// Checks if the player's deck is full.
    /// </summary>
    /// <returns>True if the deck is full; otherwise, false.</returns>
    public bool IsDeckFull()
    {
        if (_deck.Count < _maxDeck)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Assigns cards to the player's deck. If the deck already contains any of the cards, 
    /// it will continue to the next card, but return false (indicating that one or more cards could not be assigned).
    /// </summary>
    /// <param name="cards">One or more cards to assign to the deck.</param>
    /// <returns>True if all cards were successfully assigned to the deck; otherwise, false.</returns>
    public bool AssignCardToDeck(params AbstractCard[] cards)
    {
        bool status = true;
        foreach (var card in cards)
        {
            if (IsDeckFull())
            {
                return false;
            }

            if (_deck.Contains(card))
            {
                status = false;
                continue;
            }
            _deck.Add(card);
        }
        return status;
    }

    /// <summary>
    /// Removes cards from the player's deck. If the deck does not contain any of the cards, 
    /// it will continue to the next card, but return false 
    /// (indicating that one or more cards could not be Removed 
    /// because they are not in the deck).
    /// </summary>
    /// <param name="cards">The card(s) to remove from the deck.</param>
    /// <returns>True if all card(s) were successfully removed from the deck; 
    /// otherwise, false.</returns>
    public bool RemoveCardFromDeck(params AbstractCard[] cards) //?? remove
    {
        var cardNames = new HashSet<string>(cards.Select(card => card.Name));

        int initialDeckCount = _deck.Count;
        _deck.RemoveAll(card => cardNames.Contains(card.Name));
        int finalDeckCount = _deck.Count;

        return (initialDeckCount - finalDeckCount) == cards.Length;
    }

    /// <summary>
    /// Retrieves the list of cards in the player's hand.
    /// </summary>
    /// <returns>A list of cards in the player's hand.</returns>
    public List<AbstractCard> GetHandCards()
    {
        return _handCards;
    }

    /// <summary>
    /// Assigns card(s) to the player's hand. The player's hand can contain duplicate cards.
    /// </summary>
    /// <param name="cards">The card(s) to assign to the player's hand.</param>
    /// <returns>True if all card(s) were successfully assigned to the player's hand; otherwise, false.</returns>
    public bool AssignCardToHand(params AbstractCard[] cards)
    {
        foreach (var card in cards)
        {
            _handCards.Add(card);
        }
        return true;
    }

    /// <summary>
    /// Removes card(s) from the player's hand. 
    /// If the player's hand does not contain any of the card(s), 
    /// it will continue to the next card, but return false 
    /// (indicating that one or more card(s) could not be removed 
    /// because they are not in the hand).
    /// </summary>
    /// <param name="cards">The card(s) to remove from the player's hand.</param>
    /// <returns>True if all card(s) were successfully removed from the hand; otherwise, false.</returns>
    public bool RetrieveCardFromHand(params AbstractCard[] cards)
    {
        var cardNames = new HashSet<string>(cards.Select(card => card.Name));

        int initialHandCount = _handCards.Count;
        _handCards.RemoveAll(card => cardNames.Contains(card.Name));
        int finalHandCount = _handCards.Count;

        return (initialHandCount - finalHandCount) == cards.Length;
    }

    /// <summary>
    /// Retrieves the current energy of the player.
    /// </summary>
    /// <returns>The current energy of the player.</returns>
    public int GetEnergy()
    {
        return _energy;
    }

    /// <summary>
    /// Sets the energy of the player.
    /// </summary>
    /// <param name="energy">The new energy to set.</param>
    /// <returns>True if successfully setting the new energy.</returns>
    public bool SetEnergy(int energy)
    {
        _energy = energy;
        return true;
    }

    /// <summary>
    /// Retrieves the maximum number of cards allowed in the player's deck.
    /// </summary>
    /// <returns>The maximum number of cards allowed in the player's deck.</returns>
    public int GetMaxDeck()
    {
        return _maxDeck;
    }

    /// <summary>
    /// Sets the maximum number of cards allowed in the player's deck.
    /// </summary>
    /// <param name="maxDeck">The new maximum number of cards to set.</param>
    /// <returns>True if successfully setting the new maximum number of cards.</returns>
    public bool SetMaxDeck(int maxDeck)
    {
        _maxDeck = maxDeck;
        return true;
    }

    /// <summary>
    /// Retrieves the total number of locations won by the player.
    /// </summary>
    /// <returns>The total number of locations won by the player.</returns>
    public int GetTotalWin()
    {
        return _totalWin;
    }

    /// <summary>
    /// Increases the total number of locations won by the player by 1.
    /// </summary>
    /// <returns>True if successfully increasing the total win count by 1; 
    /// otherwise false.</returns>
    public bool AddTotalWin()
    {
        _totalWin += 1;
        return true;
    }

    /// <summary>
    /// Increases the total number of locations won by the player by a specified number.
    /// </summary>
    /// <param name="addWin">The number to increase the total win count by.</param>
    /// <returns>True if successfully increasing the total win count; 
    /// otherwise false.</returns>
    public bool AddTotalWin(int addWin)
    {
        _totalWin += addWin;
        return true;
    }

    /// <summary>
    /// Sets the total number of locations won by the player.
    /// </summary>
    /// <param name="totalWin">The new total number of wins to set.</param>
    /// <returns>True if successfully setting the new total win count; 
    /// otherwise false.</returns>
    public bool SetTotalWin(int totalWin)
    {
        _totalWin = totalWin;
        return true;
    }

    /// <summary>
    /// Retrieves the current status of the player (none, win, lose, draw).
    /// </summary>
    /// <returns>The current status of the player.</returns>
    public PlayerStatus GetPlayerStatus()
    {
        return _playerStatus;
    }

    /// <summary>
    /// Sets the status of the player (none, win, lose, draw).
    /// </summary>
    /// <param name="status">The new status to set (None, Win, Lose, Draw).</param>
    /// <returns>True if successfully setting the new status; otherwise false.</returns>
    public bool SetPlayerStatus(PlayerStatus status)
    {
        _playerStatus = status;
        return true;
    }
}
