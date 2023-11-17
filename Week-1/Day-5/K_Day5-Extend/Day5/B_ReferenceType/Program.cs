//Reference
class Program {
	static void Main() {
		Car a = new Car(3);
		Car b = a;
		
		b.value = 5;
		
		a.value.Dump();
		b.value.Dump();
	}
}

class Car
{
	public int value;
	public Car(int input) {
		value = input;
	}
}