class Program
{
    public static void Main()
    {
        // Thread thread = new Thread(WrapperInternalLibrary);    // using WrapperInternalLibrary instead of Internal Library
                                                        // cause internal library throw exception
        // or u can use
        Thread thread1 = new Thread(() =>
        {
            try{
                InternalLibrary();
            }
            catch{

            }
        });
        
        thread1.Start();

        Console.WriteLine("Program Finished!");

    }

    public static void WrapperInternalLibrary()
    {
        try{
            InternalLibrary();
        }
        catch{

        }
    }

    public static void InternalLibrary()
    {
        throw new Exception("ini exceptioin");
    }
}