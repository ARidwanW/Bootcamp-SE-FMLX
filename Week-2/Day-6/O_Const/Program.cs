//Const
class Program
{
	static void Main()
	{
		MathLib math = new();
		 
		MathLib.phi.Dump();
	}
}

class MathLib {
	public const int phi = 314;
}