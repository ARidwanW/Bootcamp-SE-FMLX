using System.CodeDom.Compiler;
using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;
using NLog;
using NLog.LayoutRenderers;

namespace MarvelSnapProject;

public class GameController
{
    private readonly Logger _logger;
    private GameStatus _gameStatus;
    private int _round;
    private Dictionary<IPlayer, PlayerInfo> _players;
    private List<AbstractLocation> _locations;
    private List<AbstractLocation> _allLocations;
    private List<AbstractCard> _allCards;
    private IPlayer _currentTurn;
    private IPlayer _winner;
    public Action<AbstractCard, CardStatus>? OnCardStatusUpdate;
    public Action<AbstractLocation, LocationStatus>? OnLocationStatusUpdate;
    public Action<AbstractLocation>? OnLocationUpdate;
    public Action<IPlayer, PlayerStatus>? OnPlayerStatusUpdate;
    public Action<IPlayer, PlayerInfo>? OnPlayerUpdate;
    public event Func<GameController, bool>? OnRevealCardAbilityCall;        // invoke every round, chek apakah ada sub, jika iya bakal di invoke dan chek apakah roundnya sudah selanjutnya
    public event Func<GameController, bool>? OnRevealLocationAbilityCall;
    public event Func<GameController, bool>? OnGoingCardAbilityCall;
    public event Func<GameController, bool>? OnGoingLocationAbilityCall;


    public GameController(Logger? log = null)
    {
        _logger = log;
        _gameStatus = GameStatus.None;
        _players = new Dictionary<IPlayer, PlayerInfo>();
        _locations = new List<AbstractLocation>();
        _allLocations = new List<AbstractLocation>();
        _allCards = new List<AbstractCard>();
        _round = 0;

        _logger?.Info("Game created");
    }

    public GameStatus GetCurrentGameStatus()
    {
        return _gameStatus;
    }

    public bool SetGameStatus(GameStatus status)
    {
        _gameStatus = status;
        return true;
    }

    public int GetCurrentRound()
    {
        return _round;
    }

    public bool NextRound()
    {
        _gameStatus = GameStatus.Running;
        OnRevealCardAbilityCall?.Invoke(this);
        OnGoingCardAbilityCall?.Invoke(this);
        OnRevealLocationAbilityCall?.Invoke(this);
        OnGoingLocationAbilityCall?.Invoke(this);
        _round += 1;
        return true;
    }

    public bool AssignPlayer(params IPlayer[] players)
    {
        int status = 0;
        foreach (IPlayer player in players)
        {
            if (_players.ContainsKey(player))
            {
                status++;
                continue;
            }
            _players.Add(player, new PlayerInfo());
        }
        return (status > 0) ? false : true;
    }

    public bool RemovePlayer(params IPlayer[] players)
    {
        return true;
    }

    public IPlayer GetPlayer(int index)
    {
        return _players.Keys.ToList()[index];
    }

    public List<IPlayer> GetAllPlayers()
    {
        List<IPlayer> players = _players.Keys.ToList();
        return players;
    }

    public Dictionary<IPlayer, PlayerInfo> GetAllPlayersInfo()
    {
        return _players;
    }

    public PlayerInfo GetPlayerInfo(IPlayer player)
    {
        return _players[player];
    }

    public List<AbstractCard> GetPlayerDeck(IPlayer player)
    {
        return _players[player].GetDeck();
    }

    public AbstractCard GetPlayerCardInDeck(IPlayer player, AbstractCard card)
    {
        return GetPlayerDeck(player).Find(c => c.Name == card.Name);
    }

    public List<AbstractCard> GetPlayerHand(IPlayer player)
    {
        return _players[player].GetHandCards();
    }

    public AbstractCard GetPlayerCardInHand(IPlayer player, AbstractCard card)
    {
        return GetPlayerHand(player).Find(c => c.Name == card.Name);
    }

    public List<AbstractCard> GetPlayerCardsInLocation(IPlayer player, AbstractLocation location)
    {
        return location.GetPlayerCards(player);
    }

    public AbstractCard GetPlayerCardInLocation(IPlayer player, AbstractLocation location, AbstractCard card)
    {
        return GetPlayerCardsInLocation(player, location).Find(c => c.Name == card.Name);
    }

    public List<AbstractLocation> GetAllDeployedLocations()
    {
        return _locations;
    }

    public AbstractLocation GetLocation(AbstractLocation location)
    {
        return _locations.Find(loc => loc == location);
    }

    public AbstractLocation GetLocation(int index)
    {
        return _locations[index];
    }

    public bool AssignLocation(params AbstractLocation[] locations)
    {
        foreach (var location in locations)
        {
            if (!_locations.Contains(location))
            {
                _locations.Add(location);
            }
        }
        return true;
    }

    public List<AbstractLocation> GetDefaultAllLocations()
    {
        return _allLocations;
    }

    public bool GenerateDefaultAllLocation()
    {
        // Asgard = 1
        // Atlantis = 2
        // AvengerCompound = 4
        // Flooded = 6
        // KunLun = 7
        // NegativeZone = 8
        // Ruins = 9
        List<AbstractLocation> locations = new List<AbstractLocation>()
        {
        new Asgard(),
        new Atlantis(),
        new AvengersCompound(),
        new Flooded(),
        new KunLun(),
        new NegativeZone(),
        new Ruins(),
        };

        foreach (var location in locations)
        {
            SetDefaultAllLocations(location);
        }
        return true;
    }

    public bool SetDefaultAllLocations(params AbstractLocation[] locations)
    {
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
        return _allCards;
    }

    public bool GenerateDefaultAllCards()
    {
        // Abomination = 1
        // Cyclops = 2
        // Howkeye = 3
        // Hulk = 4
        // IronMan = 5
        // JessicaJones = 6
        // Medusa = 7
        // MisterFantastic = 8
        // MistyKnight = 9
        // QuickSilver = 10
        // Sentinel = 11
        // Spectrum = 12
        // StarLord = 13
        // ThePunisher = 14
        // Thing = 15
        // WhiteTiger = 16
        List<AbstractCard> cards = new List<AbstractCard>()
        {
            new Abomination(),
            new Cyclops(),
            new Hawkeye(),
            new Hulk(),
            new IronMan(),
            new JessicaJones(),
            new Medusa(),
            new MisterFantastic(),
            new MistyKnight(),
            new QuickSilver(),
            new Sentinel(),
            new Spectrum(),
            new StarLord(),
            new ThePunisher(),
            new Thing(),
            new WhiteTiger()
        };

        foreach (var card in cards)
        {
            SetDefaultAllCards(card);
        }
        return true;
    }

    public bool SetDefaultAllCards(params AbstractCard[] cards)
    {
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
        return _allCards[indexCard];
    }

    public int GetShuffleIndex(int max)
    {
        Random random = new Random();
        return random.Next(max);
    }

    public bool AssignCardToPlayerDeck(IPlayer player, params AbstractCard[] cards)
    {
        bool status = false;
        if (!_players.ContainsKey(player))
        {
            return false;
        }

        foreach (var card in cards)
        {
            status = _players[player].AssignCardToDeck(card.Clone());
            if (status)
            {
                GetPlayerCardInDeck(player, card).SetCardStatus(CardStatus.OnDeck);
            }
        }

        return status;
    }

    public bool AssignCardToPlayerHand(IPlayer player, params AbstractCard[] cards)
    {
        bool status = false;
        if (!_players.ContainsKey(player))
        {
            return false;
        }

        foreach (var card in cards)
        {
            //* player hand can have same card
            var cardInDeck = GetPlayerDeck(player).Find(c => c.Name == card.Name);
            status = _players[player].AssignCardToHand(cardInDeck);
            if (status)
            {
                GetPlayerCardInHand(player, cardInDeck).SetCardStatus(CardStatus.OnHand);
            }

        }
        return status;
    }

    public bool AssignPlayerCardToLocation(IPlayer player, AbstractCard card, AbstractLocation location)
    {
        if (!_players.ContainsKey(player))
        {
            return false;
        }

        if (!GetAllDeployedLocations().Contains(location))
        {
            return false;
        }

        if (!location.IsLocationValid())
        {
            return false;
        }

        var cardInHand = GetPlayerCardInHand(player, card);
        var status = location.AssignPlayerCardToLocation(player, cardInHand);
        if (status)
        {
            GetPlayerCardInLocation(player, location, cardInHand).SetCardStatus(CardStatus.OnLocation);
            var cardInLocation = GetPlayerCardInLocation(player, location, cardInHand);
            if (cardInLocation._isOnReveal || cardInLocation._isOnGoing)
            {
                cardInLocation.DeployCard(this, player, location);
            }
        }
        // GetPlayerInfo(player).RetrieveCardFromHand(card);

        return status;
    }

    public IPlayer GetCurrentTurn()
    {
        return _currentTurn;
    }

    public bool SetTurn(IPlayer player)
    {
        _currentTurn = player;
        return true;
    }

    public bool SetTurn(int index)
    {
        _currentTurn = GetAllPlayers()[index];
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
        SetTurn(indexNext);
        return true;
    }

    public IPlayer GetWinner()
    {
        return _winner;
    }

    public int GetPlayerEnergy(IPlayer player)
    {
        return _players[player].GetEnergy();
    }

    public int GetPlayerPowerInLocation(IPlayer player, AbstractLocation location)
    {
        return location.GetPlayerPower(player);
    }

    public bool SetPlayerPowerInLocation(IPlayer player, AbstractLocation location)
    {
        var playerCardInLocation = location.GetPlayerCards(player);
        foreach (var card in playerCardInLocation)
        {
            location.AssignPlayerPower(player, card.GetPower());
        }
        return true;
    }






}
