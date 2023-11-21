using Dumper;
void Main()
{
	CustomCollection<int> custom = new CustomCollection<int>(20);
	custom.Add(0, 1);
	custom.Add(1, 3);
	//custom.Add(2, "hello");
	int result = custom.GetValue(1);
	result.Dump();
	
	CustomCollection<string> custom2 = new(2);
	custom2.Add(0,"a");
}
class CustomCollection<T>
{
	T[] myArray;
	public CustomCollection(int arraySize)
	{
		myArray = new T[arraySize];
	}
	public bool Add(int index, T x)
	{
		myArray[index] = x;
		return true;
	}
	public T GetValue(int index)
	{
		return myArray[index];
	}
}