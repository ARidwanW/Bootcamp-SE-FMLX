void Main()
{
		Action<bool> x;
		Action<bool, bool, int, int, bool> y;
		Func<int, int, bool> comparer = Comparison;
		comparer += (int a, int b) => a == b;
    Console.WriteLine(comparer.Invoke(3, 3));
}
bool Comparison(int a, int b) {
	return a == b;
}
int Add(int a, int b) {
	return a + b;
}
