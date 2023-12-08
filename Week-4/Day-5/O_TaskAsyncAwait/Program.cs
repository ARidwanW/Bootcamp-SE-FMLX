using System;
using System.Threading.Tasks;

class Program
{
	static async Task Main()
	{
		Task result = Task.Run(() => AddAsync(3, 4));
		await result;
		Console.WriteLine($"Result: {result}");
	}

	static async Task AddAsync(int a, int b)
	{
		// Simulate an asynchronous operation
		await Task.Delay(1000);

		//return a + b;
	}
}