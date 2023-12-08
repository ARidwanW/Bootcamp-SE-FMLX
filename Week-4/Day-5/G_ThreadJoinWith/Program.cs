﻿using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Starting program.");

        Thread thread = new Thread(DoTask);

        thread.Start();
        thread.Join();

        Console.WriteLine("Program complete.");
    }

    public static void DoTask()
    {
        Console.WriteLine("Starting task.");
        Thread.Sleep(2000);
        Console.WriteLine("Task complete.");
    }
}