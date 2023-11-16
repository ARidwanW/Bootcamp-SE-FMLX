// Interface
public interface IPermintaanOrtu    // * best practice using public
{
    void Kuliah();
}
public interface IPermintaanIstri
{
    void Iphone15();
}
class Parent
{
    public string name;
}

// * its like multiple inherit
class Human : Parent, IPermintaanIstri, IPermintaanOrtu
{
    public void Iphone15()
    {
        Console.WriteLine("Besok ya");
    }

    public void Kuliah()
    {
        Console.WriteLine("UMY");
    }
}
