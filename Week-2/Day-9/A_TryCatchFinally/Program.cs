class Program {
	static void Main()
	{
		int a = 10;
		int b = 0;
		try {
			int result = a / b;
		}
		catch (FormatException e) 
		{
			Console.WriteLine($"{e.Message}");
		}
		finally 
		{
			//Release unmanaged resource
			Console.WriteLine("Finally");
		}
		Console.WriteLine("Program finished");
	}
}