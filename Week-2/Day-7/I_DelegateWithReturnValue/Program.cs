//Delegate Return Value
using Dumper;
public delegate int MyDelegate(int a, int b);
public class Program {
	static void Main() {
		Calculator calc = new();
		MyDelegate del = calc.Add;
		del += calc.Sub;
		
		int result = del.Invoke(10,9);
		result.Dump();
	}
}
public class Calculator{
	public int Add(int a, int b) {
		return a + b;
	}
	public int Sub(int a, int b) {
		return a - b;
	}
}