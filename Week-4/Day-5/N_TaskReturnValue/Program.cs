using System.Threading.Tasks;

class Program
{
	static void Main()
	{
		int x = 3;
		int y = 4;
		Task<int> task = Task.Run(()=>Add(x,y));
		task.Wait();
		int result = task.Result;
		Console.WriteLine($"Result: {result}");
	}
	
	static int Add(int a, int b)
	{
		Task.Delay(200);
		return a + b;
	}
}