using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Location;

public abstract class AbstractLocation
{
    /// <summary>
    /// Gets identifier of the location.
    /// </summary>
    /// <value>int</value>
    public int Id { get; private set; }

    /// <summary>
    /// Gets the name of the location.
    /// </summary>
    /// <value>string</value>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the description of the location.
    /// </summary>
    /// <value>string</value>
    public string Description { get; private set; }

    /// <summary>
    /// Gets the abilities associated with the location.
    /// </summary>
    /// <value>LocationAbility</value>
    public LocationAbility LocationAbility { get; private set; }

    /// <summary>
    /// Represents the status of the location.
    /// </summary>
    private LocationStatus _locationStatus;

    /// <summary>
    /// Gets a value indicating whether the location has the ongoing ability.
    /// </summary>
    /// <value>bool</value>
    public bool _isOnGoing { get; private set; }

    /// <summary>
    ///  Gets a value indicating whether the location has the on reveal ability.
    /// </summary>
    /// <value>bool</value>
    public bool _isOnReveal { get; private set; }

    /// <summary>
    /// Represents the validity of the location.
    /// </summary>
    private bool _isValid;

    /// <summary>
    /// Represents all the cards associated with the location.
    /// </summary>
    private List<AbstractCard> _allCards;

    /// <summary>
    /// Represents the cards associated with each player at the location.
    /// </summary>
    private Dictionary<IPlayer, List<AbstractCard>> _playersCards;

    /// <summary>
    /// Represents the amount of power that each player has at the location.
    /// </summary>
    private Dictionary<IPlayer, int> _playersPower;

    /// <summary>
    /// Represents the status of each player at the location.
    /// </summary>
    private Dictionary<IPlayer, PlayerStatus> _playersStatus;

    /// <summary>
    /// Initializes a new instance of the AbstractLocation class.
    /// </summary>
    /// <param name="id">The identifier of the location.</param>
    /// <param name="name">The name of the location.</param>
    /// <param name="description">The description of the location.</param>
    /// <param name="ability">The abilities associated with the location.</param>
    /// <param name="locationStatus">The status of the location (Hidden, Revealed).</param>
    /// <param name="isOnGoing">A value indicating whether the location has the ongoing ability.</param>
    /// <param name="isOnReveal">A value indicating whether the location has the on reveal ability.</param>
    /// <param name="isValid">A value indicating the validity of the location.</param>
    public AbstractLocation(int id, string name, string description, LocationAbility ability, LocationStatus locationStatus = LocationStatus.Hidden, bool isOnGoing = false, bool isOnReveal = false, bool isValid = true)
    {
        Id = id;
        Name = name;
        Description = description;
        LocationAbility = ability;
        _locationStatus = locationStatus;
        _isOnGoing = isOnGoing;
        _isOnReveal = isOnReveal;
        _isValid = isValid;
        _allCards = new List<AbstractCard>();
        _playersCards = new Dictionary<IPlayer, List<AbstractCard>>();
        _playersPower = new Dictionary<IPlayer, int>();
        _playersStatus = new Dictionary<IPlayer, PlayerStatus>();
    }

    /// <summary>
    /// Executes the ongoing special ability of the location.
    /// </summary>
    /// <param name="game">The game controller instance.</param>
    /// <returns>True if the ongoing ability was successfully executed.</returns>
    public abstract AbstractLocation SpecialAbilityOnGoing(GameController game);

    /// <summary>
    /// Executes the on reveal special ability of the location.
    /// </summary>
    /// <param name="game">The game controller instance.</param>
    /// <returns>True if the on reveal ability was successfully executed.</returns>
    public abstract AbstractLocation SpecialAbilityOnReveal(GameController game);

    /// <summary>
    /// Registers the abilities of the location.
    /// </summary>
    /// <param name="game">The game controller instance.</param>
    /// <returns>True if the location has the ongoing ability, 
    /// false if it has the on reveal ability.</returns>
    public virtual bool RegisterAbility(GameController game)
    {
        if (_isOnGoing)
        {
            return _isOnGoing;
        }
        return _isOnReveal;
    }

    /// <summary>
    /// Gets the current status of the location.
    /// </summary>
    /// <returns>The current status of the location.</returns>
    public LocationStatus GetLocationStatus()
    {
        return _locationStatus;
    }

    /// <summary>
    /// Sets the status of the location.
    /// </summary>
    /// <param name="status">The new status to set.</param>
    /// <returns>True if successfully setting the new status.</returns>
    public bool SetLocationStatus(LocationStatus status)
    {
        _locationStatus = status;
        return true;
    }

    /// <summary>
    /// Checks if the location is valid.
    /// </summary>
    /// <returns>True if the location is valid; otherwise false.</returns>
    public bool IsLocationValid()
    {
        return _isValid;
    }

    /// <summary>
    /// Sets the validity of the location.
    /// </summary>
    /// <param name="valid">The new validity to set.</param>
    /// <returns>True if successfully setting the new validity.</returns>
    public bool SetLocationValid(bool valid)
    {
        _isValid = valid;
        return true;
    }

    /// <summary>
    /// Gets all the cards associated with the location.
    /// </summary>
    /// <returns>A list of all the cards associated with the location.</returns>
    public List<AbstractCard> GetAllCards()
    {
        return _allCards;
    }

    /// <summary>
    /// Assigns cards to the location.
    /// </summary>
    /// <param name="cards">The cards to assign to the location.</param>
    /// <returns>True if successfully assigning the cards.</returns>
    public bool AssignCardToLocation(params AbstractCard[] cards)
    {
        _allCards.AddRange(cards);
        return true;
    }

    /// <summary>
    /// Gets the cards associated with a player at the location.
    /// </summary>
    /// <param name="player">The player to get the cards for.</param>
    /// <returns>A list of the player's cards at the location.</returns>
    public List<AbstractCard> GetPlayerCards(IPlayer player)
    {
        return _playersCards[player];
    }

    /// <summary>
    /// Gets the cards associated with all players at the location.
    /// </summary>
    /// <returns>A dictionary mapping each player to their list of cards 
    /// at the location.</returns>
    public Dictionary<IPlayer, List<AbstractCard>> GetAllPlayersCards()
    {
        return _playersCards;
    }

    /// <summary>
    /// Assigns a card to a player at the location. 
    /// if there is no player in dictionary, it will add new player with new list of cards.
    /// </summary>
    /// <param name="player">The player to assign the card to.</param>
    /// <param name="card">The card to assign to the player.</param>
    /// <returns>True if successfully assigning the card to the player.</returns>
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

        return AssignCardToLocation(card);
    }

    /// <summary>
    /// Gets the power of a player at the location.
    /// </summary>
    /// <param name="player">The player to get the power for.</param>
    /// <returns>The power of the player at the location.</returns>
    public int GetPlayerPower(IPlayer player)
    {
        return _playersPower[player];
    }

    /// <summary>
    /// Gets the power of all players at the location.
    /// </summary>
    /// <returns>A dictionary mapping each player to their power at the location.</returns>
    public Dictionary<IPlayer, int> GetAllPlayersPower()
    {
        return _playersPower;
    }

    /// <summary>
    /// Assigns power to a player at the location.
    /// </summary>
    /// <param name="player">The player to assign the power to.</param>
    /// <param name="power">The power to assign to the player.</param>
    /// <returns>True if successfully assigning the power to the player.</returns>
    public bool AssignPlayerPower(IPlayer player, int power)
    {
        _playersPower[player] = power;
        return true;
    }

    /// <summary>
    /// Adds power to a player at the location. 
    /// if there is no player in dictionary. it will create a new key value pair
    /// </summary>
    /// <param name="player">The player to add the power to.</param>
    /// <param name="powerToAdd">The power to add to the player.</param>
    /// <returns>True if successfully adding the power to the player.</returns>
    public bool AddPlayerPower(IPlayer player, int powerToAdd)
    {
        if (_playersPower.ContainsKey(player))
        {
            _playersPower[player] += powerToAdd;
        }
        else
        {
            _playersPower[player] = powerToAdd;
        }
        return true;
    }

    /// <summary>
    /// Assigns players to the location.
    /// </summary>
    /// <param name="players">The players to assign to the location.</param>
    /// <returns>True if all players were successfully assigned; otherwise false.</returns>
    public bool AssignPlayer(params IPlayer[] players)
    {
        bool status = true;
        foreach (IPlayer player in players)
        {
            if (_playersCards.ContainsKey(player) || _playersPower.ContainsKey(player) || _playersStatus.ContainsKey(player))
            {
                status = false;
                continue;
            }
            _playersCards.Add(player, new List<AbstractCard>());
            _playersPower.Add(player, 0);
            _playersStatus.Add(player, PlayerStatus.None);
        }
        return status;
    }

    /// <summary>
    /// Gets the status of all players at the location.
    /// </summary>
    /// <returns>A dictionary mapping each player to their status at the location.</returns>
    public Dictionary<IPlayer, PlayerStatus> GetAllPlayerStatus()
    {
        return _playersStatus;
    }

    /// <summary>
    /// Gets the status of a player at the location.
    /// </summary>
    /// <param name="player">The player to get the status for.</param>
    /// <returns>The status of the player at the location.</returns>
    public PlayerStatus GetPlayerStatus(IPlayer player)
    {
        return _playersStatus[player];
    }

    /// <summary>
    /// Sets the status of a player at the location.
    /// </summary>
    /// <param name="player">The player to set the status for.</param>
    /// <param name="playerStatus">The status to set for the player.</param>
    /// <returns>True if successfully setting the status for the player; otherwise false.</returns>
    public bool SetPlayerStatus(IPlayer player, PlayerStatus playerStatus)
    {
        _playersStatus[player] = playerStatus;
        return true;
    }

    /// <summary>
    /// Removes card(s) from the location.
    /// </summary>
    /// <param name="cards">The card(s) to remove from the location.</param>
    /// <returns>True if successfully removing all the cards from the location; 
    /// otherwise false.</returns>
    public bool RemoveCardFromLocation(AbstractCard[] cards)
    {
        bool status = true;
        foreach (var card in cards)
        {
            if (_allCards.Contains(card))
            {
                _allCards.Remove(card);
            }
            else
            {
                status = false;
            }
        }
        return status;
    }

    /// <summary>
    /// Removes player(s) from the location.
    /// </summary>
    /// <param name="players">The player(s) to remove from the location.</param>
    /// <returns>True if successfully removing all the players from the location; 
    /// otherwise false.</returns>
    public bool RemovePlayer(IPlayer[] players)
    {
        bool status = true;
        foreach (var player in players)
        {
            if (_playersCards.ContainsKey(player))
            {
                _playersCards.Remove(player);
                _playersPower.Remove(player);
                _playersStatus.Remove(player);
            }
            else
            {
                status = false;
            }
        }
        return status;
    }
}
