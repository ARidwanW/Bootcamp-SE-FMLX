using System.Reflection;
using MarvelSnapProject;
using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;
using NLog;
using Spectre.Console;

namespace MarvelSnapProjectSimpleTest;

public static class SimpleTest
{
    public static void SimpleTestAssignCard1()
    {
        //* simple test
        GameController game = new();
        MSPlayer Wawan = new(1, "Wawan");
        Hawkeye hawkeye = new();
        var hawkeyeCard = hawkeye.Clone();
        Abomination abomination = new();
        game.AssignPlayer(Wawan);
        game.AssignDeckCard(Wawan, true, true, hawkeyeCard);
        var wawanDeck = game.GetDeck(Wawan);
        foreach (var card in wawanDeck)
        {
            Console.WriteLine(card.Name + card.GetCardStatus());
        }
        var assignCardToWawan = game.AssignHandCard(Wawan, true, cards: hawkeyeCard);
        Console.WriteLine(assignCardToWawan);
        foreach (var card in game.GetHand(Wawan))
        {
            Console.WriteLine(card.Name + card.GetCardStatus());
        }
    }

    public static void SimpleTestAssignCard2()
    {
        //* simple test 2
        GameController game = new();
        MSPlayer Wawan = new(1, "Wawan");
        Hawkeye hawkeye = new();
        Abomination abomination = new();
        AbstractCard[] twoCards = { hawkeye, abomination };
        game.AssignPlayer(Wawan);
        game.AssignDeckCard(Wawan, true, true, hawkeye, abomination);
        var wawanDeck = game.GetDeck(Wawan);
        foreach (var card in wawanDeck)
        {
            Console.WriteLine(card.Name + card.GetCardStatus());
        }
        var assignCardToWawan = game.AssignHandCard(Wawan, true, cards: twoCards);
        Console.WriteLine(assignCardToWawan);
        foreach (var card in game.GetHand(Wawan))
        {
            Console.WriteLine(card.Name + card.GetCardStatus());
        }
    }

    public static void SimpleTestGetItemName()
    {
        //* test to get item name from list
        PlayerInfo playerInfo = new PlayerInfo();
        IronMan ironMan = new IronMan();
        Console.WriteLine(playerInfo.AssignCardToDeck(ironMan));
        var deck = playerInfo.GetDeck();
        foreach (var card in deck)
        {
            Console.WriteLine(card.Name);
        }
        Console.WriteLine(playerInfo.AssignCardToHand(ironMan));
        Console.WriteLine(playerInfo.RemoveCardFromDeck(ironMan));
        var hand = playerInfo.GetHandCards();
        foreach (var card in hand)
        {
            Console.WriteLine(card.Name);
        }
        deck = playerInfo.GetDeck();
        foreach (var card in deck)
        {
            Console.WriteLine(card.Name);
        }
    }

    public static void TestGame()
    {
        //* Display instance
        MarvelSnapDisplay marvelSnapDisplay = new MarvelSnapDisplay();

        //* Let's Create the game
        GameController game;
        if (!AnsiConsole.Confirm("Using Logger?"))
        {
            game = new GameController();
        }
        else
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "./log/logfile.txt" };
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);
            LogManager.Configuration = config;
            game = new GameController(LogManager.GetCurrentClassLogger());
        }


        Console.Clear();
        marvelSnapDisplay.Intro();
        Console.ResetColor();

        //* Assign Player
        string? name1, name2;
        IPlayer player1, player2;
        do
        {
            name1 = AnsiConsole.Ask<string>("[blue]Input First Player's Name \t: [/]");
            name1 = char.ToUpper(name1[0]) + name1.Substring(1);
            player1 = new MSPlayer(101, name1);
        } while (name1 == "" || !game.AssignPlayer(player1));
        game.AssignPlayer(player1);

        do
        {
            name2 = AnsiConsole.Ask<string>("[red]Input Second Player's Name \t: [/]");
            name2 = char.ToUpper(name2[0]) + name2.Substring(1);
            player2 = new MSPlayer(102, name2);
        }
        while (name2 == "" || !game.AssignPlayer(player2));
        game.AssignPlayer(player2);

        //* list player
        List<IPlayer> listPlayers = game.GetPlayer();

        AnsiConsole.Write(new Markup($"\n[bold yellow]Welcome[/] [bold blue]{player1.Name}[/] [bold yellow]and[/] [bold red]{player2.Name}[/] !" +
                                    "\n[bold green]Lets Play !![/] \n").Centered());

        //* to start game
        do
        {
            AnsiConsole.MarkupLine("\n[bold yellow]Press Enter to start the Game[/]");
        }
        while (Console.ReadKey().Key != ConsoleKey.Enter);

        //* Cards
        Abomination abomination = new();
        Cyclops cyclops = new();
        Hawkeye hawkeye = new();
        Hulk hulk = new();
        IronMan ironMan = new();
        Medusa medusa = new();
        QuickSilver quickSilver = new();
        Thing thing = new();

        //* list of cards
        List<AbstractCard> listCards = new List<AbstractCard>()
        {
            // 1 energi
            hawkeye,
            quickSilver,

            // 2 energi
            medusa,

            //3 energi
            cyclops,

            //4 energi
            thing,

            //5 energi
            abomination,
            ironMan,

            //6 energi
            hulk,
        };

        //* assign card to player deck
        foreach (var player in listPlayers)
        {
            foreach (var card in listCards)
            {
                game.AssignDeckCard(player, true, true, card);
            }
        }

        //* list player card deck
        List<AbstractCard> deckPlayer1 = game.GetDeck(player1);
        List<AbstractCard> deckPlayer2 = game.GetDeck(player2);

        //* assign card to player hand
        game.AssignHandCard(player1, true, cards: listCards.ToArray());
        game.AssignHandCard(player2, true, cards: listCards.ToArray());


        //* locations
        KunLun kunLun = new KunLun();
        NegativeZone negativeZone = new NegativeZone();
        Ruins ruins = new Ruins();

        //* list of location
        List<AbstractLocation> listLocations = new List<AbstractLocation>()
        {
            kunLun,
            negativeZone,
            ruins,
        };

        //* Assign location to game
        game.AssignLocation(listLocations.ToArray());

        //* Assign all player to all location deployed
        foreach (var location in game.GetAllDeployedLocations())
        {
            game.AssignPlayerToLocation(location, listPlayers.ToArray());
        }

        // Console.Clear();
        // game.NextRound();
        // marvelSnapDisplay.Intro();
        // int currentRound = game.GetCurrentRound();
        // var currentTurn = game.GetCurrentTurn();
        // game.NextTurn(player1);
        // AnsiConsole.Write(new Markup($"[bold red]Round {currentRound}[/]").Centered());
        // marvelSnapDisplay.DisplayLocation(game);
        //*chek current turn here (current Turn) if player1 then marvelSnapDisplay.DiplayPlayerCard(game, player1);
        //*ask the index or name of the card with ansiconsole --> var card --> ask again if there's no such index or name
        //*ask the index or name of the location with ansiconsole --> var location --> ask again if there's no such index or location name
        //*search card in player hand game.GetPlayerHand(IPlayer)[index of card] or game.GetPlayerHand(IPlayer).find(c => c.Name == card.Name) --> var choosedCard
        //*search location game.GetDeployedLocation(index) or game.GetAllDeployedLocations().Find(loc => loc.Name == location.Name) --> var choosedLocation
        //*assign card to location --> game.AssignPlayerCardToLocation(IPlayer player, AbstractCard card, AbstractLocation location, bool usingEnergy = true)
        //*change turn with NexTurn() or NextTurn(index) or NexTurn(IPlayer player)
        //*do the same as player 1 and go into loop
        // Console.ReadKey();

        game.StartGame();
        game.NextTurn(player2);
        while (game.GetGameStatus() == GameStatus.Running)
        {

            if (game.GetCurrentTurn() == game.GetPlayer(game.GetPlayer().Count - 1))
            {
                game.NextRound();
            }

            if (game.GetCurrentRound() == 7)
            {
                game.SetGameStatus(GameStatus.Finished);
                Console.Clear();
                marvelSnapDisplay.Intro();
                marvelSnapDisplay.DisplayLocation(game);
                break;
            }

            Console.Clear();
            game.NextTurn();
            marvelSnapDisplay.Intro();
            int currentRound = game.GetCurrentRound();
            var currentTurn = game.GetCurrentTurn();
            var currentEnergy = game.GetPlayerEnergy(currentTurn);
            AnsiConsole.Write(new Markup($"[bold red]Round {currentRound}[/]").Centered());
            marvelSnapDisplay.DisplayLocation(game);
            if (currentTurn == player1)
            {
                AnsiConsole.Write(new Markup($"[bold yellow]Turn:[/] [bold blue]{currentTurn.Name}[/]").Centered());
            }
            else
            {
                AnsiConsole.Write(new Markup($"[bold yellow]Turn:[/] [bold red]{currentTurn.Name}[/]").Centered());
            }

            AnsiConsole.Write(new Markup($"[bold yellow]Player Energy:[/] [cyan]{currentEnergy}[/]").Centered());

            marvelSnapDisplay.DiplayPlayerCard(game, currentTurn);

            AbstractCard choosedCard;
            AbstractLocation choosedLocation;
            int cardIndex = AnsiConsole.Prompt(
            new TextPrompt<int>($"[rapidblink yellow]{currentTurn.Name}[/], [bold green]Choose the card (index of your card): [/]")
                .ValidationErrorMessage("[red]That's not a valid card index[/]")
                .Validate(index =>
                {

                    if (index < 0 || index > game.GetHand(currentTurn).Count)
                    {
                        return ValidationResult.Error("[red]The card index must be within the range of your hand[/]");
                    }

                    choosedCard = game.GetHand(currentTurn)[index - 1];
                    if (choosedCard.GetCost() > currentEnergy)
                    {
                        return ValidationResult.Error("[red]The cost of the card cannot exceed the player's energy[/]");
                    }
                    return ValidationResult.Success();
                }));
            int locationIndex = AnsiConsole.Prompt(
            new TextPrompt<int>($"[rapidblink yellow]{currentTurn.Name}[/], [bold green]Choose the location (index of your location): [/]")
                .ValidationErrorMessage("[red]That's not a valid location index[/]")
                .Validate(index =>
                {
                    if (index < 0 || index > game.GetAllDeployedLocations().Count)
                    {
                        return ValidationResult.Error("[red]The location index must be within the range of deployed locations[/]");
                    }
                    return ValidationResult.Success();
                }));

            choosedCard = game.GetHand(currentTurn)[cardIndex - 1];
            choosedLocation = game.GetDeployedLocation(locationIndex - 1);

            game.AssignPlayerCardToLocation(currentTurn, choosedCard, choosedLocation, byName: false, registerAbility: true);
            Console.ReadKey();
        }

        var winner = game.FindWinner();
        if (winner.Name != "Draw")
        {
            if (winner == player1)
            {
                AnsiConsole.Write(new Markup($"\n\n\n[bold yellow]The Winner is [/][bold blue]{winner.Name}[/][bold yellow]!![/]\n" +
                                    "[bold yellow]Congrats!![/]\n\n\n").Centered());
            }
            else
            {
                AnsiConsole.Write(new Markup($"\n\n\n[bold yellow]The Winner is [/][bold red]{winner.Name}[/][bold yellow]!![/]\n" +
                                "[bold yellow]Congrats!![/]\n\n\n").Centered());
            }
        }
        else
        {
            AnsiConsole.Write(new Markup($"\n\n\nThe Game is {winner.Name}!!\n\n\n").Centered());
        }
    }

    public static void GetAllVarAndMethodGController()
    {
        var type = typeof(GameController); // Ganti 'YourClass' dengan nama kelas Anda

        Console.WriteLine("=== Methods ===");
        foreach (var method in type.GetMethods())
        {
            if (method.DeclaringType == type)
            {
                Console.WriteLine("Method: {0}", method.Name);
                Console.WriteLine("Return Type: {0}", method.ReturnType);
                Console.WriteLine("Access Modifier: {0}", method.IsPublic ? "public" : "non-public");
            }
        }

        Console.WriteLine("\n=== Variables ===");
        foreach (var field in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
        {
            Console.WriteLine("Variable: {0}", field.Name);
            Console.WriteLine("Type: {0}", field.FieldType);
            Console.WriteLine("Access Modifier: {0}", field.IsPublic ? "public" : "non-public");
        }
    }
}
