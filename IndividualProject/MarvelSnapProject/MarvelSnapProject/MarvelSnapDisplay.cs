using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;
using NLog.LayoutRenderers;
using Spectre.Console;

namespace MarvelSnapProject;

public class MarvelSnapDisplay
{
    public void Intro()
    {
        var ruleHead = new Rule();
        ruleHead.Style = Style.Parse("rapidblink cyan1");

        string description = "This is a Marvel Snap game clone\n(Education Purpose Only)\nSome Card is Overpower lol :rolling_on_the_floor_laughing:";
        string author = "By: ARidwanW";
        // $"[bold yellow]{description}[/]"
        AnsiConsole.Write(new Markup("[bold yellow]Welcome to the game![/]").Centered());
        AnsiConsole.Write(ruleHead);
        AnsiConsole.Write(new FigletText("WAWAN  SNAP").Centered().Color(Color.Red1));
        AnsiConsole.Write(new Markup($"[bold yellow]{description}[/]").Centered());
        AnsiConsole.Write(new Markup($"[bold yellow]{author}[/]").Centered());
        AnsiConsole.Write(ruleHead);
    }

    public void DisplayLocation(GameController game)
    {
        var playerA = game.GetPlayer(0);
        var playerB = game.GetPlayer(1);
        var playerInfoA = game.GetPlayerInfo(playerA);
        var playerInfoB = game.GetPlayerInfo(playerB);

        var table = new Table().Border(TableBorder.Rounded).Centered();
        table.AddColumn("Location");
        table.AddColumn("Status");
        table.AddColumn($"Status {playerA.Name}");
        table.AddColumn($"Card {playerA.Name}");
        table.AddColumn($"Power {playerA.Name}");
        table.AddColumn($"Status {playerB.Name}");
        table.AddColumn($"Card {playerB.Name}");
        table.AddColumn($"Power {playerB.Name}");

        var currentRound = game.GetCurrentRound();
        if (currentRound < 4)
        {
            game.GetDeployedLocation(currentRound - 1).SetLocationStatus(LocationStatus.Revealed);
        }

        for (int i = 0; i < 3; i++)
        {
            var location = game.GetDeployedLocation(i);
            var locationStatus = location.GetLocationStatus().ToString();

            var playerStatusA = location.GetPlayerStatusInLocation(playerA).ToString();
            var playerStatusB = location.GetPlayerStatusInLocation(playerB).ToString();

            var cardsPlayerA = game.GetPlayerCardsInLocation(playerA, location);
            var cardStringsA = cardsPlayerA.Select(card => card.Name);

            var cardsPlayerB = game.GetPlayerCardsInLocation(playerB, location);
            var cardStringsB = cardsPlayerB.Select(card => card.Name);

            var powerPlayerA = game.GetPlayerPowerInLocation(playerA, location).ToString();
            var powerPlayerB = game.GetPlayerPowerInLocation(playerB, location).ToString();


            if (location != null && playerA != null && playerB != null)
            {
                table.AddRow(
                    Markup.Escape((location.GetLocationStatus() == LocationStatus.Revealed) ? location.Name : "Hidden"),
                    Markup.Escape(locationStatus),
                    Markup.Escape(playerStatusA),
                    Markup.Escape(string.Join(", ", cardStringsA)),
                    Markup.Escape(powerPlayerA),
                    Markup.Escape(playerStatusB),
                    Markup.Escape(string.Join(", ", cardStringsB)),
                    Markup.Escape(powerPlayerB)
                    );

            }
        }

        AnsiConsole.Write(table);
    }
    //     var cards = game.GetPlayerCardsInLocation(playerA, location);
    // var cardStrings = cards.Select(card => card.ToString());
    // var result = Markup.Escape(string.Join(", ", cardStrings));


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

    public void TestBoardSpectre()
    {
        var table = new Table().Centered();
        table.AddColumn("foo");
        table.AddColumn("bar");
        table.AddRow("asdf", "afaf");

        AnsiConsole.Write(table);
    }

}
