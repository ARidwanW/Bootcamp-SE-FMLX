#define GAMETESTER

class Program
{
    static void Main()
    {
        #if GAMERUNNER
        Console.WriteLine("GameRunner.");

        #elif GAMETESTER
        Console.WriteLine("GameTester.");

        #else 
        Console.WriteLine("Not Anything.");
        #endif
        Console.WriteLine("Finish");
    }
}
