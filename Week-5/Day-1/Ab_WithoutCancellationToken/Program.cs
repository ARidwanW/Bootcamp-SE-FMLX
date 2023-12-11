
static class Program {
	static void Main() 
	{
		DoLongRunningLoop();
		Console.WriteLine("Running Loop Finished");
	}
	static void DoLongRunningLoop()
	{
		for (int i = 0; i < 100; i++) 
		{
			Console.WriteLine($"Task : {i} % ");
			Thread.Sleep(100);
		}
		Console.WriteLine($"Task Completed");
	}
}
