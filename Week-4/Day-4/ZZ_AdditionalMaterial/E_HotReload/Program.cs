//Use HotReload on Debugger --> dotnet watch
int i = 0;
while (true)
{
	Console.WriteLine("beto");
	Console.WriteLine("sate");
	i++;
	Console.WriteLine(i);
	await Task.Delay(1000);
}