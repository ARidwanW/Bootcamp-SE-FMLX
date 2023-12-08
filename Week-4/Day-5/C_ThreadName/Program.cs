﻿using System;
using System.Threading;

class Program
{
	static void Main()
	{

		Thread thread = new Thread(DoWork);
		Thread secondThread = new Thread(DoWork);


		thread.Name = "Worker Thread";
		secondThread.Name = "Second Worker Thread";


		thread.Start();
		secondThread.Start();

		thread.Join();
		secondThread.Join();
		
		Console.WriteLine("Main thread exiting.");
	}

	static void DoWork()
	{
		Console.WriteLine($"Thread {Thread.CurrentThread.Name} started.");
		Thread.Sleep(2000);
		Console.WriteLine($"Thread {Thread.CurrentThread.Name} finished.");
	}
}