void Main()
{
	Car myCar = new();
	myCar.CetakSekarang();
}
class Car
{
	public void EngineRun()
	{
		"EngineRun".Dump();
	}
}
public static class MyExtension {
	public static void CetakSekarang(this object a) {
		Console.WriteLine(a);
	}
}

