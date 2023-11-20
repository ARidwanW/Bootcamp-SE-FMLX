void Main()
{
	Car car = new Car("RR");
	car.EngineRun();
	
	Car.EngineCheck();
}

class Car {
	public string enginebrand;
	public Car(string brand) {
		enginebrand = brand;
	}
	public void EngineRun() {
		("EngineRun " + enginebrand).Dump();
		EngineCheck();
	}
	public static void EngineCheck() {
		//("EngineCheck " + enginebrand).Dump();
		//static only access static
	}
}