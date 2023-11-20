//Parsing
//And tryParse
void Main()
{
	//string a = "30a";
	//int result = int.Parse(a);
	//result.Dump();

	string b = "30a";
	int value;
	bool status = int.TryParse(b, out value);
	status.Dump();
	value.Dump();
}

