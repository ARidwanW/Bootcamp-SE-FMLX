using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
	static async Task Main()
	{
		int[] numbers = { 1, 2, 3, 4, 5 };

		Task<int>[] tasks = numbers.Select(n => MultiplyByTwoAsync(n)).ToArray();

		int[] results = await Task.WhenAll(tasks);


		Console.WriteLine(string.Join(", ", results));

		Task<int> t1 = Task.Run(() => MultiplyByTwoAsync(5));
		await t1;
	}
	static async Task<int> MultiplyByTwoAsync(int number)
	{
		await Task.Delay(500);
		return number * 2;
	}
}