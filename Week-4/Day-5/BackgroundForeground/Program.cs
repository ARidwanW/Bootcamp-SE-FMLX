﻿using System;
using System.Threading;

namespace ForeGroundBackground
{
	public class Program
	{
		static void Main(string[] args)
		{
			Thread thread1 = new Thread(Method1)
			{
				IsBackground = false
			};
			
			Console.WriteLine($"Thread1 is a Background thread:  {thread1.IsBackground}");
			thread1.Start();
			
			Console.WriteLine("Main Thread Exited");
		}

		static void Method1()
		{
			Console.WriteLine("Method1 Started");
			for (int i = 0; i <= 5; i++)
			{
				Console.WriteLine("Method1 is in Progress!!");
				Thread.Sleep(1000);
			}
			Console.WriteLine("Method1 Exited");
			Console.WriteLine("Press any key to Exit.");
			Console.ReadKey();
		}
	}
}