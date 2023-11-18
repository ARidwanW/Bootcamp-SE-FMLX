using Day_4_PR;
class Program
{
    static void Main()
    {
        Console.Write("Please input a number: ");
        int userInput = Convert.ToInt32(Console.ReadLine());
        FooBar foobar = new FooBar();

        string msg = foobar.Next(userInput);
        Console.WriteLine(msg);

    }
}
