//Overloading
class Calculator {
	public int Add(int a, int b) {
		return a + b;
	}
	public float Add(float a, float b) {
		return a + b;
	}
	private int StringLengthChecker(string a, string b) {
		return (a + b).Length;
	}
	// This method is conflict because same name same parameter,
	// even the return type is different
	//public double Add(string a, string b)
	//{
	//	return a.Length + b.Length;
	//}
}
