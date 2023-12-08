using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Task task1 = Task.Run(async () => { await Task.Delay(1000); Console.WriteLine("Hello from Task 1!"); });
        Task task2 = Task.Run(async () => { await Task.Delay(1500); Console.WriteLine("Hello from Task 2!"); });
        Task completedTask = await Task.WhenAny(task1, task2);
        Console.WriteLine("First completed task: " + (completedTask == task1 ? "Task 1" : "Task 2"));
    }
}