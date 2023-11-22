namespace GameControllerLib;

// ! we need updateeeeesssss
public class UI
{
    // * we need method to update card status
    public void UpdateCard(ICard card, CardStatus status)
    {
        Console.WriteLine($"Card: {card.Id} status changed to {status}");
    }
}

public class Database
{
    public void LogToDb(ICard card, CardStatus status)
    {
        Console.WriteLine($"{DateTime.Now} - Card : {card.Id} status changed to {status}");
    }
}

public class SMS
{
    // * let's try static
    public static void SendSms(ICard card, CardStatus status)
    {
        Console.WriteLine($"SMS NOTIFICATION! Card: {card.Id} status changed to {status}");
    }
}