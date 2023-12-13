using System.Xml.Serialization;

public class Person
{
	public string? Name;
	public int Age { get; set; }
    public List<string> myList { get; set; }
}

class Program
{
	static void Main(string[] args)
	{
		List<Person> people = new List<Person>
		{
			new Person { Name = "Charlie", Age = 12, myList = new List<string>(){"a", "b"} },
			new Person { Name = "Alice", Age = 30, myList = new List<string>() }
		};

		// Serialize the list
		XmlSerializer serializer = new XmlSerializer(typeof(List<Person>)); //! must using type
		using (StreamWriter writer = new StreamWriter("person.xml"))
		{
			serializer.Serialize(writer, people);
		}

        // Console.WriteLine(serializer);

		using (StreamReader reader = new StreamReader("person.xml"))
		{
			List<Person> deserializedPeople = (List<Person>)serializer.Deserialize(reader);

			Console.WriteLine(deserializedPeople.Count);
			foreach (var person in deserializedPeople)
			{
				Console.WriteLine($"Deserialized Person: {person.Name}, {person.Age}");
                foreach(var item in person.myList)
                {
                    Console.WriteLine(item);
                }
                // Console.WriteLine(person.myList);
			}
		}
	}
}