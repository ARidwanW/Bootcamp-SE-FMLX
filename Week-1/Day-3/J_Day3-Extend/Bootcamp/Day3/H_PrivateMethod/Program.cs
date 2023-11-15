
class Program{
	static void Main() {
		Car car = new Car("a",3);
		car.EngineRun();
	}
}
class Car
{ //internal
	string brand; // private
	int tempX;
	public Car(string b, int x) {
		brand = b;
		tempX = x;
	}
	public void EngineRun() {
		int x = 3;
		EngineTest();
		EngineUp(7);
	}
	private void EngineTest()
	{ // private
		"Engine Testing".Dump();
	}
	private void EngineUp(int x)
	{ // private
		"Engine Up".Dump();
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