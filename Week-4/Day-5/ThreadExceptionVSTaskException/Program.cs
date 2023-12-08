class Program 
{
	static void Main() 
	{
		// try
		// {
		// 	Thread t1 = new Thread(MethodException);
		// 	t1.Start();
		// 	t1.Join();
		// }
		// catch(Exception e) 
		// {
		// 	Console.WriteLine(e.Message);
		// }
		
		try 
		{
			Task task1 = new Task(MethodException);
			task1.Start();
			task1.Wait(); 
		}
		catch(AggregateException e) 
		{
			Console.WriteLine(e.Message);
		}
		
	}
	static void MethodException() 
	{
		throw new ArgumentException("This is thread");
	}
}