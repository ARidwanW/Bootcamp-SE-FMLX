using System.Diagnostics;

static class Program
{
	static void Main()
	{
		int userID = 123123;
		string pass = "pass";
		Debug.WriteLine(userID + "	 " + pass);
		Trace.WriteLine("Userid and password inserted");
		
		Debug.Assert(true, "DebugAssert says, I am watching!");
		Trace.Assert(true, "TraceAssert says, I am watching!");
		
		Console.WriteLine("Finish");
	}
}