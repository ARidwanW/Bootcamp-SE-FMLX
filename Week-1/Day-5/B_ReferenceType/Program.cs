//Reference
class Program {
	static void Main() {
		Car a = new Car(3);     // * Reference Type: class, array, string
		Car b = a;
		
		b.value = 5;
		
		a.value.Dump();     // ??output: 5
		b.value.Dump();     // ??output: 5
	}
}

class Car
{
	public int value;
	public Car(int input) {
		value = input;
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