using System.Collections;

class Program 
{
	static void Main() {
		ArrayList myList = new();
		myList.Add(3);
		myList.Add(4);
		myList.Add(5);
		myList.Add(true);
		myList.Add(new Program());
		myList.Add("hello");
		int valueInt = (int)myList[0];
		Console.WriteLine(valueInt);
	}
}