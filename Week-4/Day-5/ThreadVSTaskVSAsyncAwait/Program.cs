using System.Diagnostics;

namespace ThreadPoolApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			for (int i = 0; i < 10; i++)
			{
				MethodWithThread();
				MethodWithTask();
				MethodWithTaskAsyncAwait();
			}
			Stopwatch stopwatch = new Stopwatch();

			Console.WriteLine("Execution using Thread");
			stopwatch.Start();
			MethodWithThread();
			stopwatch.Stop();
			Console.WriteLine("Time consumed by MethodWithThread is : " +
								 stopwatch.ElapsedTicks.ToString());

			stopwatch.Reset();

			Console.WriteLine("Execution using Task (blocked)");
			stopwatch.Start();
			MethodWithTask();
			stopwatch.Stop();
			Console.WriteLine("Time consumed by MethodWithTask is : " +
								 stopwatch.ElapsedTicks.ToString());

			stopwatch.Reset();

			Console.WriteLine("Execution using Thread Pool");
			stopwatch.Start();
			MethodWithTaskAsyncAwait();
			stopwatch.Stop();
			Console.WriteLine("Time consumed by MethodWithTaskAsyncAwait is : " +
								 stopwatch.ElapsedTicks.ToString());

			Console.Read();

		}

		private static void MethodWithTask()
		{
			Task[] myAllTask = new Task[10];
			for (int i = 0; i < 10; i++)
			{
				myAllTask[i] = Task.Run(() => Test());
			}
			Task.WaitAll(myAllTask);
		}

		public static void MethodWithThread()
		{
			Thread[] myAllThread = new Thread[10];
			for (int i = 0; i < 10; i++)
			{
				myAllThread[i] = new Thread(Test);
				myAllThread[i].Start();
			}
			myAllThread[0].Join();
			myAllThread[1].Join();
			myAllThread[2].Join();
			myAllThread[3].Join();
			myAllThread[4].Join();
			myAllThread[5].Join();
			myAllThread[6].Join();
			myAllThread[7].Join();
			myAllThread[8].Join();
			myAllThread[9].Join();
		}

		public static async void MethodWithTaskAsyncAwait()
		{

			Task[] myAllTask = new Task[10];
			for (int i = 0; i < 10; i++)
			{
				myAllTask[i] = Task.Run(() => Test());
			}
			await Task.WhenAll(myAllTask);
		}

		public static void Test()
		{

		}
	}
}