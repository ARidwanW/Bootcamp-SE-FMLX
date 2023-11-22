using GameControllerLib;

class Program
{
    static void Main()
    {
        // * lets the game begin
        // ?? where's the ui
        // ?? and where's the database
        // ! we need lisneter
        UI ui = new();
        Database db = new();

        // ! we need players
        Player player1 = new Player(101, "Ucup");
        Player player2 = new Player(102, "Bambang");

        // ! put player to the game
        GameController game = new GameController(player1, player2);

        // ! let add update method
        game.onCardUpdate += ui.UpdateCard;
        game.onCardUpdate += db.LogToDb;
        game.onCardUpdate += SMS.SendSms;

        // ! we need cards, let's add 2
        Card card1 = new Card(11, 1, 2);
        Card card2 = new Card(12, 2, 3);

        // ! let's add card to player 1
        game.AddCard(player1, card1, card2);

        // ?? oh wait, we need to update the card
        // ?? we need to update it in UI and DB


    }
}
