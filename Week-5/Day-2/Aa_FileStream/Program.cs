using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string FilePath = @".\MyFile.txt";
        using (FileStream fileStream = new FileStream(FilePath,
        FileMode.Create, FileAccess.Write, FileShare.None))
        {
            byte[] toWrite = Encoding.UTF8.GetBytes("Ini isinya");
            Console.Write($"File has been opened and the Path is {FilePath}");
            fileStream.Write(toWrite, 0, toWrite.Length);
            Console.ReadLine();
        }
    }
    // static async Task Main(string[] args)
    // {
    //     string FilePath = @".\MyFile.txt";
    //     using (FileStream fileStream = new FileStream(FilePath,
    //     FileMode.Create, FileAccess.Write, (FileShare.Delete | FileShare.ReadWrite)))
    //     {
    //         byte[] toWrite = Encoding.UTF8.GetBytes("Ini isinya");
    //         Console.Write($"File has been opened and the Path is {FilePath}");
    //         fileStream.Write(toWrite, 0, toWrite.Length);
    //         //fileStream.Flush();
    //         await Task.Delay(100);
    //         Console.WriteLine("\n finish delay");
    //         fileStream.Write(toWrite, 0, toWrite.Length);
    //         Console.ReadLine();
    //     }
    // }
}