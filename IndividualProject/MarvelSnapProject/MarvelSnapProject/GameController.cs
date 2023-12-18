using System.Reflection;
using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;
using NLog;
using Spectre.Console;

namespace MarvelSnapProject;

public class GameController
{
    /// <summary>
    /// Instance of GameController logger.
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Game status (None, Running, Finished).
    /// </summary>
    private GameStatus _gameStatus;

    /// <summary>
    /// Current round of the game.
    /// </summary>
    private int _round;

    /// <summary>
    /// Maximum rounds in the game. 
    /// Default is 6 rounds when the game is created.
    /// </summary>
    private int _maxRound;

    /// <summary>
    /// Dictionary of players and their information. 
    /// PlayerInfo stores card in deck and hand, energy, 
    /// max deck, total wins, and player status.
    /// </summary>
    private Dictionary<IPlayer, PlayerInfo> _players;

    /// <summary>
    /// List of deployed locations. 
    /// A deployed location is a location used or implemented in the game.
    /// </summary>
    private List<AbstractLocation> _locations;

    /// <summary>
    /// Maximum number of deployable locations. 
    /// Default is 3 deployable locations when the game is created.
    /// </summary>
    private int _maxLocation;

    /// <summary>
    /// List of all locations in the game.
    /// </summary>
    private List<AbstractLocation> _allLocations;

    /// <summary>
    /// List of all cards in the game.
    /// </summary>
    private List<AbstractCard> _allCards;

    /// <summary>
    /// The player whose turn it currently is.
    /// </summary>
    private IPlayer _currentTurn;

    /// <summary>
    /// Winner of the game.
    /// </summary>
    private IPlayer _winner;

    /// <summary>
    /// Action to handle updates to the status of a card.
    /// </summary>
    public event Action<AbstractCard, CardStatus>? OnCardStatusUpdate;

    /// <summary>
    /// Action to handle updates to the status of a location.
    /// </summary>
    public event Action<AbstractLocation, LocationStatus>? OnLocationStatusUpdate;

    /// <summary>
    /// Action to handle updates to the status of a player.
    /// </summary>
    public event Action<IPlayer, PlayerStatus>? OnPlayerStatusUpdate;

    /// <summary>
    /// Action to handle updates to a location.
    /// </summary>
    public event Action<AbstractLocation>? OnLocationUpdate;

    /// <summary>
    /// Action to handle updates to a player's information.
    /// </summary>
    public event Action<IPlayer, PlayerInfo>? OnPlayerUpdate;

    /// <summary>
    /// Event to handle the reveal of a card's ability. 
    /// Invoked by default in the NextRound() method.
    /// </summary>
    public event Func<GameController, bool>? OnRevealCardAbilityCall;

    /// <summary>
    /// Event to handle the reveal of a location's ability. 
    /// Invoked by default in the NextRound() method.
    /// </summary>
    public event Func<GameController, bool>? OnRevealLocationAbilityCall;

    /// <summary>
    /// Event to handle ongoing card abilities. 
    /// Invoked by default in the NextRound() method.
    /// </summary>
    public event Func<GameController, bool>? OnGoingCardAbilityCall;

    /// <summary>
    /// Event to handle ongoing location abilities. 
    /// Invoked by default in the NextRound() method.
    /// </summary>
    public event Func<GameController, bool>? OnGoingLocationAbilityCall;


    /// <summary>
    /// Constructor for GameController. Initializes default parameters.
    /// </summary>
    /// <param name="log">Instance of Logger, such as NLog.</param>
    public GameController(ILogger? log = null)
    {
        _logger = log;
        _logger?.Info("Creating Game...");
        _gameStatus = GameStatus.None;
        _players = new Dictionary<IPlayer, PlayerInfo>();
        _locations = new List<AbstractLocation>();
        _allLocations = new List<AbstractLocation>();
        _allCards = new List<AbstractCard>();
        _round = 0;
        _maxRound = 6;
        _maxLocation = 3;
        _logger?.Info("Game status: {status}, current round: {round}, max round: {maxRound}, max location: {maxLocation}",
                        _gameStatus, _round, _maxRound, _maxLocation);
        _logger?.Info("Players: {players}, deployed locations: {locations}",
                        _players, _locations);
        _logger?.Info("default locations: {allLocations}, default cards: {allCards}",
                        _allLocations, _allCards);
        _logger?.Info("Current turn: {turn}", _currentTurn);


    }

    //* gamecontroller to assign all variable overloading
    public GameController(GameStatus gameStatus, int round, int maxRound, int maxLocation,
                        Dictionary<IPlayer, PlayerInfo> players, List<AbstractLocation> locations,
                        List<AbstractLocation> allLocations, List<AbstractCard> allCards, IPlayer currentTurn,
                        ILogger? log = null)
    {
        _logger = log;
        _logger?.Info("Creating Game...");
        _gameStatus = gameStatus;
        _round = round;
        _maxRound = maxRound;
        _maxLocation = maxLocation;
        _players = players;
        _locations = locations;
        _allLocations = allLocations;
        _allCards = allCards;
        _currentTurn = currentTurn;
        _logger?.Info("Game status: {status}, current round: {round}, max round: {maxRound}, max location: {maxLocation}.",
                        _gameStatus, _round, _maxRound, _maxLocation);
        _logger?.Info("Players: {players}, deployed locations: {locations}.",
                        _players, _locations);
        _logger?.Info("default locations: {allLocations}, default cards: {allCards}.",
                        _allLocations, _allCards);
        _logger?.Info("Current turn: {turn}.", _currentTurn);
    }

    /// <summary>
    /// Sets the game status to Running.
    /// </summary>
    public void StartGame()
    {
        _logger?.Info("Game status: {status}.", GameStatus.Running);
        SetGameStatus(GameStatus.Running);
    }

    /// <summary>
    /// Sets the game status to Finished.
    /// </summary>
    public void EndGame()
    {
        _logger?.Info("Game status: {status}.", GameStatus.Finished);
        SetGameStatus(GameStatus.Finished);
    }

    /// <summary>
    /// Retrieves the current game status.
    /// </summary>
    /// <returns>Current game status.</returns>
    public GameStatus GetCurrentGameStatus()
    {
        _logger?.Info("Get game status: {status}.", _gameStatus);
        return _gameStatus;
    }

    /// <summary>
    /// Sets the current game status.
    /// </summary>
    /// <param name="status">Desired game status.</param>
    /// <returns>True if the game status was successfully set; 
    /// otherwise, an error is thrown.</returns>
    public bool SetGameStatus(GameStatus status)
    {
        _logger?.Info("Set game status from {status} to {newStatus}.", _gameStatus, status);
        _gameStatus = status;
        _logger?.Info("Game status: {status}", _gameStatus);
        return true;
    }

    /// <summary>
    /// Retrieves the current round of the game.
    /// </summary>
    /// <returns>The current round as an integer.</returns>
    public int GetCurrentRound()
    {
        _logger?.Info("Get current round: {round}.", _round);
        return _round;
    }

    /// <summary>
    /// Gets the names of the target instances of a delegate's invocation list.
    /// </summary>
    /// <param name="delegate">The delegate whose invocation list will be checked.</param>
    /// <param name="type">The type of the target instances to be checked.</param>
    /// <returns>A list of names of the target instances of the delegate's invocation list that are of the specified type.</returns>
    public List<string> GetTargetInvoke<T>(Delegate? @delegate)
    {
        _logger?.Info("Delegate type: {delegateType}", @delegate?.GetType());
        List<string> nameTarget = new();
        foreach (var handler in @delegate?.GetInvocationList() ?? Enumerable.Empty<Delegate>())
        {
            if (handler.Target != null)
            {
                // var instance = handler.Target;
                // var nameProperty = type.GetProperty("Name");
                // if (nameProperty != null)
                // {
                //     var name = nameProperty.GetValue(instance) as string;
                //     if (name != null)
                //     {
                //         nameTarget.Add(name);
                //     }
                // }
                var instance = (T)handler.Target;
                if (instance != null)
                {
                    var nameProperty = typeof(T).GetProperty("Name");
                    if (nameProperty != null)
                    {
                        var name = nameProperty.GetValue(instance) as string;
                        if (name != null)
                        {
                            nameTarget.Add(name);
                        }
                    }
                }
            }
        }
        // _logger?.Info("Method to be invoked: {methodNmae}", @delegate?.Method.Name);
        _logger?.Info("Target name: {nameTarget}", nameTarget);
        return nameTarget;
    }

    /// <summary>
    /// Advances the game to the specified round. 
    /// This method sets the game status to Running, 
    /// invokes all card and location special abilities, 
    /// assigns player power to location, 
    /// finds the winner in every location, 
    /// reveals all locations by index below the given round argument, 
    /// and sets player energy by the given round argument.
    /// </summary>
    /// <param name="round">The round to advance to.</param>
    /// <returns>True if the round was successfully advanced; 
    /// otherwise, an error is thrown.</returns>
    public bool NextRound(int round)
    {
        _logger?.Info("Next round from round {round} to {newRound}", _round, round);
        _gameStatus = GameStatus.Running;

        OnRevealLocationAbilityCall?.Invoke(this);
        // GetTargetInvoke(OnRevealLocationAbilityCall, typeof(AbstractLocation));
        OnGoingLocationAbilityCall?.Invoke(this);
        // GetTargetInvoke(OnGoingLocationAbilityCall, typeof(AbstractLocation));
        OnRevealCardAbilityCall?.Invoke(this);
        // GetTargetInvoke(OnRevealCardAbilityCall, typeof(AbstractCard));
        OnGoingCardAbilityCall?.Invoke(this);
        // GetTargetInvoke(OnGoingCardAbilityCall, typeof(AbstractCard));

        AssignPlayerPowerToLocation();
        FindWinnerInLocation();

        _round = round;
        RevealLocation(round, true);
        SetPlayerEnergy(_round);

        _logger?.Info("Game Status: {status}, call location ability on reveal: {onRevealLocCall}, call location ability on going: {onGoingLocCall}",
                        _gameStatus);   //TODO: getinvocationlist
        _logger?.Info("Current round: {round}", _round);
        return true;
    }

    /// <summary>
    /// Advances the game to the specified round. 
    /// This method only reassigns the current round to the given argument.
    /// </summary>
    /// <param name="round">The round to advance to.</param>
    /// <param name="plain">If true, uses this overload method.</param>
    /// <returns>True if the round was successfully set; 
    /// otherwise, an error is thrown.</returns>
    public bool NextRound(int round, bool plain)
    {
        _logger?.Info("Next round from round {round} to {newRound}", _round, round);
        _round = round;
        _logger?.Info("Current round: {round}", _round);
        return true;
    }

    /// <summary>
    /// Advances the game to the next round by incrementing the current round by 1. 
    /// This method automatically calls the game flow.
    /// </summary>
    /// <returns>True if the round was successfully advanced; 
    /// otherwise, an error is thrown.</returns>
    public bool NextRound()
    {
        _logger?.Info("Next round from round {round} to {newRound}", _round, _round + 1);
        _gameStatus = GameStatus.Running;

        OnRevealLocationAbilityCall?.Invoke(this);
        GetTargetInvoke<AbstractLocation>(OnRevealLocationAbilityCall);
        OnGoingLocationAbilityCall?.Invoke(this);
        GetTargetInvoke<AbstractLocation>(OnGoingLocationAbilityCall);
        OnRevealCardAbilityCall?.Invoke(this);
        GetTargetInvoke<AbstractCard>(OnRevealCardAbilityCall);
        OnGoingCardAbilityCall?.Invoke(this);
        GetTargetInvoke<AbstractCard>(OnGoingCardAbilityCall);

        AssignPlayerPowerToLocation();
        FindWinnerInLocation();

        _round += 1;
        RevealLocation(_round);
        SetPlayerEnergy(_round);

        _logger?.Info("Game Status: {status}, call location ability on reveal: {onRevealLocCall}, call location ability on going: {onGoingLocCall}",
                        _gameStatus);   //TODO: return AbstractCard & AbstractLocation for delegate
        _logger?.Info("Current round: {round}", _round);

        return true;
    }

    /// <summary>
    /// Advances the game to the next round by incrementing the current round by 1. 
    /// This method does not call any game flow.
    /// </summary>
    /// <param name="plain">If true, uses this overload method.</param>
    /// <returns>True if the round was successfully advanced; 
    /// otherwise, an error is thrown.</returns>
    public bool NextRound(bool plain)
    {
        _logger?.Info("Next round from round {round} to {newRound}", _round, _round + 1);
        _round += 1;
        _logger?.Info("Current round: {round}", _round);
        return true;
    }

    /// <summary>
    /// Hides the specified location.
    /// </summary>
    /// <param name="location">The location to hide.</param>
    /// <returns>True if the location was successfully hidden; 
    /// otherwise, an error is thrown.</returns>
    public bool HiddenLocation(AbstractLocation location)
    {
        _logger?.Info("Hide location: {location}, hash code: {hashCode}, status: {status}", location, location.GetHashCode(), location.GetLocationStatus());
        OnLocationStatusUpdate?.Invoke(location, LocationStatus.Hidden);
        _logger?.Info("Invoke update location: {location}, hash code: {hashCode}, status: {status}.", location, location.GetHashCode(), LocationStatus.Hidden);
        return location.SetLocationStatus(LocationStatus.Hidden);
    }

    /// <summary>
    /// Reveals the specified location.
    /// </summary>
    /// <param name="location">The location to reveal.</param>
    /// <returns>True if the location was successfully revealed; 
    /// otherwise, an error is thrown.</returns>
    public bool RevealLocation(AbstractLocation location)
    {
        _logger?.Info("Reveal location: {location}, hash code: {hashCode}, status: {status}", location, location.GetHashCode(), location.GetLocationStatus());
        OnLocationStatusUpdate?.Invoke(location, LocationStatus.Revealed);
        _logger?.Info("Invoke update location: {location}, hash code: {hashCode}, status: {status}.", location, location.GetHashCode(), LocationStatus.Revealed);
        return location.SetLocationStatus(LocationStatus.Revealed);
    }

    /// <summary>
    /// Reveals the location at the specified index from the deployed locations. 
    /// If the index is out of maximul deployable location, it returns false. 
    /// The second argument determines whether to loop 
    /// through all indexes below the given index or not.
    /// </summary>
    /// <param name="index">The index of the location in the deployed locations.</param>
    /// <param name="isLoop">Determines whether 
    /// to loop through all indexes below the given index or not.</param>
    /// <returns>True if the location was successfully revealed; otherwise, false.</returns>
    public bool RevealLocation(int index, bool isLoop = false)
    {
        _logger?.Info("Reveal location with or to index: {index}, isLoop: {isLoop}", index, isLoop);
        if (index > _maxLocation)
        {
            _logger?.Warn("Index: {index} is out of maximum deployable locations.", index);
            return false;
        }

        if (!isLoop)
        {
            var currentLocation = GetDeployedLocation(index - 1);
            RevealLocation(currentLocation);
            if (currentLocation._isOnReveal || currentLocation._isOnGoing)
            {
                _logger?.Info("Register ability of {location}.", currentLocation);
                currentLocation.RegisterAbility(this);
            }
            return true;
        }
        else
        {
            for (int i = 0; i < index; i++)
            {
                var currentLocation = GetDeployedLocation(i);
                RevealLocation(currentLocation);
                if (currentLocation._isOnReveal || currentLocation._isOnGoing)
                {
                    _logger?.Info("Register ability of {location}.", currentLocation);
                    currentLocation.RegisterAbility(this);
                }
            }
        }
        return true;
    }

    /// <summary>
    /// Retrieves the maximum round of the game.
    /// </summary>
    /// <returns>The maximum round as an integer.</returns>
    public int GetMaxRound()
    {
        _logger?.Info($"Get max round: {_maxRound}.");
        return _maxRound;
    }

    /// <summary>
    /// Sets the maximum round of the game to the specified value.
    /// </summary>
    /// <param name="maxround">The maximum round to set.</param>
    /// <returns>True if the maximum round was successfully set; 
    /// otherwise, an error is thrown.</returns>
    public bool SetMaxRound(int maxround)
    {
        _logger?.Info($"Set max round from {_maxRound} to {maxround}.");
        _maxRound = maxround;
        return true;
    }

    /// <summary>
    /// Retrieve information about all players.
    /// </summary>
    /// <returns>A dictionary containing player information, with each player as the key and their information as the value</returns>
    public Dictionary<IPlayer, PlayerInfo> GetAllPlayersInfo()
    {
        _logger?.Info("Getting all players info.");
        return _players;
    }

    /// <summary>
    /// Retrieves a list of all players without player infomation.
    /// </summary>
    /// <returns>A list of all players without player information.</returns>
    public List<IPlayer> GetAllPlayers()
    {
        _logger?.Info("Getting all players.");
        return _players.Keys.ToList();
    }

    /// <summary>
    /// Retrieves a player based on the provided player instance.
    /// </summary>
    /// <param name="player">The player instance to search for.</param>
    /// <returns>The found player.</returns>
    /// <exception cref="PlayerNotFoundException">Thrown when the player is not found.</exception>
    public IPlayer GetPlayer(IPlayer player)
    {
        var foundPlayer = GetAllPlayers().Find(p => p.Id == player.Id);
        _logger?.Info($"Find player: {player.Name} by id: {player.Id}.");
        if (foundPlayer == null)
        {
            _logger?.Error($"Player: {player.Name}, id: {player.Id} is not found.");
            throw new Exception("Player not found.");
        }
        return foundPlayer;
    }

    /// <summary>
    /// Retrieves a player based on the provided index from list of all players.
    /// </summary>
    /// <param name="index">The index of the player to retrieve.</param>
    /// <returns>The player at the given index.</returns>
    public IPlayer GetPlayer(int index)
    {
        var getPlayerIndex = GetAllPlayers()[index];
        _logger?.Info($"Get player with index {index} from all players.");
        return getPlayerIndex;
    }

    /// <summary>
    /// Retrieves the information of a player.
    /// </summary>
    /// <param name="player">The player whose information is to be retrieved.</param>
    /// <returns>The information of the player.</returns>
    public PlayerInfo GetPlayerInfo(IPlayer player)
    {
        var getPlayerFromInfo = GetAllPlayersInfo()[player];
        _logger?.Info($"Get player info of player id:{player.Id} from all players info.");
        return getPlayerFromInfo;
    }

    /// <summary>
    /// Assigns player(s) to the game.
    /// </summary>
    /// <param name="players">The player(s) to be assigned.</param>
    /// <returns>True if all players were successfully assigned; 
    /// otherwise, false.</returns>
    public bool AssignPlayer(params IPlayer[] players)
    {
        var newPlayers = players.Where(player => !_players.ContainsKey(player)).ToList();
        _logger?.Info($"Searching new player from [{string.Join(", ", players.Select(p => p.Name))}].");
        _logger?.Info($"Creating List of new player : [{string.Join(", ", newPlayers.Select(p => p.Name))}].");
        newPlayers.ForEach(player => _players.Add(player, new PlayerInfo()));
        newPlayers.ForEach(player =>
        {
            if (player != null)
            {
                OnPlayerUpdate?.Invoke(player, new PlayerInfo());
            }
        });
        _logger?.Info($"Assign every new player to a game, as a key to dictionary with new player info.");
        return newPlayers.Count == players.Length;
    }

    /// <summary>
    /// Removes player(s) from the game.
    /// </summary>
    /// <param name="players">The player(s) to be removed.</param>
    /// <returns>True if all players were successfully removed;
    /// otherwise, false.</returns>
    public bool RemovePlayer(params IPlayer[] players)
    {
        _logger?.Info("Removing players...");
        bool allRemoved = true;
        foreach (var player in players)
        {
            if (!_players.Remove(player))
            {
                _logger?.Info($"Removing player: {player} from game.");
                allRemoved = false;
            }
        }
        return allRemoved;
    }

    /// <summary>
    /// Retrieves the deck of a player.
    /// </summary>
    /// <param name="player">The player whose deck is to be retrieved.</param>
    /// <returns>The deck of the player.</returns>
    public List<AbstractCard> GetPlayerDeck(IPlayer player)
    {
        var getPlayerDeck = GetPlayerInfo(player).GetDeck();
        _logger?.Info($"Getting player deck.");
        return getPlayerDeck;
    }

    /// <summary>
    /// Retrieves a card from a player's deck.
    /// </summary>
    /// <param name="player">The player whose deck is to be searched.</param>
    /// <param name="card">The card to search for.</param>
    /// <param name="byName">If true, search by card name; 
    /// otherwise, search by card instance.</param>
    /// <returns>The found card.</returns>
    /// <exception cref="CardNotFoundException">Thrown when the card is not found.</exception>
    public AbstractCard GetPlayerCardInDeck(IPlayer player, AbstractCard card, bool byName = true)
    {
        var playerDeck = GetPlayerDeck(player);
        var foundCard = playerDeck.Find(c => c.Name == card.Name);
        foundCard = byName ? foundCard : playerDeck.Find(c => c == card);
        _logger?.Info($"Find {card.Name} by name : {byName}.");

        if (foundCard == null)
        {
            _logger?.Error($"Card: {card.Name} is not found.");
            throw new Exception("Card not found.");
        }

        return foundCard;
    }

    /// <summary>
    /// Assigns card(s) to a player's deck.
    /// </summary>
    /// <param name="player">The player to whom the cards will be assigned.</param>
    /// <param name="cards">The card(s) to be assigned.</param>
    /// <returns>True if the cards were successfully assigned; otherwise, false.</returns>
    public bool AssignCardToPlayerDeck(IPlayer player, params AbstractCard[] cards)
    {
        var assignCardToPlayerDeck = GetPlayerInfo(player).AssignCardToDeck(cards);
        _logger?.Info($"Assign card of [{string.Join(", ", cards.Select(c => c.Name))}] to deck player: {player.Name}, id: {player.Id}.");
        return assignCardToPlayerDeck;
    }

    /// <summary>
    /// Assigns cards to a player's deck 
    /// with options to clone cards and search by name.
    /// </summary>
    /// <param name="player">The player to whom the cards will be assigned.</param>
    /// <param name="clone">If true, the cards will be cloned before assignment.</param>
    /// <param name="byName">If true, the cards will be searched by name.</param>
    /// <param name="cards">The card(s) to be assigned.</param>
    /// <returns>True if the cards were successfully assigned; otherwise, false.</returns>
    public bool AssignCardToPlayerDeck(IPlayer player, bool clone = true, bool byName = true, params AbstractCard[] cards)
    {
        _logger?.Info($"Assigning card of [{string.Join(", ", cards.Select(c => c.Name))}] to deck player: {player.Name}, id: {player.Id}...");
        _logger?.Info($"With parameter clone: {clone}, byName: {byName}.");
        bool status = false;

        if (!_players.ContainsKey(player))
        {
            _logger?.Warn($"There is no player id: {player.Id} in [{_players.Keys.Select(p => p.Id)}].");
            return false;
        }

        foreach (var card in cards)
        {
            var cloneCard = clone ? card.Clone() : card;
            status = GetPlayerInfo(player).AssignCardToDeck(cloneCard);
            _logger?.Info($"Assign card: {card.Name} to player: {player.Name}, id: {player.Id} deck.");
            if (status)
            {
                GetPlayerCardInDeck(player, cloneCard, byName).SetCardStatus(CardStatus.OnDeck);
                OnCardStatusUpdate?.Invoke(cloneCard, CardStatus.OnDeck);
                _logger?.Info($"Set card status of {card.Name} to {card.GetCardStatus()}.");
            }
        }
        return status;
    }

    /// <summary>
    /// Removes card(s) from a player's deck.
    /// </summary>
    /// <param name="player">The player whose deck will be searched.</param>
    /// <param name="cards">The card(s) to be removed.</param>
    /// <returns>True if the cards were successfully Removed; otherwise, false.</returns>
    public bool RemovePlayerCardFromDeck(IPlayer player, params AbstractCard[] cards)
    {
        var retrieveCard = GetPlayerInfo(player).RemoveCardFromDeck(cards);
        _logger?.Info($"Retrieve card: [{string.Join(", ", cards.Select(c => c.Name))}].");
        return retrieveCard;
    }

    /// <summary>
    /// Retrieves the cards in a player's hand.
    /// </summary>
    /// <param name="player">The player whose hand will be retrieved.</param>
    /// <returns>A list of cards in the player's hand.</returns>
    public List<AbstractCard> GetPlayerHand(IPlayer player)
    {
        var getHand = GetPlayerInfo(player).GetHandCards();
        _logger?.Info($"Get card in hand player: {player.Name}, id: {player.Id}.");
        return getHand;
    }

    /// <summary>
    /// Retrieves a card from a player's hand.
    /// </summary>
    /// <param name="player">The player whose hand will be searched.</param>
    /// <param name="card">The card to be retrieved.</param>
    /// <param name="byName">If true, the card will be searched by name.</param>
    /// <returns>The found card.</returns>
    /// <exception cref="CardNotFoundException">Thrown when the card is not found.</exception>
    public AbstractCard GetPlayerCardInHand(IPlayer player, AbstractCard card, bool byName = true)
    {
        var playerHand = GetPlayerHand(player);
        var foundCard = playerHand.Find(c => c.Name == card.Name);
        foundCard = byName ? foundCard : playerHand.Find(c => c == card);
        _logger?.Info($"Find {card.Name} by name : {byName} in player id:{player.Id} hand.");

        if (foundCard == null)
        {
            _logger?.Error($"Card: {card.Name} is not found");
            throw new Exception("Card not found.");
        }
        return foundCard;
    }

    /// <summary>
    /// Assigns card(s) to a player's hand.
    /// </summary>
    /// <param name="player">The player to whom the cards will be assigned.</param>
    /// <param name="cards">The card(s) to be assigned.</param>
    /// <returns>True if the cards were successfully assigned; 
    /// otherwise, false.</returns>
    public bool AssignCardToPlayerHand(IPlayer player, params AbstractCard[] cards)
    {
        var assignCardtoHand = GetPlayerInfo(player).AssignCardToHand(cards);
        _logger?.Info($"Assign card: [{string.Join(", ", cards.Select(c => c.Name))}] to player: {player.Name}, id: {player.Id} hand.");
        return assignCardtoHand;
    }

    /// <summary>
    /// Assigns card(s) to a player's hand with options to clone cards 
    /// and search by name. It can also assign cards from the deck.
    /// </summary>
    /// <param name="player">The player to whom the cards will be assigned.</param>
    /// <param name="fromDeck">If true, the cards will be assigned from the deck.</param>
    /// <param name="byDeckName">If true, the cards will be searched in the deck by name.</param>
    /// <param name="clone">If true, the cards will be cloned before assignment.</param>
    /// <param name="byName">If true, the cards will be searched by name.</param>
    /// <param name="cards">The card(s) to be assigned.</param>
    /// <returns>True if the cards were successfully assigned; otherwise, false.</returns>
    public bool AssignCardToPlayerHand(IPlayer player, bool fromDeck = true, bool byDeckName = true,
                                        bool clone = true, bool byName = true,
                                        params AbstractCard[] cards)
    {
        bool status = false;
        if (!_players.ContainsKey(player))
        {
            _logger?.Warn($"There is no player id: {player.Id} in [{_players.Keys.Select(p => p.Id)}].");
            return false;
        }

        foreach (var card in cards)
        {
            //* player hand can have same card
            var cardInDeck = GetPlayerCardInDeck(player, card, byDeckName);
            cardInDeck = fromDeck ? cardInDeck : card;
            var cloneCard = clone ? cardInDeck.Clone() : cardInDeck;
            status = GetPlayerInfo(player).AssignCardToHand(cloneCard);
            _logger?.Info($"Assign card: {cloneCard.Name} to player: {player.Name}, id: {player.Id} hand.");
            if (status)
            {
                GetPlayerCardInHand(player, cloneCard, byName).SetCardStatus(CardStatus.OnHand);
                OnCardStatusUpdate?.Invoke(cloneCard, CardStatus.OnHand);
                _logger?.Info($"Set card status of {card.Name} to {card.GetCardStatus()}.");
            }

        }
        return status;
    }

    /// <summary>
    /// Removes card(s) from a player's hand.
    /// </summary>
    /// <param name="player">The player whose hand the cards will be removed from.</param>
    /// <param name="cards">The card(s) to be removed.</param>
    /// <returns>True if the cards were successfully removed; otherwise, false.</returns>
    public bool RemovePlayerCardFromHand(IPlayer player, params AbstractCard[] cards)
    {
        var RemoveHandCard = GetPlayerInfo(player).RetrieveCardFromHand(cards);
        _logger?.Info($"Retrieveing {player.Name}, id: {player.Id} card: [{cards.Select(c => c.Name)}] from  hand.");
        return RemoveHandCard;
    }

    /// <summary>
    /// Retrieves the energy of a player.
    /// </summary>
    /// <param name="player">The player whose energy is to be retrieved.</param>
    /// <returns>The energy of the player.</returns>
    public int GetPlayerEnergy(IPlayer player)
    {
        var playerEnergy = GetPlayerInfo(player).GetEnergy();
        _logger?.Info($"Get {player.Name}, id: {player.Id} energy: {playerEnergy}..");
        return playerEnergy;
    }

    /// <summary>
    /// Sets the energy of all players to the specified value.
    /// </summary>
    /// <param name="energy">The energy to set.</param>
    public bool SetPlayerEnergy(int energy)
    {
        foreach (var player in GetAllPlayers())
        {
            SetPlayerEnergy(player, energy);
        }
        return true;
    }

    /// <summary>
    /// Sets the energy of a player to the specified value.
    /// </summary>
    /// <param name="player">The player whose energy is to be set.</param>
    /// <param name="energy">The energy to set.</param>
    /// <returns>True if the energy was successfully set for the player.</returns>
    public bool SetPlayerEnergy(IPlayer player, int energy)
    {
        var playerEnergy = GetPlayerInfo(player).SetEnergy(energy);
        _logger?.Info($"Set {player.Name}, id: {player.Id} energy to {energy}.");
        return playerEnergy;
    }

    /// <summary>
    /// Increases the energy of a player by 1.
    /// </summary>
    /// <param name="player">The player whose energy is to be increased.</param>
    /// <returns>True if the energy was successfully increased for the player.</returns>
    public bool AddPlayerEnergy(IPlayer player)
    {
        return SetPlayerEnergy(player, GetPlayerEnergy(player) + 1);
    }

    /// <summary>
    /// Increases the energy of a player by the specified value.
    /// </summary>
    /// <param name="player">The player whose energy is to be increased.</param>
    /// <param name="addEnergy">The amount of energy to add.</param>
    /// <returns>True if the energy was successfully increased for the player.</returns>
    public bool AddPlayerEnergy(IPlayer player, int addEnergy)
    {
        return SetPlayerEnergy(player, GetPlayerEnergy(player) + addEnergy);
    }

    /// <summary>
    /// Retrieves the maximum deck size of a player.
    /// </summary>
    /// <param name="player">The player whose maximum deck size is to be retrieved.</param>
    /// <returns>The maximum deck size of the player.</returns>
    public int GetPlayerMaxDeck(IPlayer player)
    {
        var maxDeck = GetPlayerInfo(player).GetMaxDeck();
        _logger?.Info($"Get {player.Name}, id: {player.Id} max deck: {maxDeck}.");
        return maxDeck;
    }

    /// <summary>
    /// Sets the maximum deck size of a player to the specified value.
    /// </summary>
    /// <param name="player">The player whose maximum deck size is to be set.</param>
    /// <param name="maxDeck">The maximum deck size to set.</param>
    /// <returns>True if the maximum deck size was successfully set for the player.</returns>
    public bool SetPlayerMaxDeck(IPlayer player, int maxDeck)
    {
        var setMaxDeck = GetPlayerInfo(player).SetMaxDeck(maxDeck);
        _logger?.Info($"Set {player.Name}, id: {player.Id} max deck to {maxDeck}.");
        return setMaxDeck;
    }

    /// <summary>
    /// Retrieves the total wins of a player.
    /// </summary>
    /// <param name="player">The player whose total wins are to be retrieved.</param>
    /// <returns>The total wins of the player.</returns>
    public int GetPlayerTotalWin(IPlayer player)
    {
        var totalWin = GetPlayerInfo(player).GetTotalWin();
        _logger?.Info($"Get {player.Name}, id: {player.Id} total win: {totalWin}.");
        return totalWin;
    }

    /// <summary>
    /// Sets the total wins of a player to the specified value.
    /// </summary>
    /// <param name="player">The player whose total wins are to be set.</param>
    /// <param name="totalWin">The total wins to set.</param>
    /// <returns>True if the total wins were successfully set for the player.</returns>
    public bool SetPlayerTotalWin(IPlayer player, int totalWin)
    {
        var setTotalWin = GetPlayerInfo(player).SetTotalWin(totalWin);
        _logger?.Info($"Set {player.Name}, id: {player.Id} total win to {totalWin}.");
        return setTotalWin;
    }

    /// <summary>
    /// Increases the total wins of a player by 1.
    /// </summary>
    /// <param name="player">The player whose total wins are to be increased.</param>
    /// <returns>True if the total wins were successfully increased for the player.</returns>
    public bool AddPlayerTotalWin(IPlayer player)
    {
        var addTotalWin = GetPlayerInfo(player).AddTotalWin();
        _logger?.Info($"Add {player.Name}, id: {player.Id} total win to by one.");
        return addTotalWin;
    }

    /// <summary>
    /// Increases the total wins of a player by the specified value.
    /// </summary>
    /// <param name="player">The player whose total wins are to be increased.</param>
    /// <param name="addWin">The amount of wins to add.</param>
    /// <returns>True if the total wins were successfully increased for the player.</returns>
    public bool AddPlayerTotalWin(IPlayer player, int addWin)
    {
        var addTotalWin = GetPlayerInfo(player).AddTotalWin(addWin);
        _logger?.Info($"Add {player.Name}, id: {player.Id} total win to by {addWin}.");
        return addTotalWin;
    }

    /// <summary>
    /// Retrieves the status of a player.
    /// </summary>
    /// <param name="player">The player whose status is to be retrieved.</param>
    /// <returns>The status of the player.</returns>
    public PlayerStatus GetPlayerStatus(IPlayer player)
    {
        var status = GetPlayerInfo(player).GetPlayerStatus();
        _logger?.Info($"Get {player.Name}, id: {player.Id} status: {status}.");
        return status;
    }

    /// <summary>
    /// Sets the status of a player to the specified value.
    /// </summary>
    /// <param name="player">The player whose status is to be set.</param>
    /// <param name="status">The status to set.</param>
    /// <returns>True if the status was successfully set for the player.</returns>
    public bool SetPlayerStatus(IPlayer player, PlayerStatus status)
    {
        var setStatus = GetPlayerInfo(player).SetPlayerStatus(status);
        OnPlayerStatusUpdate?.Invoke(player, status);
        _logger?.Info($"Set {player.Name}, id: {player.Id} status to {status}.");
        return setStatus;
    }

    /// <summary>
    /// Retrieves all deployed locations.
    /// </summary>
    /// <returns>A list of all deployed locations.</returns>
    public List<AbstractLocation> GetAllDeployedLocations()
    {
        _logger?.Info($"Get all deployed locations.");
        return _locations;
    }

    /// <summary>
    /// Retrieves a deployed location based on the provided location instance.
    /// </summary>
    /// <param name="location">The location instance to search for.</param>
    /// <param name="byName">If true, search by location name; otherwise, search by location instance.</param>
    /// <returns>The found location.</returns>
    /// <exception cref="LocationNotFoundException">Thrown when the location is not found.</exception>
    public AbstractLocation GetDeployedLocation(AbstractLocation location, bool byName = true)
    {
        var deployedLocations = GetAllDeployedLocations();
        var foundLocation = deployedLocations.Find(loc => loc.Name == location.Name);
        foundLocation = byName ? foundLocation : deployedLocations.Find(loc => loc == location);
        _logger?.Info($"Find {location.Name} by name : {byName}.");

        if (foundLocation == null)
        {
            _logger?.Error($"Location: {location.Name} is not found.");
            throw new Exception("Location not found.");
        }
        return foundLocation;
    }

    /// <summary>
    /// Retrieves a deployed location based on the provided index.
    /// </summary>
    /// <param name="index">The index of the location to retrieve.</param>
    /// <returns>The location at the given index.</returns>
    public AbstractLocation GetDeployedLocation(int index)
    {
        var deployedLocation = GetAllDeployedLocations()[index];
        _logger?.Info($"Find location by index : {index} from all deployed locations.");
        return deployedLocation;
    }

    /// <summary>
    /// Assigns location(s) to the game.
    /// </summary>
    /// <param name="locations">The location(s) to be assigned.</param>
    /// <returns>True if all locations were successfully assigned; otherwise, false.</returns>
    public bool AssignLocation(params AbstractLocation[] locations)
    {
        var newLocations = locations.Where(location => !_locations.Contains(location)).ToList();
        newLocations.ForEach(location => _locations.Add(location));
        newLocations.ForEach(location =>
        {
            OnLocationUpdate?.Invoke(location);
        });
        _logger?.Info($"Assign new location of [{string.Join(", ", newLocations.Select(l => l.Name))}].");
        return newLocations.Count == locations.Length;
    }

    //TODO: Async await: foreach, tolist, find, and so on

    /// <summary>
    /// Removes location(s) from the game.
    /// </summary>
    /// <param name="locations">The location(s) to be removed.</param>
    /// <returns>True if all locations were successfully removed; otherwise, false.</returns>
    public bool RemoveLocation(params AbstractLocation[] locations)
    {
        bool allRemoved = true;
        foreach (var location in locations)
        {
            if (!_locations.Remove(location))
            {
                allRemoved = false;
            }
        }
        _logger?.Info($"Removing all location of [{string.Join(", ", locations.Select(l => l.Name))}]: {allRemoved}.");
        return allRemoved;
    }

    /// <summary>
    /// Retrieves the status of a location.
    /// </summary>
    /// <param name="location">The location whose status is to be retrieved.</param>
    /// <returns>The status of the location.</returns>
    public LocationStatus GetLocationStatus(AbstractLocation location)
    {
        _logger?.Info($"Getting {location.Name} status: {location.GetLocationStatus()}.");
        return location.GetLocationStatus();
    }

    /// <summary>
    /// Sets the status of a location to the specified value.
    /// </summary>
    /// <param name="location">The location whose status is to be set.</param>
    /// <param name="status">The status to set.</param>
    /// <returns>True if the status was successfully set for the location.</returns>
    public bool SetLocationStatus(AbstractLocation location, LocationStatus status)
    {
        _logger?.Info($"Set {location.Name} status to {status}.");
        OnLocationStatusUpdate?.Invoke(location, status);
        return location.SetLocationStatus(status);
    }

    /// <summary>
    /// Checks if a location is valid.
    /// </summary>
    /// <param name="location">The location to check.</param>
    /// <returns>True if the location is valid; otherwise, false.</returns>
    public bool IsLocationValid(AbstractLocation location)
    {
        _logger?.Info($"Check location valid: {location.IsLocationValid()}.");
        return location.IsLocationValid();
    }

    /// <summary>
    /// Sets the validity of a location.
    /// </summary>
    /// <param name="location">The location whose validity is to be set.</param>
    /// <param name="isValid">The validity to set.</param>
    /// <returns>True if the validity was successfully set for the location.</returns>
    public bool SetLocationValid(AbstractLocation location, bool isValid)
    {
        _logger?.Info($"Set {location.Name} valid to {isValid}.");
        return location.SetLocationValid(isValid);
    }

    /// <summary>
    /// Retrieves all cards in a location.
    /// </summary>
    /// <param name="location">The location whose cards are to be retrieved.</param>
    /// <returns>A list of all cards in the location.</returns>
    public List<AbstractCard> GetAllCardsInLocation(AbstractLocation location)
    {
        _logger?.Info($"Getting all cards in {location.Name}.");
        return location.GetAllCards();
    }

    /// <summary>
    /// Retrieves a card from a location based on the provided card instance.
    /// </summary>
    /// <param name="location">The location to search for the card.</param>
    /// <param name="card">The card to be retrieved.</param>
    /// <param name="byName">If true, search by card name; otherwise, search by card instance.</param>
    /// <returns>The found card.</returns>
    /// <exception cref="CardNotFoundException">Thrown when the card is not found.</exception>
    public AbstractCard GetCardInLocation(AbstractLocation location, AbstractCard card, bool byName = true)
    {
        var allCardsInLocation = GetAllCardsInLocation(location);
        var foundCard = allCardsInLocation.Find(c => c.Name == card.Name);
        foundCard = byName ? foundCard : allCardsInLocation.Find(c => c == card);
        _logger?.Info($"Find {card.Name} by name : {byName} in {location.Name}.");

        if (foundCard == null)
        {
            _logger?.Error($"Card: {card.Name} is not found.");
            throw new Exception("Card not found.");
        }
        return foundCard;
    }

    /// <summary>
    /// Retrieves a card from a location based on the provided index.
    /// </summary>
    /// <param name="location">The location to search for the card.</param>
    /// <param name="index">The index of the card to retrieve.</param>
    /// <returns>The card at the given index.</returns>
    public AbstractCard GetCardInLocation(AbstractLocation location, int index)
    {
        var cardLocationIndex = GetAllCardsInLocation(location)[index];
        _logger?.Info($"Get card by index: {index} from {location.Name}.");
        return cardLocationIndex;
    }

    /// <summary>
    /// Assigns card(s) to a location.
    /// </summary>
    /// <param name="location">The location to which the cards will be assigned.</param>
    /// <param name="cards">The card(s) to be assigned.</param>
    /// <returns>True if the cards were successfully assigned; otherwise, false.</returns>
    public bool AssignCardToLocation(AbstractLocation location, params AbstractCard[] cards)
    {
        _logger?.Info($"Assigning [{string.Join(", ", cards.Select(c => c.Name))}] cards to {location.Name}.");
        return location.AssignCardToLocation(cards);
    }

    /// <summary>
    /// Removes cards from a location.
    /// </summary>
    /// <param name="location">The location from which the cards will be removed.</param>
    /// <param name="cards">The cards to be removed.</param>
    /// <returns>True if the cards were successfully removed; otherwise, false.</returns>
    public bool RemoveCardFromLocation(AbstractLocation location, params AbstractCard[] cards)
    {
        _logger?.Info($"Removing[{string.Join(", ", cards.Select(c => c.Name))}] from {location.Name}.");
        return location.RemoveCardFromLocation(cards);
    }

    /// <summary>
    /// Retrieves all cards of all players in a location.
    /// </summary>
    /// <param name="location">The location to search for the cards.</param>
    /// <returns>A dictionary with players as keys and their cards in the location as values.</returns>
    public Dictionary<IPlayer, List<AbstractCard>> GetPlayerCardInLocation(AbstractLocation location)
    {
        _logger?.Info($"Getting all player cards in {location.Name}.");
        return location.GetAllPlayersCards();
    }

    /// <summary>
    /// Retrieves all cards of a player in a location.
    /// </summary>
    /// <param name="player">The player whose cards are to be retrieved.</param>
    /// <param name="location">The location to search for the cards.</param>
    /// <returns>A list of all cards of the player in the location.</returns>
    public List<AbstractCard> GetPlayerCardInLocation(IPlayer player, AbstractLocation location)
    {
        _logger?.Info($"Getting {player.Name}, id: {player.Id} card in {location.Name}...");
        return GetPlayerCardInLocation(location)[player];
    }

    /// <summary>
    /// Retrieves a card of a player from a location based on the provided card instance.
    /// </summary>
    /// <param name="player">The player whose card is to be retrieved.</param>
    /// <param name="location">The location to search for the card.</param>
    /// <param name="card">The card to be retrieved.</param>
    /// <param name="byName">If true, search by card name; otherwise, search by card instance.</param>
    /// <returns>The found card.</returns>
    /// <exception cref="CardNotFoundException">Thrown when the card is not found.</exception>
    public AbstractCard GetPlayerCardInLocation(IPlayer player, AbstractLocation location,
                                                AbstractCard card, bool byName = true)
    {
        var playerCards = GetPlayerCardInLocation(player, location);
        var foundCard = playerCards.Find(c => c.Name == card.Name);
        foundCard = byName ? foundCard : playerCards.Find(c => c == card);
        _logger?.Info($"Find {card.Name} by name : {byName} in {location.Name}.");
        if (foundCard == null)
        {
            _logger?.Error($"Card: {card.Name} is not found.");
            throw new Exception("Card not found.");
        }
        return foundCard;
    }

    /// <summary>
    /// Assigns player(s) to a location.
    /// </summary>
    /// <param name="location">The location to which the players will be assigned.</param>
    /// <param name="players">The player(s) to be assigned.</param>
    /// <returns>True if the players were successfully assigned; otherwise, false.</returns>
    public bool AssignPlayerToLocation(AbstractLocation location, params IPlayer[] players)
    {
        _logger?.Info($"Assigning [{string.Join(", ", players.Select(c => c.Name))}] to {location.Name}.");
        location.AssignPlayer(players);
        return true;
    }

    /// <summary>
    /// Removes player(s) from a location.
    /// </summary>
    /// <param name="location">The location from which the players will be removed.</param>
    /// <param name="players">The player(s) to be removed.</param>
    /// <returns>True if the players were successfully removed; otherwise, false.</returns>
    public bool RemovePlayerFromLocation(AbstractLocation location, params IPlayer[] players)
    {
        _logger?.Info($"Removing [{string.Join(", ", players.Select(c => c.Id))}] from {location.Name}.");
        return location.RemovePlayer(players);
    }

    /// <summary>
    /// Retrieves the power of all players in a location.
    /// </summary>
    /// <param name="location">The location to search for the players' power.</param>
    /// <returns>A dictionary with players as keys and their power in the location as values.</returns>
    public Dictionary<IPlayer, int> GetPlayerPowerInLocation(AbstractLocation location)
    {
        _logger?.Info($"Getting all players power in {location.Name}.");
        return location.GetAllPlayersPower();
    }

    /// <summary>
    /// Retrieves the power of a player in a location.
    /// </summary>
    /// <param name="player">The player whose power is to be retrieved.</param>
    /// <param name="location">The location to search for the player's power.</param>
    /// <returns>The power of the player in the location.</returns>
    public int GetPlayerPowerInLocation(IPlayer player, AbstractLocation location)
    {
        _logger?.Info($"Getting {player.Name}, id: {player.Id} power in {location.Name}...");
        return GetPlayerPowerInLocation(location)[player];
    }

    /// <summary>
    /// Assigns the total power of each player's cards 
    /// to each location where the player has cards.
    /// </summary>
    /// <returns>Always returns true when the operation is completed.</returns>
    public bool AssignPlayerPowerToLocation()
    {
        var players = GetAllPlayers();
        var locations = GetAllDeployedLocations();
        foreach (var location in locations)
        {
            foreach (var player in players)
            {
                if (GetPlayerCardInLocation(location).ContainsKey(player))
                {
                    var playerCards = GetPlayerCardInLocation(player, location);
                    var totalPower = 0;

                    foreach (var card in playerCards)
                    {
                        totalPower += card.GetPower();
                    }

                    if (GetPlayerPowerInLocation(location).ContainsKey(player))
                    {
                        AssignPlayerPowerToLocation(player, location, totalPower);
                    }
                    else
                    {
                        GetPlayerPowerInLocation(location).Add(player, totalPower);
                    }
                }
            }
        }

        return true;
    }

    /// <summary>
    /// Assigns power to a player in a location.
    /// </summary>
    /// <param name="player">The player to whom the power will be assigned.</param>
    /// <param name="location">The location where the power will be assigned.</param>
    /// <param name="power">The power to assign.</param>
    /// <returns>True if the power was successfully assigned; otherwise, false.</returns>
    public bool AssignPlayerPowerToLocation(IPlayer player, AbstractLocation location, int power)
    {
        _logger?.Info($"Assigning {player.Name}, id: {player.Id} power: {power} to {location.Name}");
        return location.AssignPlayerPower(player, power);
    }

    /// <summary>
    /// Increases the power of a player in a location by 1.
    /// </summary>
    /// <param name="player">The player whose power is to be increased.</param>
    /// <param name="location">The location where the power will be increased.</param>
    /// <returns>True if the power was successfully increased; otherwise, false.</returns>
    public bool AddPlayerPowerToLocation(IPlayer player, AbstractLocation location)
    {
        _logger?.Info($"Add power of {player.Name}, id: {player.Id} to {location.Name} by one.");
        return location.AddPlayerPower(player, 1);
    }

    /// <summary>
    /// Increases the power of a player in a location by the specified value.
    /// </summary>
    /// <param name="player">The player whose power is to be increased.</param>
    /// <param name="location">The location where the power will be increased.</param>
    /// <param name="powerToAdd">The amount of power to add.</param>
    /// <returns>True if the power was successfully increased; otherwise, false.</returns>
    public bool AddPlayerPowerToLocation(IPlayer player, AbstractLocation location, int powerToAdd)
    {
        _logger?.Info($"Add power of {player.Name}, id: {player.Id} to {location.Name} by {powerToAdd}.");
        return location.AddPlayerPower(player, powerToAdd);
    }

    /// <summary>
    /// Retrieves the status of all players in a location.
    /// </summary>
    /// <param name="location">The location to search for the players' status.</param>
    /// <returns>A dictionary with players as keys and their status in the location as values.</returns>
    public Dictionary<IPlayer, PlayerStatus> GetPlayerStatusInLocation(AbstractLocation location)
    {
        _logger?.Info($"Getting all players status in {location.Name}.");
        return location.GetAllPlayerStatus();
    }

    /// <summary>
    /// Retrieves the status of a player in a location.
    /// </summary>
    /// <param name="player">The player whose status is to be retrieved.</param>
    /// <param name="location">The location to search for the player's status.</param>
    /// <returns>The status of the player in the location.</returns>
    public PlayerStatus GetPlayerStatusInLocation(IPlayer player, AbstractLocation location)
    {
        _logger?.Info($"Getting {player.Name}, id: {player.Id} status in {location.Name}.");
        return GetPlayerStatusInLocation(location)[player];
    }

    /// <summary>
    /// Sets the status of a player in a location to the specified value.
    /// </summary>
    /// <param name="player">The player whose status is to be set.</param>
    /// <param name="location">The location where the status will be set.</param>
    /// <param name="status">The status to set.</param>
    /// <returns>True if the status was successfully set for the player; otherwise, false.</returns>
    public bool SetPlayerStatusInLocation(IPlayer player, AbstractLocation location, PlayerStatus status)
    {
        _logger?.Info($"Set {player.Name}, id: {player.Id} status in {location.Name} to {status}.");
        OnPlayerStatusUpdate?.Invoke(player, status);
        return location.SetPlayerStatus(player, status);
    }

    /// <summary>
    /// Retrieves all players in a location based on the specified source of player information.
    /// </summary>
    /// <param name="location">The location to search for the players.</param>
    /// <param name="infoSource">The source of player information. It can be from cards, power, or status.</param>
    /// <returns>A list of all players in the location based on the specified source of player information.</returns>
    public List<IPlayer> GetAllPlayersInLocation(AbstractLocation location, PlayerInfoSource infoSource = PlayerInfoSource.FromCard)
    {
        switch (infoSource)
        {
            case PlayerInfoSource.FromCard:
                return GetPlayerCardInLocation(location).Keys.ToList();
            case PlayerInfoSource.FromPower:
                return GetPlayerPowerInLocation(location).Keys.ToList();
            case PlayerInfoSource.FromStatus:
                return GetPlayerStatusInLocation(location).Keys.ToList();
            default:
                throw new ArgumentException("Invalid source");
        }
    }

    /// <summary>
    /// Retrieves a player from a location based on the provided player instance.
    /// </summary>
    /// <param name="location">The location to search for the player.</param>
    /// <param name="player">The player to be retrieved.</param>
    /// <returns>The found player.</returns>
    /// <exception cref="PlayerNotFoundException">Thrown when the player is not found.</exception>
    public IPlayer GetPlayerInLocation(AbstractLocation location, IPlayer player)
    {
        var playersInLocation = GetAllPlayersInLocation(location);
        var foundPlayer = playersInLocation.Find(p => p.Id == player.Id);
        _logger?.Info($"Find player: {player.Name} by id: {player.Id}.");

        if (foundPlayer == null)
        {
            _logger?.Error($"Player: {player.Name}, id: {player.Id} is not found.");
            throw new Exception("Player not found.");
        }
        return foundPlayer;
    }

    /// <summary>
    /// Retrieves a player from a location based on the provided index.
    /// </summary>
    /// <param name="location">The location to search for the player.</param>
    /// <param name="index">The index of the player to retrieve.</param>
    /// <returns>The player at the given index.</returns>
    public IPlayer GetPlayerInLocation(AbstractLocation location, int index)
    {
        _logger?.Info($"Getting player in {location.Name} by index: {index}...");
        return GetAllPlayersInLocation(location)[index];
    }

    /// <summary>
    /// Retrieves the maximum deployable location.
    /// </summary>
    /// <returns>The maximum deployable location.</returns>
    public int GetMaxLocation()
    {
        _logger?.Info($"Getting max deployable location: {_maxLocation}.");
        return _maxLocation;
    }

    /// <summary>
    /// Sets the maximum deployable location to the specified value.
    /// </summary>
    /// <param name="maxLocation">The maximum deployable location to set.</param>
    /// <returns>Always returns true when the operation is completed.</returns>
    public bool SetMaxLocation(int maxLocation)
    {
        _maxLocation = maxLocation;
        _logger?.Info($"Set max deployable location to  {maxLocation}.");
        return true;
    }

    /// <summary>
    /// Retrieves all default locations in the game.
    /// </summary>
    /// <returns>A list of all default locations in the game.</returns>
    public List<AbstractLocation> GetDefaultAllLocations()
    {
        _logger?.Info($"Get all default locations in game.");
        return _allLocations;
    }

    /// <summary>
    /// Sets the default location(s) in the game.
    /// </summary>
    /// <param name="locations">The location(s) to set as default.</param>
    /// <returns>True if all locations were successfully set as default; otherwise, false.</returns>
    public bool SetDefaultAllLocations(params AbstractLocation[] locations)
    {
        _logger?.Info($"Set all default location in game: [{string.Join(", ", locations.Select(l => l.Name))}].");
        foreach (var location in locations)
        {
            if (_allLocations.Contains(location))
            {
                continue;
            }
            _allLocations.Add(location);
        }
        return true;
    }

    /// <summary>
    /// Retrieves all default cards in the game.
    /// </summary>
    /// <returns>A list of all default cards in the game.</returns>
    public List<AbstractCard> GetDefaultAllCards()
    {
        _logger?.Info($"Getting all default cards in game.");
        return _allCards;
    }

    /// <summary>
    /// Sets the default card(s) in the game.
    /// </summary>
    /// <param name="cards">The card(s) to set as default.</param>
    /// <returns>True if all cards were successfully set as default; otherwise, false.</returns>
    public bool SetDefaultAllCards(params AbstractCard[] cards)
    {
        _logger?.Info($"Set all default card in game: [{string.Join(", ", cards.Select(c => c.Name))}].");
        foreach (var card in cards)
        {
            if (_allCards.Contains(card))
            {
                continue;
            }
            _allCards.Add(card);
        }
        return true;
    }

    /// <summary>
    /// Retrieves a random card from the default cards in the game.
    /// </summary>
    /// <returns>A random card from the default cards in the game.</returns>
    public AbstractCard GetShuffleCard()
    {
        Random random = new Random();
        var indexCard = random.Next(_allCards.Count);
        _logger?.Info($"Getting shuffle card...");
        return _allCards[indexCard];
    }

    /// <summary>
    /// Retrieves a random location from the default locations in the game.
    /// </summary>
    /// <returns>A random location from the default locations in the game.</returns>
    public AbstractLocation GetShuffleLocation()
    {
        Random random = new Random();
        var indexLocation = random.Next(_allLocations.Count);
        _logger?.Info($"Getting shuffle location...");
        return _allLocations[indexLocation];
    }

    /// <summary>
    /// Retrieves a random index from 0 to the specified maximum value.
    /// </summary>
    /// <param name="max">The maximum value for the random index.</param>
    /// <returns>A random index from 0 to the specified maximum value.</returns>
    public int GetShuffleIndex(int max)
    {
        Random random = new Random();
        _logger?.Info($"Getting shuffle index by max: {max}...");
        return random.Next(max);
    }

    /// <summary>
    /// Assigns a card to a player in a location.
    /// </summary>
    /// <param name="player">The player to whom the card will be assigned.</param>
    /// <param name="card">The card to be assigned.</param>
    /// <param name="location">The location where the card will be assigned.</param>
    /// <returns>True if the card was successfully assigned; otherwise, false.</returns>
    public bool AssignPlayerCardToLocation(IPlayer player, AbstractCard card,
                                            AbstractLocation location)
    {
        if (!_players.ContainsKey(player))
        {
            _logger?.Warn($"There is no player id: {player.Id} in [{_players.Keys.Select(p => p.Id)}].");
            return false;
        }

        if (!GetAllDeployedLocations().Contains(location))
        {
            _logger?.Warn($"There is no {location.Name} in [{GetAllDeployedLocations().Select(l => l.Name)}].");
            return false;
        }

        if (!location.IsLocationValid())
        {
            _logger?.Warn($"the {location.Name} is not valid.");
            return false;
        }

        _logger?.Info($"Assigning {card.Name} to {player.Name}, id: {player.Id} at {location.Name}.");
        return location.AssignPlayerCardToLocation(player, card);
    }

    /// <summary>
    /// Assigns a card to a player in a location with options to clone cards and search by name. It can also assign cards from the hand.
    /// </summary>
    /// <param name="player">The player to whom the card will be assigned.</param>
    /// <param name="card">The card to be assigned.</param>
    /// <param name="location">The location where the card will be assigned.</param>
    /// <param name="fromHand">If true, the card will be assigned from the hand.</param>
    /// <param name="byHandName">If true, the card will be searched in the hand by name.</param>
    /// <param name="clone">If true, the card will be cloned before assignment.</param>
    /// <param name="byName">If true, the card will be searched by name.</param>
    /// <param name="registerAbility">If true, the card's ability will be registered.</param>
    /// <param name="usingEnergy">If true, the card's cost will be checked against the player's energy.</param>
    /// <returns>True if the card was successfully assigned; otherwise, false.</returns>
    public bool AssignPlayerCardToLocation(IPlayer player, AbstractCard card,
                                            AbstractLocation location, bool fromHand = true,
                                            bool byHandName = true, bool clone = true,
                                            bool byName = true,
                                            bool registerAbility = false,
                                            bool usingEnergy = true)
    {
        if (!_players.ContainsKey(player))
        {
            _logger?.Warn($"There is no player id: {player.Id} in [{_players.Keys.Select(p => p.Id)}].");
            return false;
        }

        if (!GetAllDeployedLocations().Contains(location))
        {
            _logger?.Warn($"There is no {location.Name} in [{GetAllDeployedLocations().Select(l => l.Name)}].");
            return false;
        }

        if (!location.IsLocationValid())
        {
            _logger?.Warn($"the {location.Name} is not valid.");
            return false;
        }

        if (usingEnergy)
        {
            if (card.GetCost() > GetPlayerEnergy(player))
            {
                return false;
            }
        }

        var cardInHand = GetPlayerCardInHand(player, card, byHandName);
        cardInHand = fromHand ? cardInHand : card;
        var cloneCard = clone ? cardInHand.Clone() : cardInHand;
        cloneCard.SetCardStatus(CardStatus.OnHand);
        OnCardStatusUpdate?.Invoke(cloneCard, CardStatus.OnHand);
        var status = location.AssignPlayerCardToLocation(player, cloneCard);
        _logger?.Info($"Assigning {card.Name} to {player.Name}, id: {player.Id} at {location.Name}.");

        if (status)
        {
            var cardInLocation = GetPlayerCardInLocation(player, location, cloneCard, byName);
            if (registerAbility)
            {
                if (cardInLocation._isOnReveal || cardInLocation._isOnGoing)
                {
                    _logger?.Info($"Deploy and register {cardInLocation.Name} ability.");
                    cardInLocation.DeployCard(this, player, location);
                    OnCardStatusUpdate?.Invoke(cardInLocation, CardStatus.OnLocation);
                }
            }
            cardInLocation.SetCardStatus(CardStatus.OnLocation);
            OnCardStatusUpdate?.Invoke(cardInLocation, CardStatus.OnLocation);
        }
        return status;
    }

    /// <summary>
    /// Retrieves the player whose turn it is.
    /// </summary>
    /// <returns>The player whose turn it is.</returns>
    public IPlayer GetCurrentTurn()
    {
        _logger?.Info($"Get current turn: {_currentTurn}.");
        return _currentTurn;
    }

    /// <summary>
    /// Sets the turn to the specified player.
    /// </summary>
    /// <param name="player">The player whose turn it will be.</param>
    /// <returns>True if the turn was successfully set to the player; otherwise, false.</returns>
    public bool NextTurn(IPlayer player)
    {
        _currentTurn = player;
        _logger?.Info($"Set current turn to {player.Name}, id: {player.Id}.");
        return true;
    }

    /// <summary>
    /// Sets the turn to the player at the specified index from all players.
    /// </summary>
    /// <param name="index">The index of the player whose turn it will be.</param>
    /// <returns>True if the turn was successfully set to the player; otherwise, false.</returns>
    public bool NextTurn(int index)
    {
        _currentTurn = GetAllPlayers()[index];
        _logger?.Info($"Set current turn to {_currentTurn} by index: {index}");
        return true;
    }

    /// <summary>
    /// Advances the turn to the next player. If the current player is the last in the list, the turn is set to the first player.
    /// </summary>
    /// <returns>True if the turn was successfully advanced; otherwise, false.</returns>
    public bool NextTurn()
    {
        var indexCurrent = GetAllPlayers().IndexOf(GetCurrentTurn());
        var indexNext = indexCurrent + 1;
        if (indexNext > GetAllPlayers().Count - 1)
        {
            indexNext = 0;
        }
        NextTurn(indexNext);
        return true;
    }

    /// <summary>
    /// Retrieves the winner of the game.
    /// </summary>
    /// <returns>The winner of the game.</returns>
    public IPlayer GetWinner()
    {
        _logger?.Info($"Get the winner: {_winner.Name}, id: {_winner.Id}");
        return _winner;
    }

    /// <summary>
    /// Finds the winner in a location based on the player's power.
    /// </summary>
    /// <param name="location">The location to search for the winner.</param>
    /// <returns>The player with the highest power in the location.</returns>
    public IPlayer FindWinnerInLocation(AbstractLocation location)
    {
        _logger?.Info($"Finding winner in {location.Name}...");
        var playersPower = GetPlayerPowerInLocation(location);
        var maxPower = playersPower.Values.Max();
        var minPower = playersPower.Values.Min();

        var winnerPair = playersPower.FirstOrDefault(x => x.Value == maxPower);
        var loserPair = playersPower.FirstOrDefault(x => x.Value == minPower);

        IPlayer winner = winnerPair.Key;
        IPlayer loser = loserPair.Key;

        var playersWithSamePower = playersPower
            .GroupBy(x => x.Value)
            .Where(g => g.Count() > 1)
            .Select(g => new { Power = g.Key, Players = g.Select(p => p.Key).ToList() })
            .ToList();

        foreach (var group in playersWithSamePower)
        {
            foreach (var player in group.Players)
            {
                if (_round < 1)
                {
                    SetPlayerStatusInLocation(player, location, PlayerStatus.None);
                    OnPlayerStatusUpdate?.Invoke(player, PlayerStatus.None);
                }
                else
                {
                    SetPlayerStatusInLocation(player, location, PlayerStatus.Draw);
                    OnPlayerStatusUpdate?.Invoke(player, PlayerStatus.Draw);
                }

            }
        }

        var playersNotInSamePowerGroup = playersPower.Keys
            .Except(playersWithSamePower.SelectMany(g => g.Players)).ToList();

        foreach (var player in playersNotInSamePowerGroup)
        {
            if (player.Equals(winner))
            {
                SetPlayerStatusInLocation(player, location, PlayerStatus.Win);
                OnPlayerStatusUpdate?.Invoke(player, PlayerStatus.Win);
            }
            else if (player.Equals(loser))
            {
                SetPlayerStatusInLocation(player, location, PlayerStatus.Lose);
                OnPlayerStatusUpdate?.Invoke(player, PlayerStatus.Lose);
            }
            else
            {
                SetPlayerStatusInLocation(player, location, PlayerStatus.None);
                OnPlayerStatusUpdate?.Invoke(player, PlayerStatus.None);
            }
        }

        return winner;
    }

    /// <summary>
    /// Finds the winner in all deployed locations.
    /// </summary>
    public void FindWinnerInLocation()
    {
        foreach (var location in GetAllDeployedLocations())
        {
            FindWinnerInLocation(location);
        }
    }

    /// <summary>
    /// Finds the overall winner of the game based on the total wins of each player.
    /// </summary>
    /// <returns>The player with the highest total wins.</returns>
    public IPlayer FindWinner()
    {
        _logger?.Info($"Finding winner...");
        foreach (var player in _players.Keys)
        {
            SetPlayerTotalWin(player, 0);
        }

        foreach (var location in _locations)
        {
            foreach (var player in GetPlayerStatusInLocation(location).Keys)
            {
                if (GetPlayerStatusInLocation(player, location) == PlayerStatus.Win)
                {
                    AddPlayerTotalWin(player, 1);
                }
            }
        }

        IPlayer winner = new MSPlayer(0, "Draw");
        int maxTotalWin = 0;
        foreach (var player in _players.Keys)
        {
            var totalWin = GetPlayerTotalWin(player);
            if (totalWin > maxTotalWin)
            {
                maxTotalWin = totalWin;
                winner = player;
            }
        }

        foreach (var player in _players)
        {
            if (player.Key == winner)
            {
                SetPlayerStatus(player.Key, PlayerStatus.Win);
                OnPlayerStatusUpdate?.Invoke(player.Key, PlayerStatus.Win);
            }
            else
            {
                SetPlayerStatus(player.Key, PlayerStatus.Lose);
                OnPlayerStatusUpdate?.Invoke(player.Key, PlayerStatus.Lose);
            }
        }
        _logger?.Info($"The winner is {winner.Name}, id: {winner.Id}");
        return winner;
    }

    /// <summary>
    /// Sets the winner of the game.
    /// </summary>
    /// <param name="player">The player who won the game.</param>
    /// <returns>True if the winner was successfully set; otherwise, false.</returns>
    public bool SetWinner(IPlayer player)
    {
        _winner = player;
        _logger?.Info($"Set winner to {player.Name}, id: {player.Id}");
        return true;
    }

}
