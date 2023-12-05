// See https://aka.ms/new-console-template for more information
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;

public partial class Program
{
    private static void Main(string[] args)
    {
        Asgard asgard = new Asgard();
        Console.WriteLine(asgard.GetLocationStatus());
        Console.WriteLine(asgard.SetLocationStatus(MarvelSnapProject.Enum.LocationStatus.Revealed));
        Console.WriteLine(asgard.GetLocationStatus());
    }
}