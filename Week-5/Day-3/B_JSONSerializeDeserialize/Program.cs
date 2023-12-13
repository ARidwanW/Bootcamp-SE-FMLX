using System.Text.Json;

[Serializable]
public class Person
{
    public int Tall;
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> myList { get; set; }

}

class Program
{
    static void Main(string[] args)
    {
        //Serialize
        //* even we parsing the variable,
        //! the variable will not serialize
        //?? Json Serialize only property
        Person person = new Person
        {
            Tall = 150,
            Name = "Charlie",
            Age = 122,
            myList = new List<string>()
        {
            "hello",
            "test"
        }
        };

        //* JsonSerializer.Serialize will return string
        string jsonString = JsonSerializer.Serialize(person);
        using (StreamWriter writer = new StreamWriter("person.json"))
        {
            writer.Write(jsonString);
        }


        //Deserialize
        string jsonFromFile;
        using (StreamReader reader = new StreamReader("person.json"))
        {
            jsonFromFile = reader.ReadToEnd();
        }
        Person? deserializedPerson = JsonSerializer.Deserialize<Person>(jsonFromFile);

        Console.WriteLine($"Deserialized Person: {deserializedPerson.Name}, {deserializedPerson.Age}");
        foreach (var item in deserializedPerson.myList)
        {
            Console.WriteLine(item);
        }
    }
}