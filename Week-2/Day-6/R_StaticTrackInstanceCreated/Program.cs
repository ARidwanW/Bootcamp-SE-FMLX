//Static
//Not owned by instance
//Created when program Run
void Main()
{
	Car a = new();
	Car b = new();
	Car.count.Dump();
}
class Car {
	public static int count = 0;
	public Car() {
		count ++;
	}
	
}
