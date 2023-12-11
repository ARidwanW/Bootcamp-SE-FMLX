using System;
using System.Threading.Tasks;

class Program
{
	static async Task Main()
	{
		Console.WriteLine("Starting the operation...");
        Task a =  Task.Delay(10000);
		Task b = DoWorkAsync();
        await Task.WhenAll(a,b);
		Console.WriteLine("Operation completed.");
	}

	static async Task DoWorkAsync()
	{
		Console.WriteLine("Starting the asynchronous work...");
		await Task.Delay(3000); // Simulates an async operation taking 2 seconds
		Console.WriteLine("Asynchronous work completed.");
	}
}

// using System.Diagnostics;

// namespace ThreadPoolApplication
// {
// 	class Program
// 	{
// 		static void Main(string[] args)
// 		{
// 			for (int i = 0; i < 10; i++)
// 			{
// 				MethodWithThread();
// 				MethodWithTask();
// 				MethodWithTaskAsyncAwait();
// 			}
// 			Stopwatch stopwatch = new Stopwatch();

// 			Console.WriteLine("Execution using Thread");
// 			stopwatch.Start();
// 			MethodWithThread();
// 			stopwatch.Stop();
// 			Console.WriteLine("Time consumed by MethodWithThread is : " +
// 								 stopwatch.ElapsedTicks.ToString());

// 			stopwatch.Reset();

// 			Console.WriteLine("Execution using Task (blocked)");
// 			stopwatch.Start();
// 			MethodWithTask();
// 			stopwatch.Stop();
// 			Console.WriteLine("Time consumed by MethodWithTask(threadBlock) is : " +
// 								 stopwatch.ElapsedTicks.ToString());

// 			stopwatch.Reset();

// 			Console.WriteLine("Execution using MethodWithTaskAsyncAwait");
// 			stopwatch.Start();
// 			MethodWithTaskAsyncAwait();
// 			stopwatch.Stop();
// 			Console.WriteLine("Time consumed by MethodWithTaskAsyncAwait is : " +
// 								 stopwatch.ElapsedTicks.ToString());

// 			Console.Read();

// 		}

// 		private static void MethodWithTask()
// 		{
// 			Task[] myAllTask = new Task[10];
// 			for (int i = 0; i < 10; i++)
// 			{
// 				myAllTask[i] = Task.Run(() => Test());
// 			}
// 			Task.WaitAll(myAllTask);
// 		}

// 		public static void MethodWithThread()
// 		{
// 			Thread[] myAllThread = new Thread[10];
// 			for (int i = 0; i < 10; i++)
// 			{
// 				myAllThread[i] = new Thread(Test);
// 				myAllThread[i].Start();
// 			}
// 			myAllThread[0].Join();
// 			myAllThread[1].Join();
// 			myAllThread[2].Join();
// 			myAllThread[3].Join();
// 			myAllThread[4].Join();
// 			myAllThread[5].Join();
// 			myAllThread[6].Join();
// 			myAllThread[7].Join();
// 			myAllThread[8].Join();
// 			myAllThread[9].Join();
// 		}

// 		public static async void MethodWithTaskAsyncAwait()
// 		{

// 			Task[] myAllTask = new Task[10];
// 			for (int i = 0; i < 10; i++)
// 			{
// 				myAllTask[i] = Task.Run(() => Test());
// 			}
// 			await Task.WhenAll(myAllTask);
// 			// await Task.WaitAll(myAllTask); // not awaitable
// 		}

// 		public static void Test()
// 		{

// 		}
// 	}
// }
