using Spectre.Console;

namespace MarvelSnapProject;

public class MarvelSnapDisplay
{
    public void Intro()
    {
        AnsiConsole.Write(new Markup("[bold yellow]Welcome to the game![/]").Centered());
        AnsiConsole.Write(new Rule());
        AnsiConsole.Write(new FigletText("WAWAN  SNAP").Centered().Color(Color.Aqua));
    }
    public void TestTableSpectre()
    {
        var table = new Table().Centered();
        AnsiConsole.Live(table)
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

                table.AddRow("far");
                ctx.Refresh();
                Thread.Sleep(1000);

                table.AddRow(new Table().AddColumn("sui"));
                ctx.Refresh();
                Thread.Sleep(1000);

            });
    }

    public void TestLayoutSpectre()
    {
        // Create the layout
        var layout = new Layout("Root")
            .SplitColumns(
                new Layout("Left"),
                new Layout("Right")
                    .SplitRows(
                        new Layout("Top"),
                        new Layout("Bottom")));

        // Update the left column
        layout["Left"].Update(
            new Panel(
                Align.Center(
                    new Markup("Hello [blue]World![/]"),
                    VerticalAlignment.Middle))
                .Expand());

        // Render the layout
        AnsiConsole.Write(layout);
    }
}
