using System;
using System.Diagnostics;

class Program {
	static void Main() {
		string text = String.Empty;
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		for (int i = 0; i < 100000; i++) {
			text += "a";
			text += "b";
			text = text.Replace('a', 'c');
		}
		stopwatch.Stop();
		Console.WriteLine(stopwatch.ElapsedMilliseconds);
	}
}
