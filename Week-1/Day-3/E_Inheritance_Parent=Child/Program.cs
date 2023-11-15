//To try
class Program {
	static void Main() {
		Child c = new Child(1,2,3,4);
		Parent p = c;
		
		//Parent p1 = new Child(1,2,3,4);

		//p.a.Dump(); ?
		//p.b.Dump(); ?
		//p.c.Dump(); ?
		//p.d.Dump(); ?
		
		//Parent p1 = new Parent(1,2);
		//Child c1 = p1; ?
	}
}
class Jokowi {}
class Parent
{
	public int a;
	public int b;
	public Parent(int a, int b) {
		this.a = a;
		this.b = b;
	}
}
class Child : Parent
{
	public int c;
	public int d;
	public Child(int a, int b, int c, int d) : base(a,b) 
	{
		this.c = c;
		this.d = d;
	}
}

//This is Extension Method
public static class IniExtension
{
	public static void Dump(this object x) 
	{
		Console.WriteLine(x.ToString());
	}
}