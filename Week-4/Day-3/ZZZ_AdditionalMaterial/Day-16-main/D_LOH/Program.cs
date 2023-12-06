using System;

namespace LOHDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] largeArray = new float[100 * 1024];  // 400 KB

            Console.WriteLine("Large object allocated on the LOH.");
            Console.ReadKey();
        }
    }
}
