using ProtoBuf;

[ProtoContract]
public class Person
{
	[ProtoMember(1)]
	public string Name { get; set; }

	[ProtoMember(2)]
	public  int Age { get; set; }

	[ProtoMember(3)]
	private int Umur = 23;
	
	public void GetUmur() 
	{
		Console.WriteLine(Umur);
	}
}

class Program
{
	static void Main(string[] args)
	{
		Person person = new Person { Name = "Alice", Age = 10 };

		// Serialize the object
		using (FileStream stream = new FileStream("person.bin", FileMode.Create))
		{
			Serializer.Serialize<Person>(stream, person);
		}

		// Deserialize the object
		Person deserializedPerson;
		using (FileStream stream = new FileStream("person.bin", FileMode.Open))
		{
			deserializedPerson = Serializer.Deserialize<Person>(stream);
		}
		deserializedPerson.GetUmur();
		Console.WriteLine($"Deserialized Person: {deserializedPerson.Name}, {deserializedPerson.Age}");
	}
}
