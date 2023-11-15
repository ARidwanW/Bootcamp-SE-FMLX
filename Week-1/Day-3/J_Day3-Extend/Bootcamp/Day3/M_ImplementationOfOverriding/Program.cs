//Implementation of Overriding
class Program {
	static void Main() {
		ElectricEngine ee = new();
		HydroEngine he = new();
		
		Car car = new Car(ee);
		car.EngineRun();
	}
}
class Car {
	public Engine engine;
	public void EngineRun() {
		engine.Start();
	}
	public Car(Engine engine) {
		this.engine = engine;
	}
}
class Engine {
	public virtual void Start() {
		"Engine Starting".Dump();
	}
}
class ElectricEngine : Engine {
	public new void Start() {
		"EE Starting".Dump();
	}
}
class HydroEngine {
	public void Start() {
		"Hydro Engine Starting".Dump();
	}
}