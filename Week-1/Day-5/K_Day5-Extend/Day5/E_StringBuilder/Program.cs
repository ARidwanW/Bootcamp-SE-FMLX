using System.Text;
using System.Diagnostics;
//StringBuilder
class Program
{
	static void Main()
	{
		Stopwatch sw = new Stopwatch();
		int iteration = 100000;
		sw.Start();
		StringBuilder sb = new();
		sb.Append("Hello");
		for (int i = 0; i < iteration; i++)
		{
			sb.Append(" World");
			sb.Append(" ! ! !");
			sb.Replace('o', 'i');
		}
		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds);
	}
}