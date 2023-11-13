// See https://aka.ms/new-console-template for more information
// * Top Level Statement --> .NET 5.0
// Console.WriteLine("Hello, World!");

// * General
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        // Console.WriteLine("Hello, general");
        Cat pokari = new Cat();
        pokari.colour = "yellow";
        pokari.Eat();
        pokari.isMale = true;
        Console.WriteLine(pokari.colour);

        Cat jiji = new Cat();
        jiji.colour = "black";
        Console.WriteLine(jiji.colour);

        Cat coki = new Cat();
        coki.colour = "white";
        Console.WriteLine(coki.colour);

        Cat tompel = new Cat();
        tompel.colour = "grey";
        Console.WriteLine(tompel.colour);
    }
}

class Cat    // class name : first general
{
    // Variable / Field
    public string colour;
    public int age;
    public bool isMale;
    public float weight;

    // Contructor
    public Cat( string colour = "yellow")
    {
        this.colour = colour;
    }

    // Method / Function
    public void Eat()
    {
        Console.WriteLine("Eat");
    }
    public void Sleep()
    {
        Console.WriteLine("Sleep");
    }
    public void Chaos()
    {
        Console.WriteLine("Chaos");
    }
    public void Meow()
    {
        Console.WriteLine("Meow");
    }

}
