namespace CatProgramParameter;

public class Cat
{
	public string name;
	public int age;
	public float weight;
	
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
