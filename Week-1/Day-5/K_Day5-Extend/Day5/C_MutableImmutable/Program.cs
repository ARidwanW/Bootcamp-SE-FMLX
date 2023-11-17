//Mutable immutable
class Program {
	static void Main() {
		string a = "3";
		string b = a;
		
		b = "5";
		
		a.Dump();
		b.Dump();
	}
}