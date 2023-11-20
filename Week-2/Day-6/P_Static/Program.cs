//Static
void Main()
{
	Calculator.Add(3,4).Dump();
}

static class Calculator {
	public static int Add(int a, int b) {
		return a + b;
	}
	public static int Div(int a, int b)
	{
		return a / b;
	}
	public static int Mul(int a, int b)
	{
		return a * b;
	}
	public static int Sub(int a, int b)
	{
		return a * b;
	}
}
