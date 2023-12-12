using System.IO;

class Program {
	static void Main() {
		string path = @".\bootcamp.txt";

		// Write some text data to the file
		using (StreamWriter writer = new StreamWriter(File.Open(path, FileMode.Append))) {
			writer.WriteLine("Hello, StreamWriter!");
			writer.WriteLine("This is another line of text.");
		}

		// Read the text data from the file
		using (StreamReader reader = new StreamReader(File.Open(path, FileMode.Open))) {
			string line1 = reader.ReadLine();
			string line2 = reader.ReadLine();
			reader.BaseStream.Position = 0;
			Console.WriteLine(line1);
			Console.WriteLine(line2);
			Console.WriteLine(reader.ReadLine());
		}
	}
}
