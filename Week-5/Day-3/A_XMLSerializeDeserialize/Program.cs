using System.IO;
using System.Xml.Serialization;

public class Person
{
    //* XML serialize will order by variable then property
    public string longName;
    public string? Name { get; set; }
    public int Age { get; set; }
    public int Tall;
    

}

class Program
{
    static void Main()
    {
        Person person = new Person { longName = "ju", Name = "Bob", Age = 11, Tall = 150 };

        XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
        List<Person> persons = new() { person };
        using (StreamWriter writer = new StreamWriter("person.xml"))
        {
            serializer.Serialize(writer, persons);
        }

        List<Person> deserializedPerson;
        using (StreamReader reader = new StreamReader("person.xml"))
        {
            deserializedPerson = (List<Person>)serializer.Deserialize(reader);
        }
        foreach (var i in deserializedPerson)
        {
            Console.WriteLine(i.Name);
            Console.WriteLine(i.Age);
            Console.WriteLine(i.longName);
        }


        //Console.WriteLine($"Deserialized Person: {deserializedPerson?.Name}, {deserializedPerson.Age}");
    }
}

class GameConfig { }
class DisplayConfig { }
class EmailConfig { }

class Configuration
{
    GameConfig gameConfig { get; set; }
    DisplayConfig displayConfig { get; set; }
    EmailConfig emailConfig { get; set; }
}