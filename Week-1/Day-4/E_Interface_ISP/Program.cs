//Interface
//Interface Seggregation Principle
//Multiple small interface instead of 1 big interface
public interface IPrint {
	void Print();
}
public interface IFax {
	void Fax();
}
public interface IScan {
	void Scan();
}
public interface IPrinterMahal : IPrint, IFax, IScan {
	
}
class Printer3Juta : IPrinterMahal
{
	public void Fax()
	{ //...
	}
	public void Print()
	{ //...
	}
	public void Scan()
	{ //...
	}
}
class Printer250Ribu : IPrint
{
	public void Print()
	{
		throw new NotImplementedException();
	}
}