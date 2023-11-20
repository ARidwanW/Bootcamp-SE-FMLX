//Reference Type
//in
class Program
{
	static void Main()
	{
		Car car = new Car("Toyota");
		ChangeBrand(in car);
		Console.WriteLine(car.brand); //?
	}
	static void ChangeBrand(in Car x)
	{
		//x.brand = "honda"; locked by its memory
		//x = new Car("honda"); locked by its memory
		x.myArray[0] = 3;
	}
}
class Car
{
	public readonly string brand;
	public readonly int[] myArray = { 1, 2, 3};
	public Car(string b) {
		brand = b;
	}
}