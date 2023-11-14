using Car_Project;
using CarComponent;

class Program 
{
	static void Main() 
	{
		Engine engine = new Engine(8, "gm");
		Engine engine2 = new Engine(9, "rr");
		Tire tire = new Tire(18, "rubber");
		Door door = new Door("red", 4, 10);
		Wiper wiper = new Wiper(10);
		Exhaust exhaust = new Exhaust("brembo",8);

		Car car = new Car(engine, tire, wiper, door, exhaust);
		string result = car.EngineBrandCheck();
		Console.WriteLine(result);
		Console.WriteLine(car.engine.brand);
	}
}