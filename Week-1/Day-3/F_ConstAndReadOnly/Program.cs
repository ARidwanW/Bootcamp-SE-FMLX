//Const vs ReadOnly
class Program {
	static void Main(){
		Calculator calc = new Calculator(10);
		calc.g.Dump();
		// calc.g = 11; <- it will error
		// Const must be assigned before compilation
		// ReadOnly can be assigned via constructor
	}
}
class Calculator {
	public const float phi = 3.14f;
	public readonly int g;
	public Calculator(int x) {
		g = x;
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