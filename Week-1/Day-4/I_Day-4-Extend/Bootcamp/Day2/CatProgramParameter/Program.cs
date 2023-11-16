using CatProgramParameter;

class Program 
{
	static void Main() 
	{
		//Instantiate instance by its constructor
		Cat cat = new Cat("pokari",3,3.0f);
		cat.Sleep();

		//Same, but different order
		Cat cat1 = new Cat(age : 3, name : "yusuf", weight: 3.0f);
		cat.Sleep();
		
		//Parameterless constructor, and fill the variable	
		Cat cat2 = new Cat()
		{
			name = "yusuf",
			age = 3,
			weight = 3.0f
		};
	
		string food = "whiskas";
		cat.Eat(food);
	}
}