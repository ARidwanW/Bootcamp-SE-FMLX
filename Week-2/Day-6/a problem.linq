<Query Kind="Program" />

class Program
{
	static void Main()
	{
		Car car = new Car();
		int[] a = {1, 2, 3, 4};
		float[] b = {1.4f, 2,5f};
		car.Run(a, b);
		
		//object a = 3;
		//if(a.GetType() == typeof(int))
		//{
		//	Console.WriteLine("its an int");
		//}
	}
}

class Car
{
	public void Run(params object[] a)
	{
		for(int i = 0; i < a.Length; i++)
		{
			Console.WriteLine(a[i]);
			if (a[i].GetType() == typeof(int[]))
			{
				Console.WriteLine("masuk");
				int[] array = (int[]) a[i];
			
				
				foreach(var item in array)
				{
					Console.WriteLine(item);
				}
			}
			
		}
		
		
		
		//int[] myIntArray = new int[a.Length];
		//int count = 0;
		//Console.WriteLine(a.GetType());
		//foreach(var item in a)
		//{
		//	item.GetType().Dump();
		//}
		
		// foreach (var (index, value) in a.entries())
		//foreach(var v in a)
		//{
		//	if (v.GetType() == typeof(int))
		//	{
		//		Console.WriteLine("its an int");
		//	}
		//}
		
		//Console.WriteLine(a);
		//Console.WriteLine(a.GetType());
		//if (a.GetType() == typeof(int))
		//{
		//	Console.WriteLine("it's an int");
		//}
	}
}