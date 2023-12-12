
//! Not implement IDisposable
// using(FileInfo fileInfo = new FileInfo("./usingFileInfo.txt"))
// {

// }

string path = "./usingFileInfo.txt";
FileInfo fileInfo = new FileInfo(path);
using(StreamWriter writer = fileInfo.CreateText())    //.Create ; .CreateText
{
    writer.WriteLine("coba gunakan using pada fileinfo");
    Console.ReadKey();
}
