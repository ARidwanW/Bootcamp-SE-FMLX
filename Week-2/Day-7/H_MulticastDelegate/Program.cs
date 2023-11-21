//Multicast Delegate
public delegate void MyDelegate(string a);
class Program
{
	static void Main()
	{
		MyDelegate hello;
		MyDelegate hai;
		Information info = new();

		hello = info.Displayer;
		hai = info.Yusuf;

		hello.Invoke("Halo");
		hai.Invoke("Hai");
	}
}
class Information
{
	public void Displayer(string notif)
	{
		("Displayer : " + notif).Dump();
	}
	public void Yusuf(string notif)
	{
		("Yusuf : " + notif).Dump();
	}
}