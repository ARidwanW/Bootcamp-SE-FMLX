namespace Animal;

public class Cat
{
    public string name;
    public Cat(string name = "NoName")
    {
        this.name = name;
        Console.WriteLine($"A new cat named {this.name} has exist!");
    }
}
