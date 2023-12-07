//Assign <DefineConstant> on the .csproj inside <PropertyGroup>

class Program {
	static void Main() {
		#if ANDROID
		Console.WriteLine("ANDROID");
		#elif APPLE
		Console.WriteLine("APPLE");
		#endif
		Console.WriteLine("Program berjalan...");
	}
} 