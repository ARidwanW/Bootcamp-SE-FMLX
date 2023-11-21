//Multicast Delegate
public delegate void MyDelegate();
class Program
{
	static void Main()
	{
		MyDelegate mydel;
		Information info = new();
		
		mydel = info.Displayer;
		mydel += info.Yusuf;
		
		mydel.Invoke();
	}
}
class Information
{
	public void Displayer()
	{
		"Displayer".Dump();
	}
	public void Yusuf()
	{
		"Yusuf".Dump();
	}
}