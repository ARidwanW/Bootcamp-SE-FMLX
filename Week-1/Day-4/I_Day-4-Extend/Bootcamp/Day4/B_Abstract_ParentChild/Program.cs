//Abstract Parent Child Implementation
abstract class A {
	public abstract void MethodA();
}
abstract class B : A {
	public abstract void MethodB();
}
class C : B
{
	public override void MethodA()
	{
		//...
	}

	public override void MethodB()
	{
		throw new NotImplementedException();
	}
}