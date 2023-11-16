// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

class Program
{
	static void Main() 
	{
		Building building = new FirstFloor();
		building.ExitDoor(123);
	}
}
abstract class Building
{
	public abstract int ExitDoor();
}

class FirstFloor : Building
{
	private int _totalEmergancyDoor;
	
	public FirstFloor(int totalEmergancyDoor)
	{
		_totalEmergancyDoor = totalEmergancyDoor;
	}
	public override int ExitDoor(int _totalEmergancyDoor)
	{
		int hasil = _totalEmergancyDoor;
		return hasil;
	}
}