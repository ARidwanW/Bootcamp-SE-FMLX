using CatProgramParameter;

class Program 
{
	static void Main() 
	{
		Cat cat = new Cat("pokari" , 3 , 3.0f);
		cat.Sleep();

		Cat cat1 = new Cat(age : 3, name : "yusuf", weight : 3.0f);

		Cat cat2 = new Cat()
		{
			name = "jiji",
			age = 4,
			weight = 5.0f
		};


		string food = "whiskas";
		cat.Eat(food);
	}
}