//Object
class Program
{
	static void Main()
	{
		object obja = 3.0f;
		object objb = 2.0f;
		Add(obja,objb);
		
	}
	static void Add(object a,object b) {
		if(a is int && b is int) {
			int resulta = (int)a;
			int resultb = (int)b;
			Console.WriteLine(resulta+resultb);
		}
		if (a is float && b is float)
		{
			float resulta = (float)a;
			float resultb = (float)b;
			Console.WriteLine(resulta + resultb);
		}
		if (a is string && b is string)
		{
			string resulta = (string)a;
			string resultb = (string)b;
			Console.WriteLine(resulta + resultb);
		}
	}
}