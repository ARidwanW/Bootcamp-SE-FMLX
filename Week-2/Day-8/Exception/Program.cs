//Exception Example
class Program {
	static void Main() {
		Console.WriteLine("Program initialized");
		int a = 10;
		int b = 0;
		Console.WriteLine("Program running");
		//int result = a/b; //DivideByZeroException
		//int[] myInt = {1,2,3};
		//int result = myInt[3]; //IndexOutOfRangeException
		//string myString = "30A";
		//int result = int.Parse(myString); //FormatException
		//dynamic myDynamic = 3;
		//int result = myDynamic.Length; //RuntimeBinderException
		//string? hello = null;
		//int result = hello.Length; //NullReferenceException
		//Runner(); //StackOverFlowException
		Console.WriteLine("Program finish");
	}
	static void Runner() {
		Runner();
	}
}