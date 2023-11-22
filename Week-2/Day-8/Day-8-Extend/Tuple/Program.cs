using Dumper;
//Tuple
class Program {
	static void Main(){
		(bool,int) result = Calculator.Add(3,4);
		bool status = result.Item1;
		int value = result.Item2;
		status.Dump();
		value.Dump();
	}
}
class Calculator {
	public static (bool, int) Add(int a, int b) {
		if (a+b > 0) {
			return (true, a+b);
		}
		return (false, 0);
	}
}