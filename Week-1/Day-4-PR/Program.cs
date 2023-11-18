using Day_4_PR;
class Program
{
    static void Main()
    {
        FooBar foobar = new FooBar();

        Console.Write("Please input a number: ");
        int userInput = Convert.ToInt32(Console.ReadLine());

        // Console.Write("Please input a start number: ");
        // int inputStart = Convert.ToInt32(Console.ReadLine());
        // Console.Write("\nPlease input a end number: ");
        // int inputEnd = Convert.ToInt32(Console.ReadLine());
        

        string msg = foobar.Next(userInput);
        // string msg = foobar.Next(inputStart, inputEnd);

        Console.WriteLine(msg);

    }
}
