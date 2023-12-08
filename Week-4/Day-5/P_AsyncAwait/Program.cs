using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting the operation...");
        await DoWorkAsync();
        Console.WriteLine("Operation completed.");
    }

    static async Task DoWorkAsync()
    {
        Console.WriteLine("Starting the asynchronous work...");
        await Task.Delay(2000); // Simulates an async operation taking 2 seconds
        Console.WriteLine("Asynchronous work completed.");
    }
}