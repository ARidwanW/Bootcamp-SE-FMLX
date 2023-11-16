//Method Hiding
class Program
{
	static void Main()
	{
		Animal animal = new Animal();
		animal.MakeSound();
		
		Cat cat = new Cat();
		cat.MakeSound();
		
		animal = cat;
		animal.MakeSound();
	}
}
class Animal
{
	public void MakeSound()
	{
		"Animal MakeSound".Dump();
	}
}
class Cat 
{
	public void MakeSound()
	{
		"Meow...".Dump();
	}
}
class Dog : Animal
{
	public new void MakeSound()
	{
		"Woof!...".Dump();
	}
}
class Bird : Animal
{
	public void MakeSound()
	{
		"Chip...".Dump();
	}
}
class Ant : Animal { }





