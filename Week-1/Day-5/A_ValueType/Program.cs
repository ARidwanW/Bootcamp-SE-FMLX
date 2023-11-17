//Value Type
class Program {
	static void Main() {
		int a = 3;      // *Value Type Variable
		int b = a;
		
		b = 5;
		
		a.Dump();       // ??output: 3
		b.Dump();       // ??output: 5
	}
}

//This is Extension Method
public static class IniExtension
{
	public static void Dump(this object x) 
	{
		Console.WriteLine(x.ToString());
	}
}