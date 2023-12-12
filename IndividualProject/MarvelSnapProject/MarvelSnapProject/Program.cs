using MarvelSnapProject;
using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using Spectre.Console;


class Program
{
    public static void Main(string[] args)
    {
        //* Let's Create the game
        GameController game = new GameController();
        var table = new Table().Centered();
        AnsiConsole.Live(table)
        .AutoClear(false)   // Do not remove when done
        .Overflow(VerticalOverflow.Ellipsis) // Show ellipsis when overflowing
        .Cropping(VerticalOverflowCropping.Top) // Crop overflow at top
            .Start(ctx =>
            {
                table.AddColumn("Foo");
                ctx.Refresh();
                Thread.Sleep(1000);

                table.AddColumn("Bar");
                ctx.Refresh();
                Thread.Sleep(1000);

                table.AddColumn("baz");
                ctx.Refresh();
                Thread.Sleep(1000);
            });

    }
}