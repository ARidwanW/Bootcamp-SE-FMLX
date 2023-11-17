//Enum
void Main() {
	int result = (int)MonthOfYear.January;
	result.Dump();
	
	//int count = 2;
	//MonthOfYear resultenum = (MonthOfYear)count;
	//resultenum.Dump();
}
public enum MonthOfYear
{
	January,
	February = 401,
	Maret,
	April = 1,
	Mei,
	Juni = 400,
	Juli = 2,
	Agustus,
	September = 2,
	October,
	November,
	Desember
}