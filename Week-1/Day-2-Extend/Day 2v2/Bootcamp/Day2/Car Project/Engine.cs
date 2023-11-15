namespace CarComponent;

public class Engine //PascalCase
{
	public int totalCylinder; //camelCase
	public string brand;
	public Engine(int cylinder, string brand) 
	{
		totalCylinder = cylinder;
		this.brand = brand;
	}
	public void EngineTest() 
	{
		Console.WriteLine("engine check");
	}
}
