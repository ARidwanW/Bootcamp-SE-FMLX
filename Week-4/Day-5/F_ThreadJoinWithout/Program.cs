﻿using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Starting program.");

        var task = new Thread(DoTask);

        task.Start();

        Console.WriteLine("Program complete.");
    }

    public static void DoTask()
    {
        Console.WriteLine("Starting task.");
        Thread.Sleep(2000);
        Console.WriteLine("Task complete.");
    }
}