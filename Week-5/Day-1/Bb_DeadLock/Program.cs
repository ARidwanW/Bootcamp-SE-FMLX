using System;
using System.Threading.Tasks;

static class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Main Method Started");

        var task1 = Task.Run(async () =>
        {
            Console.WriteLine("Task 1 started");
            await Task.Delay(1000);

            Console.WriteLine("Task 1 waiting for Task 2");
        });
        
        var task2 = Task.Run(async () =>
        {
            Console.WriteLine("Task 2 started");
            await Task.Delay(1000);

            Console.WriteLine("Task 2 waiting for Task 1");
        });

        await Task.WhenAll(task1, task2);

        Console.WriteLine("All tasks completed");
        Console.ReadKey();
    }
}
