using System.Diagnostics;

namespace ExampleApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			
			Trace.Listeners.Clear();
			using(TextWriterTraceListener traceListener = new TextWriterTraceListener("myTraceOutput.txt")) 
			{
				Trace.Listeners.Add(traceListener);
			
				Trace.Assert(true, "This is a trace false.");
				Debug.Assert(false, "This is a DEBUG FALSE.");
				Trace.WriteLine("This is a trace statement.");
			
				traceListener.Flush();
				traceListener.Close();
			}
		}
	}
}
