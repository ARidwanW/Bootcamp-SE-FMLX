//Delegate Return Value
using Dumper;
public delegate int MyDelegate(int a, int b);
public class Program
{
	static void Main()
	{
		Calculator calc = new();
		MyDelegate del = calc.Add;
		del += calc.Sub;

		Delegate[] delegateList = del.GetInvocationList();
		int[] result = new int[delegateList.Length];
		int count = 0;
		foreach(MyDelegate d in delegateList) {
			result[count] = d.Invoke(10,9);
			count++;
		}
		foreach(int i in result) {
			i.Dump();
		}
	}
}
public class Calculator
{
	public int Add(int a, int b)
	{
		return a + b;
	}
	public int Sub(int a, int b)
	{
		return a - b;
	}
}