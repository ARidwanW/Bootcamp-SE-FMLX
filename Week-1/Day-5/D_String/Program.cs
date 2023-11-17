//String --> Immutable

// *everytime string is build, reassigned, it will create new address
// *so the memory will be increase
// *but there's garbace collector to clean the unused memory
// *garbage collector run randomly, and stop the program for a while
// *so it takes more time

// *if you want string work like other reference type
// *you can use StringBuilder class

using System.Diagnostics;
class Program {
	static void Main() {
		Stopwatch sw = new Stopwatch();
		int iteration = 100000;
		sw.Start();
		string a = "Hello";
		for (int i = 0; i < iteration; i++)
		{
			a += " World";
			a += " ! ! !";
			a.Replace('o','i');
		}
		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds);
	}
}