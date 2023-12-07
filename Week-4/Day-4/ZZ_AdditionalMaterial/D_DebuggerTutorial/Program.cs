using System.Diagnostics;
namespace Namespace
{
	static class Program
	{
		static void Main()
		{
			double a = 4.0;
			double b = 2.5;
			double answer = Add(a, b);
			Car car = new Car();
			double[] myArray = new double[2] { a, b };
			Console.WriteLine($"{a} + {b} = {answer}");
			string x = Console.ReadLine();
			Console.WriteLine(x);
		}
		static double Add(double a, double b)
		{
			Console.WriteLine(a);
			Console.WriteLine(b);
			double result = a + b;
			return result;
		}
	}
	class Car {
		public string y = "name";
	}
}