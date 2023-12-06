class Program
{
	static void Main()
	{
		string path = @"./myFile.txt";
		using(FileStream file = new FileStream(path ,FileMode.Create)) 
		{
			using(StreamWriter sw = new(file))
			{
				sw.WriteLine("Hello");
			} //sw.Dispose() will be called here
		} //file.Dispose() will be called here
	}
}