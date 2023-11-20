//Value Type
class Program {
	static void Main(){
		int a = 3;
		AddTwo(a);
		Console.WriteLine(a); // ? 3 , 5
	}
	static void AddTwo(int a) {
		a = a + 2; 
	}
}
class MyInt {
	public int value;
}