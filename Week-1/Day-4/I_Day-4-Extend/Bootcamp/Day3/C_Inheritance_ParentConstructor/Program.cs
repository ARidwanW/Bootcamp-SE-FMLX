//Inheritance
//Parent Constructor not Parameterless
class Program
{
	static void Main()
	{
		Cat cat = new Cat();
		
		cat.colour.Dump();
		cat.age.Dump();
	}
}

class Animal
{
	public string colour;
	public int age;
	public Animal(string colour, int age) //Constructor
	{
		this.colour = colour;
		this.age = age;
		"Animal Created".Dump();
	}
	public void Eat()
	{
		"Animal Eat".Dump();
	}
}
class Cat : Animal
{
	public Cat() : base("no colour", 0)
	{
		"Cat Created".Dump();
	}
	public void Meow()
	{
		"Meow...".Dump();
	}
}

//This is Extension Method
public static class IniExtension
{
	public static void Dump(this object x) 
	{
		Console.WriteLine(x.ToString());
	}
}