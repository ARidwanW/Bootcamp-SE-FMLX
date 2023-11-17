//Array Size
void Main()
{
	//C.ReadLine always return string
	string userInput = Console.ReadLine();
	int size = int.Parse(userInput);
	
	//array size config
	var myStringArray = new string[size];
	Console.WriteLine(myStringArray.Length);
}

