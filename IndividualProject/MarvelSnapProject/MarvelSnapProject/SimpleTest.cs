using MarvelSnapProject;
using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;

namespace MarvelSnapProjectSimpleTest;

public class SimpleTest
{
    public void SimpleTestAssignCard1()
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

    public void SimpleTestAssignCard2()
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

    public void SimpleTestGetItemName()
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

    public void SimpleTestGetLocation()
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
}
