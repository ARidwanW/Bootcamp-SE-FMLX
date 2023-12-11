using System;
using System.Threading;
using System.Threading.Tasks;

static class Program
{  
	static int counter = 0;

	static async Task Main()
	{
		var task1 = IncrementCounterAsync();
		var task2 = IncrementCounterAsync();

		await Task.WhenAll(task1, task2);

		Console.WriteLine($"Final Counter: {counter}");
		Console.ReadKey();
	}

	static async Task IncrementCounterAsync()
	{
		for (int i = 0; i < 100; i++)
		{
			counter++;
            await Task.Delay(100);
            Console.WriteLine($"Counter from: {counter}");
		}
	}
}
