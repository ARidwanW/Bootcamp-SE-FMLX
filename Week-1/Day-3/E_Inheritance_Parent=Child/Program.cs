//To try
class Program {
	static void Main() {
		Child c = new Child(1,2,3,4);
		Parent p = c;   // its working
		// Parent p1 = new Child(1,2,3,4);  // also working

		p.a.Dump(); // output: 1
		p.b.Dump(); // output: 2
		/* p.c.Dump(); // output: error
		p.d.Dump(); // output: error */
		
		Parent p1 = new Parent(1,2);    // its working yeah classic

        // this will error even when parent and child have the same number of parameter
		/* Child c1 = p1;  // output: error CS0266: Cannot implicitly convert type 'Parent' to 'Child' */
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
    public Child(int a, int b) : base(a, b)
    {

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