using MarvelSnapProject;
using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using Spectre.Console;


public partial class Program
{
    private static void Main(string[] args)
    {
        //* Let's Create the game
        GameController game = new GameController();
        AnsiConsole.Write(new Markup("[bold yellow]Hello[/] [red]World![/]\n"));
        var table = new Table();
        table.AddColumn(new TableColumn(new Markup("[yellow]Foo[/]")));
        table.AddColumn(new TableColumn("[blue]Bar[/]"));
        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine(":accordion:");
        


    }
}