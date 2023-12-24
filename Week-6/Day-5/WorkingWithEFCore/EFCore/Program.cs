using EFDatabase;

class MainProgram
{
	static void Main() 
	{
		using(Northwind db = new Northwind()) 
		{
			Console.WriteLine($"Name: {db.Database}");
			Console.WriteLine($"Database: {db.Database.ProviderName}");
			Console.WriteLine($"Database: {db.Database.CanConnect()}");
		}
	}
}