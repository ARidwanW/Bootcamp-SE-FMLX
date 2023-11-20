//Override ToString from class Object
void Main()
{
	Car a = new Car("Toyota");
	Console.WriteLine(a);
	string result = a.ToString();
	Console.WriteLine(result);
}

class Car {
	private string brand;
	public Car(string brand) {
		this.brand = brand;
	}
	

	// * It override from class Object
	// All class are child of class Object
	// TODO : Try to override another method from Object class
	// TODO : Like Equals(object a), ToString(), etc.
	public override string ToString()
	{
		 return brand;
	}
}
