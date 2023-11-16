//Parent and Child different value
//base : to call parent value/method
//this : to call its value/method
public class Parent {
	public int a;
	public Parent(int input) {
		this.a = input;
	}
}
public class Child : Parent{
	public int a;
	public Child(int a, int c) : base(a) {
		this.a = a;
		this.a *= c;
	}
	public void GetAFromParent() {
		base.a.Dump();
	}
	public void GetAFromChild()
	{
		this.a.Dump();
	}
}
class Program {
	static void Main() {
		Child c = new Child(2,3);
		c.GetAFromParent(); //2
		c.GetAFromChild(); //6
	}
}