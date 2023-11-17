// String Builder --> mutable type of string

// * it will copy the address
// * so if reassigned the variable it will replace the value in the same address
// * but it doesn't need Garbage Collector
// * it safe more time


using System.Text;
using System.Diagnostics;
//StringBuilder
class Program
{
	static void Main()
	{
		Stopwatch sw = new Stopwatch();
		int iteration = 100000;
		sw.Start(); // stopwatch start for below execution
		StringBuilder sb = new();
		sb.Append("Hello");
		for (int i = 0; i < iteration; i++)
		{
			sb.Append(" World");
			sb.Append(" ! ! !");
			sb.Replace('o', 'i');
		}
		sw.Stop();  // stop the stopwatch
		Console.WriteLine(sw.ElapsedMilliseconds);
	}
}