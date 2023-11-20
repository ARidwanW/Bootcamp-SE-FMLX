//Extension Method
//Support for OpenClose Principle in SOLID
void Main()
{
	int a = 3; 
	int result = a.Tambah(2);
	
	//Not work because Tambah method only accept 'int'
	//float myfloat = 3.0f;
	//myfloat.Tambah(2.0f);
	result.Cetak();
}
public static class IniExtension {
	public static int Tambah(this int a, int b) {
		return a+b;
	}
	public static void Cetak(this object a)
	{
		Console.WriteLine(a);
	}
}
