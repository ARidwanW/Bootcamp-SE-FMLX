using MarvelSnapProject;
using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;

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
        game.AssignCardToPlayerDeck(Wawan,hawkeyeCard);
        var wawanDeck = game.GetPlayerDeck(Wawan);
        foreach(var card in wawanDeck)
        {
            Console.WriteLine(card.Name + card.GetCardStatus());
        }
        var assignCardToWawan = game.AssignCardToPlayerHand(Wawan, hawkeyeCard);
        Console.WriteLine(assignCardToWawan);
        foreach(var card in game.GetPlayerHand(Wawan))
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
        foreach(var card in wawanDeck)
        {
            Console.WriteLine(card.Name + card.GetCardStatus());
        }
        var assignCardToWawan = game.AssignCardToPlayerHand(Wawan, hawkeye, abomination);
        Console.WriteLine(assignCardToWawan);
        foreach(var card in game.GetPlayerHand(Wawan))
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
        foreach(var card in deck)
        {
            Console.WriteLine(card.Name);
        }
        Console.WriteLine(playerInfo.AssignCardToHand(ironMan));
        Console.WriteLine(playerInfo.RetrieveCardFromDeck(ironMan));
        var hand = playerInfo.GetHandCards();
        foreach(var card in hand)
        {
            Console.WriteLine(card.Name);
        }
        deck = playerInfo.GetDeck();
        foreach(var card in deck)
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
        var locations = game.GetAllLocations();
        foreach(var item in locations)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(location.Name);
    }

    public static void TestGame()
    {
        //* Let's Create the game
        GameController game = new GameController();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("==== Welcome To Wawan Snap ==== \n");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("A Marvel Snap Clone Project");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("By: Alwandia Ridwan Wadiska");
        Console.ResetColor();

        //* Assign Player
        string? name1, name2;
        IPlayer player1, player2;
        do
        {
            Console.Write("Input First Player's Name \t: ");
            name1 = Console.ReadLine();
            name1 = char.ToUpper(name1[0]) + name1.Substring(1);
            player1 = new MSPlayer(101, name1);
        } while (name1 == "" || !game.AssignPlayer(player1));
        game.AssignPlayer(player1);

        do
        {
            Console.Write("Input Second Player's Name \t: ");
            name2 = Console.ReadLine();
            name2 = char.ToUpper(name2[0]) + name2.Substring(1);
            player2 = new MSPlayer(102, name2);
        }
        while (name2 == "" || !game.AssignPlayer(player2));
        game.AssignPlayer(player2);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nWelcome {player1.Name} and {player2.Name} ! \nLets Play !! \n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        do
        {
            Console.WriteLine("\nPress Enter to start the Game");
        }
        while (Console.ReadKey().Key != ConsoleKey.Enter);
        Console.ResetColor();

        Console.Clear();
        game.NextRound();
    }
}
