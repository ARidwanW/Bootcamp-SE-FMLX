namespace Dumper;
public static class MyExtension
{
    public static void Dump(this object x)
    {
        Console.WriteLine(x.ToString());
    }
}
