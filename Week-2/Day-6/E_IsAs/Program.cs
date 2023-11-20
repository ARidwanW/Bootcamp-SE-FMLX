//Is = type checking
//As = Explicit cast for reference type
static void Main() {
	object a = "Hello";
	string resulta = a as string;
	//string resulta = (string)a;
	
	object b = true;
	if(b is bool) {
		bool resultb = (bool)b;
	}
	// * The low level is below
	Type type = b.GetType(); //GetType -> instance
	Type type2 = typeof(Boolean); //typeof(...) -> class
	if(b.GetType() == type2) {
		bool resultb = (bool)b;
		Console.WriteLine(resultb);
	}
}