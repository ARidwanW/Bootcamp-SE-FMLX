﻿using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread newThread = new Thread(PrintNumbers);

        newThread.Start();
        
        Thread.Sleep(2000);

        Console.WriteLine($"Is newThread alive? {newThread.IsAlive}");

        newThread.Priority = ThreadPriority.Highest;

        newThread.IsBackground = true;

        newThread.Join();

        Console.WriteLine("Main thread continues.");
        
    }

    static void PrintNumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Thread: {i}");
            Thread.Sleep(1000);
        }
    }
}