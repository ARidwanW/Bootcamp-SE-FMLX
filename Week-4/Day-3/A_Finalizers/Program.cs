using System;

namespace DestructorExample
{
	class DestructorDemo
	{
		public DestructorDemo()
		{
			Console.WriteLine("Constructor Object called");
		}
		~DestructorDemo()
		{
			Console.WriteLine("Destructor/Finalizers called, Object destroyed");
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			
			InstanceCreator();
			//....
			Console.ReadKey();
		}
		static void InstanceCreator() {
			int a = 3;
			DestructorDemo obj1 = new DestructorDemo();
		}
	}
}
