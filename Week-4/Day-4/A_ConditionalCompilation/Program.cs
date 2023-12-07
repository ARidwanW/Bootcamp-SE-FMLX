// #define DEBUG // first come first serve
                    // and DEBUG is default
// #define RELEASE // to run --> "dotnet build -c RELEASE" or "dotnet run -c RELEASE"
class Program
{
    public static void Main()
    {
        #if CODE
        // test code
        MethodA();
        MethodC();
        #elif (RELEASE && DEBUG) 
        // production
        MethodA();
        MethodB();
        MethodC();
        #elif TEST
        MethodB();
        MethodC();
        #else
        Console.WriteLine("nothing");
        #endif

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
        Console.WriteLine("this C");
    }
}
