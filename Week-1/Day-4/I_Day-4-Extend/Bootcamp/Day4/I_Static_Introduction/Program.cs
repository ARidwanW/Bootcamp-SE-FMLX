static void Main() {
	Parent yusuf = new Parent("Yusuf");
	Parent hamid = new Parent("Hamid");
	Parent yanto = new Parent("Yanto");
	Parent jarot = new Parent("Jarot");
	Parent tanto = new Parent("Tanto");
	
	yusuf.name.Dump();
	hamid.name.Dump();
	yanto.name.Dump();
	jarot.name.Dump();
	
	Parent.counter.Dump();
}

class Parent {
	public static int counter;
	public string name;
	
	public Parent(string input) {
		name = input;
		counter ++;
	}
}