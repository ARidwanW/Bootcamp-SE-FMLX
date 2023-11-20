//Object
//Pattern Matching
class Program
{
	static void Main()
	{
		object obja = 3;
		object objb = 2;
		Add(obja, objb);

	}
	static void Add(object a, object b)
	{
		//Syntatic Sugar
		//Pattern Matching
		if (a is int inta && b is int intb)
		{
			Console.WriteLine(inta + intb);
		}
		if (a is float floata && b is float floatb)
		{
			Console.WriteLine(floata + floatb);
		}
		if (a is string stringa && b is string stringb)
		{
			Console.WriteLine(stringa + stringb);
		}
	}
}