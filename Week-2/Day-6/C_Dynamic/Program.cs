//Dynamic
// ! Dont use Dynamic in any case
// ! It will take so many process and hurts CPU
void Main()
{
	dynamic a = 3;
	a = "hello";
	a = true;
	// Var will check at compile time
	// Dynamic will check at running time
	// var a = new Car();
	a.Running();
	// ! Below will give exception
	a.Runninx();
	a.Meledak();
}

class Car {
	public void Running() {
		Console.WriteLine("Running");
	}
}

