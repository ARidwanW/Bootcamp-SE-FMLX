using System.CodeDom.Compiler;
using System.Diagnostics;
using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;
using NLog;
using NLog.LayoutRenderers;
using Spectre.Console;

namespace MarvelSnapProject;

public class GameController
{
    /// <summary>
    /// GameController logger instance.
    /// </summary>
    private readonly Logger _logger;
    /// <summary>
    /// Enum GameStatus [None, Running, Finished].
    /// </summary>
    private GameStatus _gameStatus;
    /// <summary>
    /// Round of the game.
    /// </summary>
    private int _round;
    /// <summary>
    /// Maximum round of the game. 
    /// When the game is created, the default is 6 rounds.
    /// </summary>
    private int _maxRound;
    /// <summary>
    /// A Dictionary of players and their info.
    /// PlayerInfo save card in deck and hand, energy, max deck,
    /// total win, and player status.
    /// </summary>
    private Dictionary<IPlayer, PlayerInfo> _players;
    /// <summary>
    /// Deployed locations. Deployed location is
    /// a location used or implemented in the game.
    /// </summary>
    private List<AbstractLocation> _locations;
    /// <summary>
    /// Maximum deployable locations.
    /// The default is 3.
    /// </summary>
    private int _maxLocation = 3;
    /// <summary>
    /// All the locations that the game has.
    /// </summary>
    private List<AbstractLocation> _allLocations;
    /// <summary>
    /// all card that the game has.
    /// </summary>
    private List<AbstractCard> _allCards;
    /// <summary>
    /// Current player turn.
    /// </summary>
    private IPlayer _currentTurn;
    /// <summary>
    /// Winner of the game.
    /// </summary>
    private IPlayer _winner;
    /// <summary>
    /// Handle update to the status of a card.
    /// </summary>
    public Action<AbstractCard, CardStatus>? OnCardStatusUpdate;
    /// <summary>
    /// Handle update to the status of a location.
    /// </summary>
    public Action<AbstractLocation, LocationStatus>? OnLocationStatusUpdate;
    /// <summary>
    /// Handle update to the status of a player.
    /// </summary>
    public Action<IPlayer, PlayerStatus>? OnPlayerStatusUpdate;
    /// <summary>
    /// Handle update to a location.
    /// </summary>
    public Action<AbstractLocation>? OnLocationUpdate;
    /// <summary>
    /// Handle update to a player's information.
    /// </summary>
    public Action<IPlayer, PlayerInfo>? OnPlayerUpdate;
    /// <summary>
    /// Handle on reveal card ability. Default Invoke in method NextRound().
    /// </summary>
    public event Func<GameController, bool>? OnRevealCardAbilityCall;
    /// <summary>
    /// Handle on reveal location ability. Default Invoke in method NextRound().
    /// </summary>
    public event Func<GameController, bool>? OnRevealLocationAbilityCall;
    /// <summary>
    /// Handle on going card ability. Default Invoke in method NextRound().
    /// </summary>
    public event Func<GameController, bool>? OnGoingCardAbilityCall;
    /// <summary>
    /// Handle on going lcoation ability. Default Invoke in method NextRound().
    /// </summary>
    public event Func<GameController, bool>? OnGoingLocationAbilityCall;

    /// <summary>
    /// Contructor of GameController. Will create default parameter to variable.
    /// </summary>
    /// <param name="log">Logger instance like NLog</param>
    public GameController(Logger? log = null)
    {
        _logger = log;
        _logger?.Info("Creating Game...");
        _gameStatus = GameStatus.None;
        _logger?.Info("Set GameStatus to None.");
        _players = new Dictionary<IPlayer, PlayerInfo>();
        _logger?.Info("Create new Dictionary of _players.");
        _locations = new List<AbstractLocation>();
        _logger?.Info("Create new List of _locations.");
        _allLocations = new List<AbstractLocation>();
        _logger?.Info("Create new List of _allLocations.");
        _allCards = new List<AbstractCard>();
        _logger?.Info("Create new List of _allCards.");
        _round = 0;
        _logger?.Info("Set round to 0.");
        _maxRound = 6;
        _logger?.Info("Game created.");
    }

    public void StartGame()
    {
        _logger?.Info("StartGame method has been called.");
        SetGameStatus(GameStatus.Running);
    }

    public void EndGame()
    {
        _logger?.Info("EndGame method has been called.");
        SetGameStatus(GameStatus.Finished);
    }

    public GameStatus GetCurrentGameStatus()
    {
        _logger?.Info($"Get current GameStatus: {_gameStatus}.");
        return _gameStatus;
    }

    public bool SetGameStatus(GameStatus status)
    {
        _gameStatus = status;
        _logger?.Info($"Set GameStatus from {_gameStatus} to {status}.");
        return true;
    }

    public int GetCurrentRound()
    {
        _logger?.Info($"Get current round: {_round}.");
        return _round;
    }

    public bool NextRound(int round)
    {
        _gameStatus = GameStatus.Running;
        _logger?.Info($"Set GameStatus to {_gameStatus}.");

        OnRevealLocationAbilityCall?.Invoke(this);
        _logger?.Info("On reveal location ability has been invoked.");
        OnGoingLocationAbilityCall?.Invoke(this);
        _logger?.Info("On going location ability has been invoked.");
        OnRevealCardAbilityCall?.Invoke(this);
        _logger?.Info("On reveal card ability has been invoked.");
        OnGoingCardAbilityCall?.Invoke(this);
        _logger?.Info("On going card ability has been invoked.");


        AssignPlayerPowerToLocation();
        FindWinnerInLocation();

        _round = round;
        _logger?.Info($"Set round {_round} to {round}.");
        RevealLocation(round, true);
        SetPlayerEnergy(_round);

        return true;
    }

    public bool NextRound(int round, bool plain)
    {
        _round = round;
        _logger?.Info($"Set round {_round} to {round}");
        return true;
    }

    public bool NextRound()
    {
        _gameStatus = GameStatus.Running;
        _logger?.Info($"Set game status to {_gameStatus}");

        OnRevealLocationAbilityCall?.Invoke(this);
        _logger?.Info("On reveal location ability has been invoked.");
        OnGoingLocationAbilityCall?.Invoke(this);
        _logger?.Info("On going location ability has been invoked.");
        OnRevealCardAbilityCall?.Invoke(this);
        _logger?.Info("On reveal card ability has been invoked.");
        OnGoingCardAbilityCall?.Invoke(this);
        _logger?.Info("On going card ability has been invoked.");


        AssignPlayerPowerToLocation();
        FindWinnerInLocation();

        _round += 1;
        _logger?.Info($"Add round by 1, round: {_round}");
        RevealLocation(_round);
        SetPlayerEnergy(_round);

        return true;
    }

    public bool NextRound(bool plain)
    {
        _round += 1;
        _logger?.Info($"Add round by 1, round: {_round}");
        return true;
    }

    public bool HiddenLocation(AbstractLocation location)
    {
        _logger?.Info($"Hide location: {location.Name} with HashCode: {location.GetHashCode()}.");
        return location.SetLocationStatus(LocationStatus.Hidden);
    }

    public bool RevealLocation(AbstractLocation location)
    {
        _logger?.Info($"Reveal location: {location.Name}. with HashCode: {location.GetHashCode()}");
        return location.SetLocationStatus(LocationStatus.Revealed);
    }

    public bool RevealLocation(int index, bool isLoop = false)
    {
        _logger?.Info($"Reveal location from deployed location and register ability...");
        _logger?.Info($"With index: {index} and isLoop: {isLoop}.");
        if (index >= _maxLocation + 1)
        {
            _logger?.Warn("Index for reveal location is out of maximum deployable locations.");
            return false;
        }

        if (!isLoop)
        {
            var currentLocation = GetDeployedLocation(index - 1);
            _logger?.Info($"Reveal location from deployed location, location: {currentLocation.Name}.");
            currentLocation.SetLocationStatus(LocationStatus.Revealed);
            if (currentLocation._isOnReveal || currentLocation._isOnGoing)
            {
                _logger?.Info($"Register ability of {currentLocation.Name}.");
                currentLocation.RegisterAbility(this);
            }
            return true;
        }
        else
        {
            for (int i = 0; i < index; i++)
            {
                var currentLocation = GetDeployedLocation(i);
                _logger?.Info($"Reveal location from deployed location, location: {currentLocation.Name}.");
                currentLocation.SetLocationStatus(LocationStatus.Revealed);
                if (currentLocation._isOnReveal || currentLocation._isOnGoing)
                {
                    _logger?.Info($"Register ability of {currentLocation.Name}.");
                    currentLocation.RegisterAbility(this);
                }
            }
        }
        return true;
    }

    public int GetMaxRound()
    {
        _logger?.Info($"Get max round: {_maxRound}.");
        return _maxRound;
    }

    public bool SetMaxRound(int maxround)
    {
        _logger?.Info($"Set max round from {_maxRound} to {maxround}.");
        _maxRound = maxround;
        return true;
    }

    public Dictionary<IPlayer, PlayerInfo> GetAllPlayersInfo()
    {
        _logger?.Info("Getting all players info.");
        return _players;
    }

    public List<IPlayer> GetAllPlayers()
    {
        _logger?.Info("Getting all players.");
        return _players.Keys.ToList();
    }

    public IPlayer GetPlayer(IPlayer player)
    {
        var foundPlayer = GetAllPlayers().Find(p => p.Id == player.Id);
        _logger?.Info($"Find player: {player.Name} by id: {player.Id}.");
        if (foundPlayer == null)
        {
            _logger?.Warn($"No found player of {player.Name} with id: {player.Id}.");
            _logger?.Warn($"Instead, A new player create with index 0 and player name of None.");
            return new MSPlayer(0, "None");
        }
        return foundPlayer;
    }

    public IPlayer GetPlayer(int index)
    {
        var getPlayerIndex = GetAllPlayers()[index];
        _logger?.Info($"Get player with index {index} from all players.");
        return getPlayerIndex;
    }

    public PlayerInfo GetPlayerInfo(IPlayer player)
    {
        var getPlayerFromInfo = GetAllPlayersInfo()[player];
        _logger?.Info($"Get player info of player id:{player.Id} from all players info.");
        return getPlayerFromInfo;
    }

    public IPlayer CreatePlayer(int id, string name)
    {
        _logger?.Info($"Creating new MSPlayer by id: {id}, name: {name}.");
        return new MSPlayer(id, name);
    }

    public bool AssignPlayer(params IPlayer[] players)
    {
        var newPlayers = players.Where(player => !_players.ContainsKey(player)).ToList();
        _logger?.Info($"Searching new player from [{string.Join(", ", players.Select(p => p.Name))}].");
        _logger?.Info($"Creating List of new player : [{string.Join(", ", newPlayers.Select(p => p.Name))}].");
        newPlayers.ForEach(player => _players.Add(player, new PlayerInfo()));
        _logger?.Info($"Assign every new player to a game, as a key to dictionary with new player info.");
        return newPlayers.Count == players.Length;
    }

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

    public List<AbstractCard> GetPlayerDeck(IPlayer player)
    {
        var getPlayerDeck = GetPlayerInfo(player).GetDeck();
        _logger?.Info($"Getting player deck.");
        return getPlayerDeck;
    }

    public AbstractCard GetPlayerCardInDeck(IPlayer player, AbstractCard card, bool byName = true)
    {
        var playerDeck = GetPlayerDeck(player);
        var foundCard = playerDeck.Find(c => c.Name == card.Name);
        foundCard = byName ? foundCard : playerDeck.Find(c => c == card);
        _logger?.Info($"Find {card.Name} by name : {byName}.");

        if (foundCard == null)
        {
            _logger?.Warn($"No card found. Instead, create a new NoneCard.");
            return new NoneCard();
        }

        return foundCard;
    }

    public bool AssignCardToPlayerDeck(IPlayer player, params AbstractCard[] cards)
    {
        var assignCardToPlayerDeck = GetPlayerInfo(player).AssignCardToDeck(cards);
        _logger?.Info($"Assign card of [{string.Join(", ", cards.Select(c => c.Name))}] to deck player: {player.Name}, id: {player.Id}.");
        return assignCardToPlayerDeck;
    }

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
                GetPlayerCardInDeck(player, card, byName).SetCardStatus(CardStatus.OnDeck);
                _logger?.Info($"Set card status of {card.Name} to {card.GetCardStatus()}.");
            }
        }
        return status;
    }

    public bool RetrievePlayerCardFromDeck(IPlayer player, params AbstractCard[] cards)
    {
        var retrieveCard = GetPlayerInfo(player).RetrieveCardFromDeck(cards);
        _logger?.Info($"Retrieve card: [{string.Join(", ", cards.Select(c => c.Name))}].");
        return retrieveCard;
    }

    public List<AbstractCard> GetPlayerHand(IPlayer player)
    {
        var getHand = GetPlayerInfo(player).GetHandCards();
        _logger?.Info($"Get card in hand player: {player.Name}, id: {player.Id}.");
        return getHand;
    }

    public AbstractCard GetPlayerCardInHand(IPlayer player, AbstractCard card, bool byName = true)
    {
        var playerHand = GetPlayerHand(player);
        var foundCard = playerHand.Find(c => c.Name == card.Name);
        foundCard = byName ? foundCard : playerHand.Find(c => c == card);
        _logger?.Info($"Find {card.Name} by name : {byName} in player id:{player.Id} hand.");

        if (foundCard == null)
        {
            _logger?.Warn($"No card found. Instead, create a new NoneCard.");
            return new NoneCard();
        }
        return foundCard;
    }

    public bool AssignCardToPlayerHand(IPlayer player, params AbstractCard[] cards)
    {
        var assignCardtoHand = GetPlayerInfo(player).AssignCardToHand(cards);
        _logger?.Info($"Assign card: [{string.Join(", ", cards.Select(c => c.Name))}] to player: {player.Name}, id: {player.Id} hand.");
        return assignCardtoHand;
    }

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
                GetPlayerCardInHand(player, cardInDeck, byName).SetCardStatus(CardStatus.OnHand);
                _logger?.Info($"Set card status of {card.Name} to {card.GetCardStatus()}.");
            }

        }
        return status;
    }

    public bool RetrievePlayerCardFromHand(IPlayer player, params AbstractCard[] cards)
    {
        var retrieveHandCard = GetPlayerInfo(player).RetrieveCardFromHand(cards);
        _logger?.Info($"Retrieveing {player.Name}, id: {player.Id} card: [{cards.Select(c => c.Name)}] from  hand.");
        return retrieveHandCard;
    }

    public int GetPlayerEnergy(IPlayer player)
    {
        var playerEnergy = GetPlayerInfo(player).GetEnergy();
        _logger?.Info($"Get {player.Name}, id: {player.Id} energy: {playerEnergy}..");
        return playerEnergy;
    }

    public bool SetPlayerEnergy(int energy)
    {
        foreach (var player in GetAllPlayers())
        {
            SetPlayerEnergy(player, energy);
        }
        return true;
    }

    public bool SetPlayerEnergy(IPlayer player, int energy)
    {
        var playerEnergy = GetPlayerInfo(player).SetEnergy(energy);
        _logger?.Info($"Set {player.Name}, id: {player.Id} energy to {energy}.");
        return playerEnergy;
    }

    public bool AddPlayerEnergy(IPlayer player)
    {
        return SetPlayerEnergy(player, GetPlayerEnergy(player) + 1);
    }

    public bool AddPlayerEnergy(IPlayer player, int addEnergy)
    {
        return SetPlayerEnergy(player, GetPlayerEnergy(player) + addEnergy);
    }

    public int GetPlayerMaxDeck(IPlayer player)
    {
        var maxDeck = GetPlayerInfo(player).GetMaxDeck();
        _logger?.Info($"Get {player.Name}, id: {player.Id} max deck: {maxDeck}.");
        return maxDeck;
    }

    public bool SetPlayerMaxDeck(IPlayer player, int maxDeck)
    {
        var setMaxDeck = GetPlayerInfo(player).SetMaxDeck(maxDeck);
        _logger?.Info($"Set {player.Name}, id: {player.Id} max deck to {maxDeck}.");
        return setMaxDeck;
    }

    public int GetPlayerTotalWin(IPlayer player)
    {
        var totalWin = GetPlayerInfo(player).GetTotalWin();
        _logger?.Info($"Get {player.Name}, id: {player.Id} total win: {totalWin}.");
        return totalWin;
    }

    public bool SetPlayerTotalWin(IPlayer player, int totalWin)
    {
        var setTotalWin = GetPlayerInfo(player).SetTotalWin(totalWin);
        _logger?.Info($"Set {player.Name}, id: {player.Id} total win to {totalWin}.");
        return setTotalWin;
    }

    public bool AddPlayerTotalWin(IPlayer player)
    {
        var addTotalWin = GetPlayerInfo(player).AddTotalWin();
        _logger?.Info($"Add {player.Name}, id: {player.Id} total win to by one.");
        return addTotalWin;
    }

    public bool AddPlayerTotalWin(IPlayer player, int addWin)
    {
        var addTotalWin = GetPlayerInfo(player).AddTotalWin(addWin);
        _logger?.Info($"Add {player.Name}, id: {player.Id} total win to by {addWin}.");
        return addTotalWin;
    }

    public PlayerStatus GetPlayerStatus(IPlayer player)
    {
        var status = GetPlayerInfo(player).GetPlayerStatus();
        _logger?.Info($"Get {player.Name}, id: {player.Id} status: {status}.");
        return status;
    }

    public bool SetPlayerStatus(IPlayer player, PlayerStatus status)
    {
        var setStatus = GetPlayerInfo(player).SetPlayerStatus(status);
        _logger?.Info($"Set {player.Name}, id: {player.Id} status to {status}.");
        return setStatus;
    }

    public List<AbstractLocation> GetAllDeployedLocations()
    {
        _logger?.Info($"Get all deployed locations.");
        return _locations;
    }

    public AbstractLocation GetDeployedLocation(AbstractLocation location, bool byName = true)
    {
        var deployedLocations = GetAllDeployedLocations();
        var foundLocation = deployedLocations.Find(loc => loc.Name == location.Name);
        foundLocation = byName ? foundLocation : deployedLocations.Find(loc => loc == location);
        _logger?.Info($"Find {location.Name} by name : {byName}.");

        if (foundLocation == null)
        {
            _logger?.Warn($"No location found. Instead, create a new NoneLocation.");
            return new NoneLocation();
        }
        return foundLocation;
    }

    public AbstractLocation GetDeployedLocation(int index)
    {
        var deployedLocation = GetAllDeployedLocations()[index];
        _logger?.Info($"Find location by index : {index} from all deployed locations.");
        return deployedLocation;
    }

    public bool AssignLocation(params AbstractLocation[] locations)
    {
        var newLocations = locations.Where(location => !_locations.Contains(location)).ToList();
        newLocations.ForEach(location => _locations.Add(location));
        _logger?.Info($"Assign new location of [{string.Join(", ", newLocations.Select(l => l.Name))}].");
        return newLocations.Count == locations.Length;
    }

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

    public LocationStatus GetLocationStatus(AbstractLocation location)
    {
        _logger?.Info($"Getting {location.Name} status: {location.GetLocationStatus()}.");
        return location.GetLocationStatus();
    }

    public bool SetLocationStatus(AbstractLocation location, LocationStatus status)
    {
        _logger?.Info($"Set {location.Name} status to {status}.");
        return location.SetLocationStatus(status);
    }

    public bool IsLocationValid(AbstractLocation location)
    {
        _logger?.Info($"Check location valid: {location.IsLocationValid()}.");
        return location.IsLocationValid();
    }

    public bool SetLocationValid(AbstractLocation location, bool isValid)
    {
        _logger?.Info($"Set {location.Name} valid to {isValid}.");
        return location.SetLocationValid(isValid);
    }

    public List<AbstractCard> GetAllCardsInLocation(AbstractLocation location)
    {
        _logger?.Info($"Getting all cards in {location.Name}.");
        return location.GetAllCards();
    }

    public AbstractCard GetCardInLocation(AbstractLocation location, AbstractCard card, bool byName = true)
    {
        var allCardsInLocation = GetAllCardsInLocation(location);
        var foundCard = allCardsInLocation.Find(c => c.Name == card.Name);
        foundCard = byName ? foundCard : allCardsInLocation.Find(c => c == card);
        _logger?.Info($"Find {card.Name} by name : {byName} in {location.Name}.");

        if (foundCard == null)
        {
            _logger?.Warn($"No card found. Instead, create a new NoneCard.");
            return new NoneCard();
        }
        return foundCard;
    }

    public AbstractCard GetCardInLocation(AbstractLocation location, int index)
    {
        var cardLocationIndex = GetAllCardsInLocation(location)[index];
        _logger?.Info($"Get card by index: {index} from {location.Name}.");
        return cardLocationIndex;
    }

    public bool AssignCardToLocation(AbstractLocation location, params AbstractCard[] cards)
    {
        _logger?.Info($"Assigning [{string.Join(", ", cards.Select(c => c.Name))}] cards to {location.Name}.");
        return location.AssignCardToLocation(cards);
    }

    public Dictionary<IPlayer, List<AbstractCard>> GetPlayerCardInLocation(AbstractLocation location)
    {
        _logger?.Info($"Getting all player cards in {location.Name}.");
        return location.GetAllPlayersCards();
    }

    public List<AbstractCard> GetPlayerCardInLocation(IPlayer player, AbstractLocation location)
    {
        _logger?.Info($"Getting {player.Name}, id: {player.Id} card in {location.Name}...");
        return GetPlayerCardInLocation(location)[player];
    }

    public AbstractCard GetPlayerCardInLocation(IPlayer player, AbstractLocation location,
                                                AbstractCard card, bool byName = true)
    {
        var playerCards = GetPlayerCardInLocation(player, location);
        var foundCard = playerCards.Find(c => c.Name == card.Name);
        foundCard = byName ? foundCard : playerCards.Find(c => c == card);
        _logger?.Info($"Find {card.Name} by name : {byName} in {location.Name}.");
        if (foundCard == null)
        {
            _logger?.Warn($"No card found. Instead, create a new NoneCard.");
            return new NoneCard();
        }
        return foundCard;
    }

    public bool AssignPlayerToLocation(AbstractLocation location, params IPlayer[] players)
    {
        _logger?.Info($"Assigning [{string.Join(", ", players.Select(c => c.Name))}] to {location.Name}.");
        location.AssignPlayer(players);
        return true;
    }

    public Dictionary<IPlayer, int> GetPlayerPowerInLocation(AbstractLocation location)
    {
        _logger?.Info($"Getting all players power in {location.Name}.");
        return location.GetAllPlayersPower();
    }

    public int GetPlayerPowerInLocation(IPlayer player, AbstractLocation location)
    {
        _logger?.Info($"Getting {player.Name}, id: {player.Id} power in {location.Name}...");
        return GetPlayerPowerInLocation(location)[player];
    }

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

    public bool AssignPlayerPowerToLocation(IPlayer player, AbstractLocation location, int power)
    {
        _logger?.Info($"Assigning {player.Name}, id: {player.Id} power: {power} to {location.Name}");
        return location.AssignPlayerPower(player, power);
    }

    public bool AddPlayerPowerToLocation(IPlayer player, AbstractLocation location)
    {
        _logger?.Info($"Add power of {player.Name}, id: {player.Id} to {location.Name} by one.");
        return location.AddPlayerPower(player, 1);
    }

    public bool AddPlayerPowerToLocation(IPlayer player, AbstractLocation location, int powerToAdd)
    {
        _logger?.Info($"Add power of {player.Name}, id: {player.Id} to {location.Name} by {powerToAdd}.");
        return location.AddPlayerPower(player, powerToAdd);
    }

    public Dictionary<IPlayer, PlayerStatus> GetPlayerStatusInLocation(AbstractLocation location)
    {
        _logger?.Info($"Getting all players status in {location.Name}.");
        return location.GetAllPlayerStatus();
    }

    public PlayerStatus GetPlayerStatusInLocation(IPlayer player, AbstractLocation location)
    {
        _logger?.Info($"Getting {player.Name}, id: {player.Id} status in {location.Name}.");
        return GetPlayerStatusInLocation(location)[player];
    }

    public bool SetPlayerStatusInLocation(IPlayer player, AbstractLocation location, PlayerStatus status)
    {
        _logger?.Info($"Set {player.Name}, id: {player.Id} status in {location.Name} to {status}.");
        return location.SetPlayerStatus(player, status);
    }

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

    public IPlayer GetPlayerInLocation(AbstractLocation location, IPlayer player)
    {
        var playersInLocation = GetAllPlayersInLocation(location);
        var foundPlayer = playersInLocation.Find(p => p.Id == player.Id);
        _logger?.Info($"Find player: {player.Name} by id: {player.Id}.");

        if (foundPlayer == null)
        {
            _logger?.Warn($"No found player of {player.Name} with id: {player.Id}.");
            _logger?.Warn($"Instead, A new player create with index 0 and player name of None.");
            return new MSPlayer(0, "None");
        }
        return foundPlayer;
    }

    public IPlayer GetPlayerInLocation(AbstractLocation location, int index)
    {
        _logger?.Info($"Getting player in {location.Name} by index: {index}...");
        return GetAllPlayersInLocation(location)[index];
    }

    public int GetMaxLocation()
    {
        _logger?.Info($"Getting max deployable location: {_maxLocation}.");
        return _maxLocation;
    }

    public bool SetMaxLocation(int maxLocation)
    {
        _maxLocation = maxLocation;
        _logger?.Info($"Set max deployable location to  {maxLocation}.");
        return true;
    }

    public List<AbstractLocation> GetDefaultAllLocations()
    {
        _logger?.Info($"Get all default locations in game.");
        return _allLocations;
    }

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

    public List<AbstractCard> GetDefaultAllCards()
    {
        _logger?.Info($"Getting all default cards in game.");
        return _allCards;
    }

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

    public AbstractCard GetShuffleCard()
    {
        Random random = new Random();
        var indexCard = random.Next(_allCards.Count);
        _logger?.Info($"Getting shuffle card...");
        return _allCards[indexCard];
    }

    public AbstractLocation GetShuffleLocation()
    {
        Random random = new Random();
        var indexLocation = random.Next(_allLocations.Count);
        _logger?.Info($"Getting shuffle location...");
        return _allLocations[indexLocation];
    }

    public int GetShuffleIndex(int max)
    {
        Random random = new Random();
        _logger?.Info($"Getting shuffle index by max: {max}...");
        return random.Next(max);
    }

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
                }
            }
        }
        return status;
    }

    public IPlayer GetCurrentTurn()
    {
        _logger?.Info($"Get current turn: {_currentTurn}.");
        return _currentTurn;
    }

    public bool NextTurn(IPlayer player)
    {
        _currentTurn = player;
        _logger?.Info($"Set current turn to {player.Name}, id: {player.Id}.");
        return true;
    }

    public bool NextTurn(int index)
    {
        _currentTurn = GetAllPlayers()[index];
        _logger?.Info($"Set current turn to {_currentTurn} by index: {index}");
        return true;
    }

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

    public IPlayer GetWinner()
    {
        _logger?.Info($"Get the winner: {_winner.Name}, id: {_winner.Id}");
        return _winner;
    }

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
                }
                else
                {
                    SetPlayerStatusInLocation(player, location, PlayerStatus.Draw);
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
            }
            else if (player.Equals(loser))
            {
                SetPlayerStatusInLocation(player, location, PlayerStatus.Lose);
            }
            else
            {
                SetPlayerStatusInLocation(player, location, PlayerStatus.None);
            }
        }

        return winner;
    }

    public void FindWinnerInLocation()
    {
        foreach (var location in GetAllDeployedLocations())
        {
            FindWinnerInLocation(location);
        }
    }

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
            }
            else
            {
                SetPlayerStatus(player.Key, PlayerStatus.Lose);
            }
        }
        _logger?.Info($"The winner is {winner.Name}, id: {winner.Id}");
        return winner;
    }

    public bool SetWinner(IPlayer player)
    {
        _winner = player;
        _logger?.Info($"Set winner to {player.Name}, id: {player.Id}");
        return true;
    }

}
