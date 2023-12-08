using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Task task = Task.Run(() => Console.WriteLine("Hello from Task!"));
        task.Wait();

        Console.WriteLine($"IsCompleted: {task.IsCompleted}"); //Complete
        Console.WriteLine($"IsFaulted: {task.IsFaulted}"); //Complete because Exception
        Console.WriteLine($"IsCanceled: {task.IsCanceled}"); //Complete because CancellationToken
    }
}