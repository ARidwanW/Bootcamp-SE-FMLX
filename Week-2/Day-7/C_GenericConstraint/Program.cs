//Generic Constraint
using System.Numerics;
void Main()
{
	Calculator<int>.Add(3,4).Dump();
	Calculator<double>.Add(2.0,1.0).Dump();
	
	Car cara = new(2);
	Car carb = new(3);
	Calculator<Car>.Add(cara,carb).Dump();
}
class Calculator<T> where T :  IAdditionOperators<T, T, T>
{
	public static T Add(T a, T b)
	{
		return a+b;
	}
}
class Car : IAdditionOperators<Car, Car, Car>
{
	public int price;
	public Car(int p) {
		price = p;
	}
	public static Car operator +(Car left, Car right)
	{
		return new Car(left.price + right.price);
	}
}