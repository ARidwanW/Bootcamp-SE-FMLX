//Child <= Parent <= Child
class Program {
	static void Main() {
		//Parent p = new Child();
		//p.MethodParent();
		// p.MethodChild(); it will error
		
		Child c = new Child();
		Parent p = c;
		Child child = (Child)p;
		child.MethodParent();
		child.MethodChild();
	}
}
public class Parent {
	public void MethodParent() {
		"MethodParent".Dump();
	}
}
public class Child : Parent
{
	public void MethodChild()
	{
		"MethodChild".Dump();
	}
}