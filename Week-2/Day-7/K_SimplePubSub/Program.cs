//Pub Sub
using Dumper;
public delegate void MySubscriber(string message);
class Program
{
	static void Main()
	{
		Youtuber yanto = new();

		Subscriber sub = new();
		Subscriber2 sub2 = new();
		Radio rad = new();

		yanto.AddSubscriber(sub.GetNotified);
		yanto.AddSubscriber(sub2.GetNotified2);
		yanto.AddSubscriber(rad.GetInform);

		yanto.UploadVideo();
	}
}
class Youtuber
{
	private MySubscriber _subs;
	public void UploadVideo()
	{
		"Uploading Video ...".Dump();
		"Upload complete".Dump();
		SendNotification("Video uploaded");
	}
	private void SendNotification(string message)
	{
		_subs?.Invoke(message);
	}
	public bool AddSubscriber(MySubscriber a)
	{
		Delegate[] myDelegate = _subs?.GetInvocationList();
		if (myDelegate.Contains(a))
		{
			return false;
		}
		_subs += a;
		return true;
	}
	public bool RemoveSubscriber(MySubscriber a)
	{
		_subs -= a;
		return true;
	}
}
class Subscriber
{
	public void GetNotified(string message)
	{
		("Subscriber1 : " + message).Dump();
	}
}
class Subscriber2
{
	public void GetNotified2(string message)
	{
		("Subscriber2 : " + message).Dump();
	}
}
class Radio
{
	public void GetInform(string message)
	{
		("Radio : " + message).Dump();
	}
}