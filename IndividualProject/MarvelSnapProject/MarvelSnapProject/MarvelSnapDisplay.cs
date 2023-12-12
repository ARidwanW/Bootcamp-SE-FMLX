using Spectre.Console;

namespace MarvelSnapProject;

public class MarvelSnapDisplay
{
    public void TestTableSpectre()
    {
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
