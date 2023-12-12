class Program
{
    static void Main(string[] args)
    {
        string FilePath = @".\MyFile.txt";
        using (FileStream fileStream = new FileStream(FilePath,
        FileMode.Create, FileAccess.Write, (FileShare.Delete | FileShare.ReadWrite)))
        using (StreamWriter streamWriter = new StreamWriter(fileStream))
        {
            Console.Write($"File has been opened and the Path is {FilePath}");
            streamWriter.WriteLine("ini isinya");
            streamWriter.Flush();
            // await Task.Delay(5000);
            // Console.WriteLine("\n finish delay");
            streamWriter.WriteLine("ini isinya");
            Console.ReadLine();
        }

    }
}