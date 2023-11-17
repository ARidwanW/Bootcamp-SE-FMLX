//Mutable immutable
class Program {
	static void Main() {
		string a = "3";     // * this string is immutable
		string b = a;
		
		b = "5";
		
		a.Dump();
		b.Dump();
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