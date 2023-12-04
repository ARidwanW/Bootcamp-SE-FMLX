// See https://aka.ms/new-console-template for more information
using MarvelSnapProject.Component.Player;

public partial class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        MSPlayer msplayer = new MSPlayer(1, "lala");
        var name = msplayer.Name;
    }
}