//Upcast Downcast
//Explicit is use of (...)
//Implicit not use (...)

static void Main() {
	int a  = 3;
	double b = a;   // * implicit
	b.Dump();
	
	double c = 3.1;
	int d = (int)c; // * explicit
	d.Dump();
}

//This is Extension Method
public static class IniExtension
{
	public static void Dump(this object x) 
	{
		Console.WriteLine(x.ToString());
	}
}