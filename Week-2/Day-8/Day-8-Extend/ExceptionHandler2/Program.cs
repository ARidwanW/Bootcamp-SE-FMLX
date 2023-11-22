//Exception Handler
// try - catch
// try = execute
// catch = if try throw exception, will catched by `catch`
class Program
{
	static void Main()
	{
		
		try
		{
			Console.WriteLine("Program initialized");
			int a = 10;
			int b = 0;
			Console.WriteLine("Program running");
			//int[] myInt = {1,2,3};
			//int result = a / b;
			string myString = "30A";
			int result = int.Parse(myString); //FormatException
			Console.WriteLine("Program finish");
		}

		catch (DivideByZeroException e)
		{
			Console.WriteLine($"{e.Message}");
		}
		catch (IndexOutOfRangeException e)
		{
			Console.WriteLine($" index out ");
		}
		catch (Exception e)
		{
			Console.WriteLine($"{e.Message}");
		}

	}
	static void Runner()
	{
		Runner();
	}
}