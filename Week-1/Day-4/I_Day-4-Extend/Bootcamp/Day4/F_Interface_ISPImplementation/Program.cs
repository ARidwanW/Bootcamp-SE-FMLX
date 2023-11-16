//Interface implementation
static void Main() {
	Printer3Juta printer3juta = new();
	Printer250Ribu printer250ribu = new();
	
	IPrint printer = printer3juta;
	printer.Print();
}
public interface IPrint
{
	void Print();
}
public interface IFax
{
	void Fax();
}
public interface IScan
{
	void Scan();
}
public interface IPrinterMahal : IPrint, IFax, IScan
{

}
class Printer3Juta : IPrinterMahal
{
	public void Fax()
	{ //...
	}
	public void Print()
	{ "Printing High Definition".Dump();
	}
	public void Scan()
	{ //...
	}
}
class Printer250Ribu : IPrint
{
	public void Print()
	{
		"Printing Seadanya".Dump();
	}
}