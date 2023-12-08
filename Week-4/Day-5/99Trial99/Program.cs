﻿using System;
using System.Threading.Tasks;

class Program
{
	static async Task Main()
	{
		// Using GetAwaiter with Task<int>
		Task<int> task = CalculateResultAsync();
		task.GetAwaiter().OnCompleted(() => Console.WriteLine($"Result using GetAwaiter: {task.Result}"));

        Console.ReadKey();
    }

	static async Task<int> CalculateResultAsync()
	{
		await Task.Delay(1000); // Simulate some asynchronous operation
		return 488882; // Return the result
	}
}