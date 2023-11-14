using CatProgramParameter;

class Program 
{
	static void Main() 
	{
		Cat cat = new Cat();
		cat.Sleep();

		string food = "whiskas";
		cat.Eat(food);
	}
}