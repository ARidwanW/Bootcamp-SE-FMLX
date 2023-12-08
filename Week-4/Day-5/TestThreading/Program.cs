class Program
{
    public static void Main()
    {
        Console.WriteLine("Start");
        Thread threada = new Thread(MethodA);
        Thread threadb = new Thread(MethodB);
        Thread threadc = new Thread(MethodC);
        Thread threadd = new Thread(MethodD);
        // threadb.Start();
        // threadc.Start();
        // threada.Start();
        // threada.Join();


        threada.Start();
        // threada.Join();
        threadb.Start();
        // threadb.Join();
        // threadd.Start();
        threadc.Start();
        threadd.Start();
        threadc.Join();


        // Jika Main Thread ingin menunggu 3 sub thread yang lain
        // dapat menggunakan join
        // threada.Join();
        // threadb.Join();
        // threadc.Join();
        Console.WriteLine("Finish");
        // threada.Join();
        // threadb.Join();
        // threadc.Join();


    }

    static void MethodA()
    {
        Console.WriteLine("this A");
    }

    static void MethodB()
    {
        Console.WriteLine("this B");
    }

    static void MethodC()
    {
        for(int i=0; i< 10; i++)
        {
            string ms = i.ToString();
        }
        string mc = "This C";
        Console.WriteLine(mc);
    }

    static void MethodD()
    {
        Console.WriteLine("this D");
    }
}
