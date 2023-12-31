﻿class Program
{
    static void Main()
    {
        Publisher pub = new("Ucup");
        Subscriber sub = new();

        pub.subs += sub.GetNotif;

        pub.SendNotif();
    }
}

class Publisher {
    public readonly string Name;
    public event EventHandler subs;
    public Publisher(string name)
    {
        Name = name;
    }
    public void SendNotif()
    {
        // subs?.Invoke(Name, EventArgs.Empty);
        subs?.Invoke(this, EventArgs.Empty);
    }

    // if using this must override ToString()
    public override string ToString()
    {
        return Name;
    }
}

class Subscriber
{
    public void GetNotif(object sender, EventArgs e)
    {
        Console.WriteLine($"Subscriber got notified from {sender}");
    }
}
