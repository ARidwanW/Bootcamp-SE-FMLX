using Internal;
using System;
// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main()
    {
        Cat cat = new Cat();
        cat.Eat();
        cat.Meow();
        cat.colour = "yellow";
        cat.age = 3;

        Console.WriteLine(cat.colour);
        Console.WriteLine(cat.age);
    }
}
