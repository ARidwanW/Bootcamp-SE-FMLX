using System.Diagnostics;

class Program 
{
    static void Main() 
    {
        int x = 5, y = 7;

        Debug.WriteLine("Starting program...");
        Debug.WriteLine("x = " + x);
        Debug.WriteLine("y = " + y);
        Debug.WriteLine("");

        Trace.WriteLine("Calculating x + y...");
        int sum = x + y;
        Trace.WriteLine("x + y = " + sum);
        Trace.WriteLine("");

        Debug.Assert(sum == 11, "The sum of x and y should be 11");
        Debug.WriteLine("Press any key to exit...");
    }
}
