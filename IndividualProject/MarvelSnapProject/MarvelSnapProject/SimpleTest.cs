using MarvelSnapProject;
using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;
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
        game.AssignCardToPlayerDeck(Wawan, hawkeyeCard);
        var wawanDeck = game.GetPlayerDeck(Wawan);
        foreach (var card in wawanDeck)
        {
            Console.WriteLine(card.Name + card.GetCardStatus());
        }
        var assignCardToWawan = game.AssignCardToPlayerHand(Wawan, hawkeyeCard);
        Console.WriteLine(assignCardToWawan);
        foreach (var card in game.GetPlayerHand(Wawan))
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
        game.AssignPlayer(Wawan);
        game.AssignCardToPlayerDeck(Wawan, hawkeye, abomination);
        var wawanDeck = game.GetPlayerDeck(Wawan);
        foreach (var card in wawanDeck)
        {
            Console.WriteLine(card.Name + card.GetCardStatus());
        }
        var assignCardToWawan = game.AssignCardToPlayerHand(Wawan, hawkeye, abomination);
        Console.WriteLine(assignCardToWawan);
        foreach (var card in game.GetPlayerHand(Wawan))
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
        Console.WriteLine(playerInfo.RetrieveCardFromDeck(ironMan));
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

    public static void SimpleTestGetLocation()
    {
        //* test GetLocation(AbstractLocation) to get item from List<AbstractLocation> in GameController
        GameController game = new();
        Asgard asgard = new();
        Atlantis atlantis = new();
        Attilan attilan = new();
        Flooded flooded = new();
        game.AssignLocation(asgard, atlantis, attilan);
        var location = game.GetLocation(flooded);
        var locations = game.GetDefaultAllLocations();
        foreach (var item in locations)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(location.Name);
    }

    public static void TestGame()
    {
        //* Display instance
        MarvelSnapDisplay marvelSnapDisplay = new MarvelSnapDisplay();

        //* Let's Create the game
        GameController game = new GameController();

        Console.Clear();
        marvelSnapDisplay.Intro();
        // Console.ForegroundColor = ConsoleColor.Blue;
        // Console.WriteLine("==== Welcome To Wawan Snap ==== \n");
        // Console.ResetColor();
        // Console.ForegroundColor = ConsoleColor.Yellow;
        // Console.WriteLine("A Marvel Snap Clone Project");
        // Console.ForegroundColor = ConsoleColor.Cyan;
        // Console.WriteLine("By: Alwandia Ridwan Wadiska");
        Console.ResetColor();

        //* Assign Player
        string? name1, name2;
        IPlayer player1, player2;
        do
        {
            // Console.Write("Input First Player's Name \t: ");
            // name1 = Console.ReadLine();
            name1 = AnsiConsole.Ask<string>("[blue]Input First Player's Name \t: [/]");
            name1 = char.ToUpper(name1[0]) + name1.Substring(1);
            player1 = new MSPlayer(101, name1);
        } while (name1 == "" || !game.AssignPlayer(player1));
        game.AssignPlayer(player1);

        do
        {
            // Console.Write("Input Second Player's Name \t: ");
            // name2 = Console.ReadLine();
            name2 = AnsiConsole.Ask<string>("[red]Input Second Player's Name \t: [/]");
            name2 = char.ToUpper(name2[0]) + name2.Substring(1);
            player2 = new MSPlayer(102, name2);
        }
        while (name2 == "" || !game.AssignPlayer(player2));
        game.AssignPlayer(player2);

        //* list player
        List<IPlayer> listPlayers = game.GetAllPlayers();

        // Console.ForegroundColor = ConsoleColor.Green;
        // Console.WriteLine($"\nWelcome {player1.Name} and {player2.Name} ! \nLets Play !! \n");
        // Console.ResetColor();
        AnsiConsole.Write(new Markup($"\n[yellow]Welcome[/] [blue]{player1.Name}[/] [yellow]and[/] [red]{player2.Name}[/] !" +
                                    "\n[green]Lets Play !![/] \n").Centered());

        // Console.ForegroundColor = ConsoleColor.Yellow;
        do
        {
            // Console.WriteLine("\nPress Enter to start the Game");
            AnsiConsole.MarkupLine("\n[bold yellow]Press Enter to start the Game[/]");
        }
        while (Console.ReadKey().Key != ConsoleKey.Enter);

        //* Cards
        Abomination abomination = new();
        Cyclops cyclops = new();
        Hawkeye hawkeye = new();
        Hulk hulk = new();
        Medusa medusa = new();
        QuickSilver quickSilver = new();

        List<AbstractCard> listCards = new List<AbstractCard>()
        {
            abomination,
            cyclops,
            hawkeye,
            hulk,
            medusa,
            quickSilver
        };

        //* assign card to player deck
        foreach (var player in listPlayers)
        {
            foreach (var card in listCards)
            {
                game.AssignCardToPlayerDeck(player, card);
            }
        }

        //* list player card deck
        List<AbstractCard> deckPlayer1 = game.GetPlayerDeck(player1);
        List<AbstractCard> deckPlayer2 = game.GetPlayerDeck(player2);

        //* assign card to player hand
        game.AssignCardToPlayerHand(player1, listCards.ToArray());
        game.AssignCardToPlayerHand(player2, listCards.ToArray());


        //* locations
        KunLun kunLun = new KunLun();
        NegativeZone negativeZone = new NegativeZone();
        Ruins ruins = new Ruins();

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
            location.AssignPlayerToLocation(listPlayers.ToArray());
        }

        Console.Clear();
        game.NextRound();
        marvelSnapDisplay.Intro();
        Console.WriteLine(game.GetCurrentRound());
        marvelSnapDisplay.DisplayLocation(game);
        Console.ReadKey();

        while (game.GetCurrentGameStatus() == GameStatus.Running)
        {
            Console.Clear();
            if (game.GetCurrentRound() == 1)
            {
                game.AssignPlayerCardToLocation(player1, hawkeye, kunLun);
            }
            game.NextRound(6);
            marvelSnapDisplay.Intro();
            Console.WriteLine(game.GetCurrentRound());
            foreach (var player in listPlayers)
            {
                foreach(var location in listLocations)
                game.SetPlayerPowerInLocation(player, location);
            }
            
            marvelSnapDisplay.DisplayLocation(game);
            Console.ReadKey();
        }



        //*test assign to location
        // Console.Clear();
        // game.AssignPlayerCardToLocation(player1, hawkeye, kunLun);
        // game.NextRound();
        // marvelSnapDisplay.Intro();
        // Console.WriteLine(game.GetCurrentRound());
        // marvelSnapDisplay.DisplayLocation(game);
        // Console.WriteLine(assigned);
        // Console.ReadKey();

        // Console.Clear();
        // game.AssignPlayerCardToLocation(player1, quickSilver, kunLun);
        // game.NextRound();
        // marvelSnapDisplay.Intro();
        // Console.WriteLine(game.GetCurrentRound());
        // marvelSnapDisplay.DisplayLocation(game);
        // Console.WriteLine(assigned);
        // Console.ReadKey();

        // Console.Clear();
        // marvelSnapDisplay.Intro();
        // game.NextRound();
        // marvelSnapDisplay.DisplayLocation(game);



        // while(game.GetCurrentGameStatus() == GameStatus.Running)
        // {
        //     // Console.WriteLine(game.AssignCardToPlayerDeck(player1, abomination,cyclops,hawkeye,hulk,medusa, quickSilver));
        //     // Console.WriteLine(game.AssignCardToPlayerDeck(player2, abomination,cyclops,hawkeye,hulk,medusa, quickSilver));
        //     // Console.WriteLine(game.AssignCardToPlayerHand(player1, cyclops, medusa, quickSilver));
        //     // Console.WriteLine(game.AssignCardToPlayerHand(player2, cyclops, medusa, quickSilver));
        //     // Console.WriteLine(game.GetPlayerDeck(player1));
        //     // Console.WriteLine(game.GetPlayerDeck(player2));
        //     // Console.WriteLine(game.GetPlayerHand(player1));
        //     // Console.WriteLine(game.GetPlayerHand(player2));
        // }
    }
}