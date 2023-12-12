using System;
using System.IO;
namespace FileHandlinDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "MyFile.txt";

            StreamReader streamReader = new StreamReader(filePath);

            Console.WriteLine("Content of the File");
            
            using (StreamReader reader = new StreamReader(filePath))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
            
            Console.ReadKey();
        }
    }
}