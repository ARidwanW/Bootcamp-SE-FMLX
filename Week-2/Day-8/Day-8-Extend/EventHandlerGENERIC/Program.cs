//EventArgs<T>
//Event
void Main()
{
	Publisher pub = new("Yusuf");
	Subscriber sub = new();
	pub.subs += sub.GetNotif;

	pub.SendNotif();
}
class Publisher
{
	public readonly string Name;
	public event EventHandler<DataEvent> subs;
	public event EventHandler<DataEvent> subs2;
	public Publisher(string name)
	{
		Name = name;
	}
	public void SendNotif()
	{
		subs?.Invoke(Name, new DataEvent { 
			code = 1, 
			information = "informasi", 
			name = "nama"
		});
	}
	public override string ToString()
	{
		return Name;
	}
}
class Subscriber
{
	public void GetNotif(object sender, DataEvent e)
	{
		Console.WriteLine($"Subscriber got notified from {sender} with data : {e.code} {e.name} {e.information}");
	}
}
class DataEvent : EventArgs {
	public string name;
	public string information;
	public int code;
}