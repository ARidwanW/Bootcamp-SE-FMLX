static class Program
{
    static void Main(string[] args)
    {
        int counter = 0;
        bool isRunning = true;

        Thread thread1 = new Thread(() =>
        {
            while (isRunning)
            {
                counter++;
                Console.WriteLine($"Thread 1: counter = {counter}");
            }
        });
        Thread thread2 = new Thread(() =>
        {
            Thread.Sleep(5000);
            isRunning = false;
            Console.WriteLine("Thread 2: isRunning = false");
        });

        thread1.Start();
        thread2.Start();
    }
}