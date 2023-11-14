namespace Animal;

public class Cat
{
    public string name;
    public string colour;
    public int age;
    public Cat(string name = "No Name", string colour = "No Colour", int age = 0)
    {
        this.name = name;
        this.colour = colour;
        this.age = age;
        Console.WriteLine($"A new cat named {this.name} has exist!");
        Console.WriteLine($"{this.name} has {this.colour} colour and {this.age} years old");
    }

    public void Eat() {
        Console.WriteLine($"{this.name} is eating!");
    }
    public void Sleep() {
        Console.WriteLine($"{this.name} is sleeping!");
    }
    public void Meow() {
        Console.WriteLine($"{this.name}: Meowww!");
    }
}
