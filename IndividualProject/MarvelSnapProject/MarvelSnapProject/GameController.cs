using System.CodeDom.Compiler;
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
    private readonly Logger _logger;
    private GameStatus _gameStatus;
    private int _round;
    private int _maxRound;
    private Dictionary<IPlayer, PlayerInfo> _players;
    private List<AbstractLocation> _locations;
    private int _maxLocation = 3;
    private List<AbstractLocation> _allLocations;
    private List<AbstractCard> _allCards;
    private IPlayer _currentTurn;
    private IPlayer _winner;
    public Action<AbstractCard, CardStatus>? OnCardStatusUpdate;
    public Action<AbstractLocation, LocationStatus>? OnLocationStatusUpdate;
    public Action<IPlayer, PlayerStatus>? OnPlayerStatusUpdate;
    public Action<AbstractLocation>? OnLocationUpdate;
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
        _maxRound = 6;

        _logger?.Info("Game created");
    }

    public void StartGame()
    {
        SetGameStatus(GameStatus.Running);
    }

    public void EndGame()
    {
        SetGameStatus(GameStatus.Finished);
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

    public bool NextRound(int round)
    {
        if (round > _maxRound)
        {
            _gameStatus = GameStatus.Finished;
            return false;
        }
        _gameStatus = GameStatus.Running;

        OnRevealCardAbilityCall?.Invoke(this);
        OnGoingCardAbilityCall?.Invoke(this);
        OnRevealLocationAbilityCall?.Invoke(this);
        OnGoingLocationAbilityCall?.Invoke(this);

        AssignPlayerPowerToLocation();
        FindWinnerInLocation();

        _round = round;
        RevealLocation(round, true);
        SetPlayerEnergy(_round);

        return true;
    }

    public bool NextRound(int round, bool plan)
    {
        _round = round;
        return true;
    }

    public bool NextRound()
    {
        // if (_round > _maxRound)
        // {
        //     _gameStatus = GameStatus.Finished;
        //     return false;
        // }
        _gameStatus = GameStatus.Running;

        OnRevealCardAbilityCall?.Invoke(this);
        OnGoingCardAbilityCall?.Invoke(this);
        OnRevealLocationAbilityCall?.Invoke(this);
        OnGoingLocationAbilityCall?.Invoke(this);

        AssignPlayerPowerToLocation();
        FindWinnerInLocation();

        _round += 1;
        RevealLocation(_round);
        SetPlayerEnergy(_round);

        return true;
    }

    public bool NextRound(bool plan)
    {
        _round += 1;
        return true;
    }

    public bool RevealLocation(int index, bool isLoop = false)
    {
        if (index >= _maxLocation + 1)
        {
            return false;
        }
        if (!isLoop)
        {
            var currentLocation = GetDeployedLocation(index - 1);
            currentLocation.SetLocationStatus(LocationStatus.Revealed);
            if (currentLocation._isOnReveal || currentLocation._isOnGoing)
            {
                currentLocation.RegisterAbility(this);
            }
            return true;
        }
        for (int i = 0; i < index; i++)
        {
            var currentLocation = GetDeployedLocation(i);
            currentLocation.SetLocationStatus(LocationStatus.Revealed);
            if (currentLocation._isOnReveal || currentLocation._isOnGoing)
            {
                currentLocation.RegisterAbility(this);
            }
        }
        return true;
    }

    public int GetMaxRound()
    {
        return _maxRound;
    }

    public bool SetMaxRound(int maxround)
    {
        _maxRound = maxround;
        return true;
    }

    public Dictionary<IPlayer, PlayerInfo> GetAllPlayersInfo()
    {
        return _players;
    }

    public List<IPlayer> GetAllPlayers()
    {
        return _players.Keys.ToList();
    }

    public IPlayer GetPlayer(IPlayer player)
    {
        var foundPlayer = GetAllPlayers().Find(p => p.Id == player.Id);
        if (foundPlayer == null)
        {
            return new MSPlayer(0, "None");
        }
        return foundPlayer;
    }

    public IPlayer GetPlayer(int index)
    {
        return GetAllPlayers()[index];
    }

    public PlayerInfo GetPlayerInfo(IPlayer player)
    {
        return _players[player];
    }

    public IPlayer CreatePlayer(int id, string name)
    {
        return new MSPlayer(id, name);
    }

    public bool AssignPlayer(params IPlayer[] players)
    {
        var newPlayers = players.Where(player => !_players.ContainsKey(player)).ToList();
        newPlayers.ForEach(player => _players.Add(player, new PlayerInfo()));
        return newPlayers.Count == players.Length;
    }

    public bool RemovePlayer(params IPlayer[] players)
    {
        bool allRemoved = true;
        foreach (var player in players)
        {
            if (!_players.Remove(player))
            {
                allRemoved = false;
            }
        }
        return allRemoved;
    }

    public List<AbstractCard> GetPlayerDeck(IPlayer player)
    {
        return GetPlayerInfo(player).GetDeck();
    }

    public AbstractCard GetPlayerCardInDeck(IPlayer player, AbstractCard card)
    {
        var playerDeck = GetPlayerDeck(player);
        var foundCard = playerDeck.Find(c => c.Name == card.Name);

        if (foundCard == null)
        {
            return new NoneCard();
        }
        return foundCard;
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
            status = GetPlayerInfo(player).AssignCardToDeck(card.Clone());
            if (status)
            {
                GetPlayerCardInDeck(player, card).SetCardStatus(CardStatus.OnDeck);
            }
        }

        return status;
    }

    public bool RetrievePlayerCardFromDeck(IPlayer player, params AbstractCard[] cards)
    {
        return GetPlayerInfo(player).RetrieveCardFromDeck(cards);
    }

    public List<AbstractCard> GetPlayerHand(IPlayer player)
    {
        return GetPlayerInfo(player).GetHandCards();
    }

    public AbstractCard GetPlayerCardInHand(IPlayer player, AbstractCard card)
    {
        var playerHand = GetPlayerHand(player);
        var foundCard = playerHand.Find(c => c.Name == card.Name);

        if (foundCard == null)
        {
            return new NoneCard();
        }
        return foundCard;
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

    public bool RetrievePlayerCardFromHand(IPlayer player, params AbstractCard[] cards)
    {
        return GetPlayerInfo(player).RetrieveCardFromHand(cards);
    }

    public int GetPlayerEnergy(IPlayer player)
    {
        return GetPlayerInfo(player).GetEnergy();
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
        return GetPlayerInfo(player).SetEnergy(energy);
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
        return GetPlayerInfo(player).GetMaxDeck();
    }

    public bool SetPlayerMaxDeck(IPlayer player, int maxDeck)
    {
        return GetPlayerInfo(player).SetMaxDeck(maxDeck);
    }

    public int GetPlayerTotalWin(IPlayer player)
    {
        return GetPlayerInfo(player).GetTotalWin();
    }

    public bool SetPlayerTotalWin(IPlayer player, int totalWin)
    {
        return GetPlayerInfo(player).SetTotalWin(totalWin);
    }

    public bool AddPlayerTotalWin(IPlayer player)
    {
        return GetPlayerInfo(player).AddTotalWin();
    }

    public bool AddPlayerTotalWin(IPlayer player, int addWin)
    {
        return GetPlayerInfo(player).AddTotalWin(addWin);
    }

    public PlayerStatus GetPlayerStatus(IPlayer player)
    {
        return GetPlayerInfo(player).GetPlayerStatus();
    }

    public bool SetPlayerStatus(IPlayer player, PlayerStatus status)
    {
        return GetPlayerInfo(player).SetPlayerStatus(status);
    }

    public List<AbstractLocation> GetAllDeployedLocations()
    {
        return _locations;
    }

    public AbstractLocation GetDeployedLocation(AbstractLocation location)
    {
        var deployedLocations = GetAllDeployedLocations();
        var foundLocation = deployedLocations.Find(loc => loc.Name == location.Name);
        if (foundLocation == null)
        {
            return new NoneLocation();
        }
        return foundLocation;
    }

    public AbstractLocation GetDeployedLocation(int index)
    {
        return GetAllDeployedLocations()[index];
    }

    public bool AssignLocation(params AbstractLocation[] locations)
    {
        var newLocations = locations.Where(location => !_locations.Contains(location)).ToList();
        newLocations.ForEach(location => _locations.Add(location));
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
        return allRemoved;
    }

    public LocationStatus GetLocationStatus(AbstractLocation location)
    {
        return location.GetLocationStatus();
    }

    public bool SetLocationStatus(AbstractLocation location, LocationStatus status)
    {
        return location.SetLocationStatus(status);
    }

    public bool IsLocationValid(AbstractLocation location)
    {
        return location.IsLocationValid();
    }

    public bool SetLocationValid(AbstractLocation location, bool isValid)
    {
        return location.SetLocationValid(isValid);
    }

    public List<AbstractCard> GetAllCardsInLocation(AbstractLocation location)
    {
        return location.GetAllCards();
    }

    public AbstractCard GetCardInLocation(AbstractLocation location, AbstractCard card)
    {
        var allCardsInLocation = GetAllCardsInLocation(location);
        var foundCard = allCardsInLocation.Find(c => c.Name == card.Name);
        if (foundCard == null)
        {
            return new NoneCard();
        }
        return foundCard;
    }

    public AbstractCard GetCardInLocation(AbstractLocation location, int index)
    {
        return GetAllCardsInLocation(location)[index];
    }

    public bool AssignCardToLocation(AbstractLocation location, params AbstractCard[] cards)
    {
        return location.AssignCardToLocation(cards);
    }

    public Dictionary<IPlayer, List<AbstractCard>> GetPlayerCardInLocation(AbstractLocation location)
    {
        return location.GetAllPlayersCards();
    }

    public List<AbstractCard> GetPlayerCardInLocation(IPlayer player, AbstractLocation location)
    {
        return GetPlayerCardInLocation(location)[player];
    }

    public AbstractCard GetPlayerCardInLocation(IPlayer player, AbstractLocation location, AbstractCard card)
    {
        var playerCards = GetPlayerCardInLocation(player, location);
        var foundCard = playerCards.Find(c => c.Name == card.Name);
        if (foundCard == null)
        {
            return new NoneCard();
        }
        return foundCard;
    }

    public bool AssignPlayerToLocation(AbstractLocation location, params IPlayer[] players)
    {
        location.AssignPlayer(players);
        return true;
    }

    public Dictionary<IPlayer, int> GetPlayerPowerInLocation(AbstractLocation location)
    {
        return location.GetAllPlayersPower();
    }

    public int GetPlayerPowerInLocation(IPlayer player, AbstractLocation location)
    {
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
        return location.AssignPlayerPower(player, power);
    }

    public bool AddPlayerPowerToLocation(IPlayer player, AbstractLocation location)
    {
        return location.AddPlayerPower(player, 1);
    }

    public bool AddPlayerPowerToLocation(IPlayer player, AbstractLocation location, int powerToAdd)
    {
        return location.AddPlayerPower(player, powerToAdd);
    }

    public Dictionary<IPlayer, PlayerStatus> GetPlayerStatusInLocation(AbstractLocation location)
    {
        return location.GetAllPlayerStatus();
    }

    public PlayerStatus GetPlayerStatusInLocation(IPlayer player, AbstractLocation location)
    {
        return GetPlayerStatusInLocation(location)[player];
    }

    public bool SetPlayerStatusInLocation(IPlayer player, AbstractLocation location, PlayerStatus status)
    {
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

        if (foundPlayer == null)
        {
            return new MSPlayer(0, "None");
        }
        return foundPlayer;
    }

    public IPlayer GetPlayerInLocation(AbstractLocation location, int index)
    {
        return GetAllPlayersInLocation(location)[index];
    }

    public int GetMaxLocation()
    {
        return _maxLocation;
    }

    public bool SetMaxLocation(int maxLocation)
    {
        _maxLocation = maxLocation;
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

    public AbstractLocation GetShuffleLocation()
    {
        Random random = new Random();
        var indexLocation = random.Next(_allLocations.Count);
        return _allLocations[indexLocation];
    }

    public int GetShuffleIndex(int max)
    {
        Random random = new Random();
        return random.Next(max);
    }
    public bool AssignPlayerCardToLocation(IPlayer player, AbstractCard card, AbstractLocation location, bool registerAbility = false, bool usingEnergy = true)
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

        if (usingEnergy)
        {
            if (card.GetCost() > GetPlayerEnergy(player))
            {
                return false;
            }
        }


        var cardInHand = GetPlayerCardInHand(player, card);
        var status = location.AssignPlayerCardToLocation(player, cardInHand);
        if (status)
        {
            var cardInLocation = GetPlayerCardInLocation(player, location, cardInHand);
            if (registerAbility)
            {
                if (cardInLocation._isOnReveal || cardInLocation._isOnGoing)
                {
                    // cardInLocation.DeployCard(this, player, location);
                    cardInLocation.DeployCard(this, player, location);
                }
            }
        }

        return status;
    }

    public IPlayer GetCurrentTurn()
    {
        return _currentTurn;
    }

    public bool NextTurn(IPlayer player)
    {
        _currentTurn = player;
        return true;
    }

    public bool NextTurn(int index)
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
        NextTurn(indexNext);
        return true;
    }

    public IPlayer GetWinner()
    {
        return _winner;
    }

    public IPlayer FindWinnerInLocation(AbstractLocation location)
    {
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

        // bool allValueAreSame = playersPower.Values.Distinct().Count() == 1;


        // foreach (var player in playersPower.Keys)
        // {
        //     if (_round < 1)
        //     {
        //         SetPlayerStatusInLocation(player, location, PlayerStatus.None);
        //     }
        //     else
        //     {
        //         var playerCards = GetPlayerCardInLocation(player, location);
        //         if (playerCards.Count == 0)
        //         {
        //             // Cek apakah semua pemain belum meletakan kartu
        //             bool allPlayersNoCards = playersPower.Keys.All(p => GetPlayerCardInLocation(p, location).Count == 0);
        //             if (allPlayersNoCards)
        //             {
        //                 SetPlayerStatusInLocation(player, location, PlayerStatus.Draw); // Ubah status menjadi Draw
        //             }
        //             else
        //             {
        //                 if (allValueAreSame)
        //                 {
        //                     SetPlayerStatusInLocation(player, location, PlayerStatus.Draw);
        //                 }
        //                 else if (player.Equals(winner))
        //                 {
        //                     SetPlayerStatusInLocation(player, location, PlayerStatus.Win);
        //                 }
        //                 else if (player.Equals(loser))
        //                 {
        //                     SetPlayerStatusInLocation(player, location, PlayerStatus.Lose); // Ubah status menjadi Lose
        //                 }
        //             }
        //         }
        //         else if (player.Equals(winner))
        //         {
        //             SetPlayerStatusInLocation(player, location, PlayerStatus.Win);
        //         }
        //         else
        //         {
        //             SetPlayerStatusInLocation(player, location, PlayerStatus.Lose);
        //         }
        //     }
        // }

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
        // Reset total win for all players
        foreach (var player in _players.Keys)
        {
            SetPlayerTotalWin(player, 0);
        }

        // Calculate total win for each player
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

        // Find the player with the highest total win
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

        return winner;
    }

    public bool SetWinner(IPlayer player)
    {
        _winner = player;
        return true;
    }

}
