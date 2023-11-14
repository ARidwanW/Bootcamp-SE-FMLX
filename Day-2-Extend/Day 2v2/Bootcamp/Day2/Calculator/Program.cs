using CalculatorLib;
class Program
{
	static void Main() 
	{
		Calculator calc = new Calculator();
		calc.Add(3, 4);

		int result = calc.Multiply(3, 4);
		Console.WriteLine(result);
		
		int result2 = calc.Subtraction(3 , 4);
		Console.WriteLine(result2);
		
		int result3 = calc.Subtraction(3 , 4);
		Console.WriteLine(result3);

		int[] arrayInt = { 3, 4, 5, 6, 7, 8, 9, 10 };
		int result4 = calc.Addition(arrayInt);
		Console.WriteLine(result4);
	}
}