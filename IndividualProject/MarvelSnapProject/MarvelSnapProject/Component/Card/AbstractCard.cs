using System.Globalization;

namespace MarvelSnapProject.Component.Card;

public abstract class AbstractCard
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Cost { get; private set; }
    public int Power { get; private set; }

    public AbstractCard(int id, string name, string description, int cost, int power)
    {
        Id = id;
        Name = name;
        Description = description;
        Cost = cost;
        Power = power;
    }

}
