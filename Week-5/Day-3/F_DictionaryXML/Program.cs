using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;
[DataContract]
class Player
{
	[DataMember]
	public string name;
	[DataMember]
	public int id;
}
[DataContract]
class Card 
{
	[DataMember]
	public int id;
}
class Program 
{
	static void Main() 
	{
		Player player = new Player() { name = "yusuf", id = 3 };
		Player player2 = new Player() { name = "andi", id = 4 };
		Player player3 = new Player() { name = "yanto", id = 5 };
		Card c = new Card() { id = 4 };

		Dictionary<Player, Card> playerCard = new();
		playerCard.Add(player, c);
		playerCard.Add(player2, c);
		playerCard.Add(player3, c);

		DataContractJsonSerializer serialize = new(typeof(Dictionary<Player, Card>));
		using (FileStream sw = new FileStream("myXml.json",FileMode.Create))
		{
			using(var writer = JsonReaderWriterFactory.CreateJsonWriter(sw,Encoding.UTF8,true,true," ")) 
			{
				serialize.WriteObject(writer, playerCard);
			}
		}
	}
}
