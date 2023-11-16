// *Abstraction
// *Abstract class

class Program
{
    static void Main()
    {
        // ! abstract class cannot be build
        // Rumah r = new Rumah();

        // ?? Instead we can build below
        RumahMewah rm = new RumahMewah();
        RumahBiasa rb = new RumahBiasa();
        RumahSederhana rs = new RumahSederhana();

        // ?? we can assign parent with any child value
        // Rumah rumah = rm;
        // Rumah rumah = rb;
        Rumah rumah = rs;

        // ?? jika rs tidak memiliki method BukaPintu
        // ?? maka rs akan mengambil dari fathernya rb

        rumah.BukaPintu();
    }
}

// * abstract class can without non abstract method 
abstract class Rumah
{
    public readonly int i;

    // Non abstract method
    public void BukaJendela()
    {
        Console.WriteLine("Buka Jendela");
    }

    // virtual method (overriding)
    public virtual void BukaGarasi()
    {
        Console.WriteLine("Ke atas");
    }

    // abstract method
    public abstract void BukaPintu();
}

class RumahMewah : Rumah
{
    // * Child must override abstract method from parent
    public override void BukaPintu()
    {
        Console.WriteLine("Keatas");
    }
}

class RumahBiasa : Rumah
{
    public override void BukaPintu()
    {
        Console.WriteLine("Ke depan");
    }
}

// ??Child from Child or GrandChild
// ??doesn't require to override father method or grandpa method
class RumahSederhana : RumahBiasa
{
    public new void BukaPintu()
    {
        Console.WriteLine("Gorden");
    }
}
