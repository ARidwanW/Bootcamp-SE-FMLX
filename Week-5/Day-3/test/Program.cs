using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;


[DataContract]
class Person{
    [DataMember]
    public string name;
    [DataMember]
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        var p = new Person(){name = "sate", Age = 15};
        DataContractSerializer xmlSerializer = new DataContractSerializer(typeof(Person));
        using (FileStream stream = new FileStream("person.xml", FileMode.OpenOrCreate))
        {
            xmlSerializer.WriteObject(stream, p);
        }

        Person importPerson;
        using (FileStream stream2 = new FileStream("person.xml", FileMode.Open))
        {
            importPerson = (Person)xmlSerializer.ReadObject(stream2);
        }

        Console.WriteLine(importPerson.name);

        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Person));
        using(FileStream stream3 = new FileStream("person.json", FileMode.OpenOrCreate))
        {
            jsonSerializer.WriteObject(stream3, importPerson);
        }

    }
}
