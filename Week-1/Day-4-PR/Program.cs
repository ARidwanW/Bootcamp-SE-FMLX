using Day_4_FooBarV2;
class Program
{
    static void Main()
    {
        // FooBar foobar = new FooBar();

        // Console.Write("Please input a number: ");
        // int userInput = Convert.ToInt32(Console.ReadLine());

        // Console.Write("Please input a start number: ");
        // int inputStart = Convert.ToInt32(Console.ReadLine());
        // Console.Write("\nPlease input a end number: ");
        // int inputEnd = Convert.ToInt32(Console.ReadLine());
        

        // string msg = foobar.Next(userInput);
        // string msg = foobar.Next(inputStart, inputEnd);

        // Console.WriteLine(msg);


        // * ###### Foobar v2
        FooBarV2<int, string> foobarv2 = new FooBarV2<int, string>();

        Dictionary<int, string> condition = new Dictionary<int, string>() {
            {3, "foo"},
            {5, "bar"}
        };

        Console.WriteLine( foobarv2.AddCondition(3, "foo"));    // ?? output: True
        foobarv2.AddCondition(5, "bar");
        foobarv2.AddCondition(7, "roo");
        foobarv2.UpdateCondition(5, "roo");
        Console.WriteLine(foobarv2.AddCondition(7, "kiwkiw"));  // ?? output: False
        foobarv2.DeleteCondition(5);
        
        Console.WriteLine(foobarv2.GetCondition());             // ?? output 3 => foo\n 7 => roo

    }
}
