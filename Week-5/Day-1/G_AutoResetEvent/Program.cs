namespace AutoResetEvents
{
    class Program
    {
        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        //* if true immediately reset and releasing
        
        static void Main(string[] args)
        {
            Thread newThread = new Thread(SomeMethod)
            {
                Name = "NewThread"
            };
            newThread.Start(); 
            Console.ReadLine();
            autoResetEvent.Set();
        }
        static void SomeMethod()
        {
            Console.WriteLine("Starting........");
            autoResetEvent.WaitOne(); 
            Console.WriteLine("Finishing........");
      		Console.ReadLine();
        }
    }
}
