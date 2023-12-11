using Microsoft.VisualBasic;

class Program
{
    public static void Main()
    {
        var msg = new MessageGenerator("ini pesan pertama");
        var messages = msg.GetMessages(3);  //.ToList() --> membuat messages menjadi sebuah sebuah list
                                            // dan saat di ganti messagenya tidak akan ke override karena beda referensi
        msg.message = "ini override pesan";
        foreach(var message in messages)
        {
            Console.WriteLine(message);
        }
    }
}

class MessageGenerator
{
    public string message;
    public MessageGenerator(string msg)
    {
        this.message = msg;
    }

    public IEnumerable<string> GetMessages(int count)
    {
        for(int i=0; i< count; i++)
        {
            yield return message;
        }
    }
}