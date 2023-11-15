namespace CalculatorLib;

public class Calculator
{
	public void Add(int a, int b) 
	{
		int result = a + b;
		Console.WriteLine(result);
	}
	public int Multiply(int a, int b) 
	{
		return a * b;
	}
	public int Subtraction(int a, int b = 0) 
	{
		return a - b;
	}
	public float Subtraction(float a, float b = 0) 
	{
		return a - b;
	}
	public float Subtraction(float a, int y, float b = 0) 
	{
		return a - b;
	}
	public int Addition(params int[] input) 
	{
		int result = 0;
		foreach(int a in input) 
		{
			//result = result + a;
			result += a;
		}
		return result;
	}
}
