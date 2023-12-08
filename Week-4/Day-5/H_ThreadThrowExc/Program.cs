using System;
using System.Threading;

class Program
{
	static void Main()
	{
		Thread thread = new Thread(() => { throw new InvalidOperationException("An error occurred!"); });

		try
		{
			thread.Start();
			thread.Join();
		}
		catch (Exception ex)
		{
			Console.WriteLine("Exception caught: " + ex.Message);
		}
	}
}