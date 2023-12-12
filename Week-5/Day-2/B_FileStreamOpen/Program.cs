using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string FilePath = "MyFile.txt";

        //* Append -> like open but seek end of line
        using (FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write))
        {
            byte[] bytedata = Encoding.UTF8.GetBytes("C# Is an Object Oriented Programming Language");

            //*array (bytedata): The buffer containing data to write to the stream.
            //*offset (0): The zero-based byte offset in the array from which to begin copying bytes to the stream.
            //*count (bytedata.Length): The maximum number of bytes to write.
            Console.WriteLine(bytedata.Length);
            fileStream.Write(bytedata, 0, bytedata.Length);
        }
        Console.WriteLine("Successfully saved file with data : C# Is an Object Oriented Programming Language");
        Console.ReadKey();
    }
}