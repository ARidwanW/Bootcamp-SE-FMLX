using CarComponent;
namespace Car_Project;

public class Car
{
	public Engine engine;
	public string myString;
	public int x;
	public Tire tire;
	public Wiper wiper;
	public Door door;
	public Exhaust exhaust;
	
	public Car(Engine en, Tire tr, Wiper wp, Door door, Exhaust ex) 
	{
		engine = en;
		tire = tr;
		wiper = wp;
		this.door = door;
		exhaust = ex;
	}
	public Car() 
	{
		
	}
	
	public void EngineRun() 
	{
		engine.EngineTest();
	}
	public string EngineBrandCheck() 
	{
		return engine.brand;
	}
}