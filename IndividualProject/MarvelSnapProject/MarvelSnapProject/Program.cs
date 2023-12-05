// See https://aka.ms/new-console-template for more information
using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;

public partial class Program
{
    private static void Main(string[] args)
    {
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
}