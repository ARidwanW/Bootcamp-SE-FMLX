using MarvelSnapProject;
using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;
using MarvelSnapProjectSimpleTest;
using Microsoft.VisualBasic;
using Spectre.Console;


class Program
{
    public static void Main(string[] args)
    {
        // MarvelSnapDisplay marvelSnapDisplay = new();
        // marvelSnapDisplay.Intro();
        // SimpleTest.TestGame();
        GameController game = new GameController();
        MSPlayer player1 = new MSPlayer(1, "wawan");
        MSPlayer player2 = new MSPlayer(2, "wiwi");

        game.StartGame();
        game.NextTurn(player2);
        while (game.GetCurrentGameStatus() == GameStatus.Running)
        {
            if (game.GetCurrentTurn() == game.GetPlayer(game.GetAllPlayers().Count - 1))
            {
                game.NextRound();
            }
            if (game.GetCurrentRound() == 7)
            {
                game.SetGameStatus(GameStatus.Finished);
                if (game.GetCurrentGameStatus() == GameStatus.Finished)
                {
                    Console.WriteLine(game.FindWinner().Name);
                }
            }

            game.NextTurn();
            Console.ReadKey();
        }

    }
}