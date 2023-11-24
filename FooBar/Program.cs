using System.Text;
using FooBarLib;


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
        FooBarV2<string> foobarv2 = new FooBarV2<string>();

        Dictionary<int, string> condition = new Dictionary<int, string>() {
            {3, "foo"},
            {7, "baz"}
        };

        // Console.WriteLine( foobarv2.AddCondition(3, "foo"));    // ?? output: True
        // foobarv2.AddCondition(5, "bar");
        // foobarv2.AddCondition(7, "roo");
        // foobarv2.UpdateCondition(5, "roo");
        // Console.WriteLine(foobarv2.AddCondition(7, "kiwkiw")); 
        // foobarv2.RemoveCondition(5);
        foobarv2.AddCondition(condition);
        foobarv2.UpdateCondition(5, "bar");
        // foobarv2.AddIterator(2);            // ?? output: 1 2
        // foobarv2.AddIterator(1, 2, 3, 4);   // ?? output: 1 2 1 2 3 4
        // foobarv2.UpdateIterator(0, 2);      // ?? output: 2 2 1 2 3 4
        // foobarv2.RemoveIterator(0);         // ?? output: 2 1 2 3 4
        // foobarv2.RemoveIterator(0);         // ?? output: 1 2 3 4
        // foobarv2.RemoveIterator(0);         // ?? output: 2 3 4
        // foobarv2.RemoveIterator(0);         // ?? output: 3 4
        
        Console.WriteLine(foobarv2.GetCondition());             // ?? output if no condition: 3 => foo\n 7 => roo
        // Console.WriteLine(foobarv2.Next(0, 15));
        // Console.WriteLine(foobarv2.Next(0, 15));
        // Console.WriteLine(foobarv2.Next(15, 0));
        // Console.WriteLine(foobarv2.Next(30, 0));
        // Console.WriteLine(foobarv2.Next(20));
        // Console.WriteLine(foobarv2.Next(-15));

    }
}
