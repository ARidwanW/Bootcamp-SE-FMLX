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

class Animal
{
    public string colour;
    public int age;
    public Animal() // Constructor
    {
        Console.WriteLine("Animal Created");
    }
    public void Eat()
    {
        Console.WriteLine("Animal Eat");
    }
}

class Cat : Animal
{
    public Cat()
    {
        Console.WriteLine("Cat Created");
    }
    public void Meow()
    {
        Console.WriteLine("Meow...");
    }
}
