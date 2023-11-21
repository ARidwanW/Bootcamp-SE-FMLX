//Single Delegate
public delegate void MyDelegate();
class Program {
	static void Main() {
		MyDelegate mydel = Displayer;
		mydel.Invoke();
		mydel();
	}
	static void Displayer() {
		"Displayer".Dump();
	}
	static void Yusuf()
	{
		"Yusuf".Dump();
	}
}
