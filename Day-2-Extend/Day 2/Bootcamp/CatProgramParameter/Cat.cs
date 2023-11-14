namespace CatProgramParameter;

public class Cat
{
	public string name;
	public int age;
	public float weight;

	public Cat()
	{
		name = "cat";
		age = 0;
		weight = 0f;
	}

	public Cat(string name, int age, float weight)
	{
		this.name = name;
		this.age = age;
		this.weight = weight;
	}

	public void Sleep()
	{
		Console.WriteLine("Cat Sleep");
	}
	public void Eat(string makanan)
	{
		Console.WriteLine("Cat eating " + makanan);
		Console.WriteLine($"Cat Eating {makanan}");
	}
}
