global using Dumper;
//Non Generic
void Main()
{
	CustomCollection custom = new CustomCollection(20);
	custom.Add(0, "hello");
	custom.Add(1, 3);
	custom.Add(2, true);
	
	object result = custom.GetValue(1);
	string resultfromobject = (string)result;
	resultfromobject.Dump();
}
class CustomCollection {
	object[] myArray;
	public CustomCollection(int arraySize) {
		myArray = new object[arraySize];
	}
	public bool Add(int index, object x) {
		myArray[index] = x;
		return true;
	}
	public object GetValue(int index)
	{
		return myArray[index];
	}
}
class CustomCollectionInt
{
	int[] myArray;
	public CustomCollectionInt(int arraySize)
	{
		myArray = new int[arraySize];
	}
	public bool Add(int index, int x)
	{
		myArray[index] = x;
		return true;
	}
	public object GetValue(int index)
	{
		return myArray[index];
	}
}
class CustomCollectionString
{
	string[] myArray;
	public CustomCollectionString(int arraySize)
	{
		myArray = new string[arraySize];
	}
	public bool Add(int index, string x)
	{
		myArray[index] = x;
		return true;
	}
	public object GetValue(int index)
	{
		return myArray[index];
	}
}


