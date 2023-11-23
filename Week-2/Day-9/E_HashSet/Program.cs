class Program
{
	static void Main()
	{
		//Unique
		HashSet<int> mySet = new();
		mySet.Add(1);
		mySet.Add(2);
		mySet.Add(3);
		mySet.Add(4);
		mySet.Add(5);

		HashSet<int> mySet2 = new();
		mySet2.Add(3);
		mySet2.Add(4);
		mySet2.Add(5);
		mySet2.Add(6);
		mySet2.Add(7);

		// mySet.UnionWith(mySet2);
		// mySet.IntersectWith(mySet2);
		mySet.ExceptWith(mySet2);
		
		foreach(var i in mySet) 
		{
			Console.WriteLine(i);
		}
	}
}