using System.Text;

// //* CreateNew
//     //* minimal FileAccess.Write
//     //* if exist, throw exceptions

// using (FileStream fs = new FileStream("./createFile.txt", FileMode.CreateNew, FileAccess.Write)) 
// {
//     string hello = "hello";
//     byte[] writeString = Encoding.UTF8.GetBytes(hello);
//     // fs.Write(writeString);
//     // or
//     fs.Write(writeString, 0 , writeString.Length);  //* buffer, offset, count
// }

//* Create
    //* minimal FileAccess.Write
    //* if exist, throw exceptions

using (FileStream fs = new FileStream("./createFile.txt", FileMode.Create, FileAccess.Write)) 
{
    string hello = "hello";
    byte[] writeString = Encoding.UTF8.GetBytes(hello);
    // fs.Write(writeString);
    // or
    fs.Write(writeString, 0 , writeString.Length);  //* buffer, offset, count
}

//* Open
using (FileStream fs = new FileStream("./createFile.txt", FileMode.Open, FileAccess.Read))
{
    // create buffer to save the stream
    byte[] myBytes = new byte[fs.Length];
    fs.Read(myBytes, 0, myBytes.Length);
    string result = Encoding.UTF8.GetString(myBytes);
    Console.WriteLine(result);
}

//* StreamWriter
using(FileStream fs = new FileStream("./streamWriter.txt", FileMode.Create, FileAccess.Write))
using(StreamWriter sw = new StreamWriter(fs))
{
    // sw.WriteLine("swack buck!!");
    // await sw.WriteLineAsync("swack buck!!");
    // await sw.WriteLineAsync("Smash up!!");
    sw.Write(@"Hello from the other side
this maybe a new line right?
this also the third line hmmm");
}

//* StreamReader
using(FileStream fs = new FileStream("./streamWriter.txt", FileMode.Open, FileAccess.Read))
using(StreamReader sr = new StreamReader(fs))
{
    // Console.WriteLine(sr.ReadLine());
    // Console.WriteLine(await sr.ReadLineAsync());
    // Console.WriteLine(await sr.ReadLineAsync());
    Console.WriteLine(sr.ReadToEnd());
}