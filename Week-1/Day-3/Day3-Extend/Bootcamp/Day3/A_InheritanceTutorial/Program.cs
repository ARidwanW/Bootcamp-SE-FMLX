//Inheritance Tutorial
class Program {
	static void Main() 
	{
		Cat cat = new Cat();
		cat.Eat();
		cat.Meow();
		cat.colour = "yellow";
		cat.age = 3;
		
		cat.colour.Dump();
		cat.age.Dump();
	}
}

class Animal
{
	public string colour;
	public int age;
	public Animal() //Constructor
	{
		"Animal Created".Dump();	
	}
	public void Eat()
	{
		"Animal Eat".Dump();
	}
}
class Cat : Animal 
{
	public Cat() {
		"Cat Created".Dump();
	}
	public void Meow() {
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