using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public abstract class AbstractCard
{
    /// <summary>
    /// Readonly property Id of Card
    /// </summary>
    /// <value>int</value>
    public int Id { get; private set; }

    /// <summary>
    /// Readonly property Name of Card
    /// </summary>
    /// <value>string</value>
    public string Name { get; private set; }

    /// <summary>
    /// Readonly property Description of Card
    /// </summary>
    /// <value>string</value>
    public string Description { get; private set; }

    /// <summary>
    /// Readonly property Cost of Card
    /// </summary>
    /// <value>int</value>
    public int Cost { get; private set; }

    /// <summary>
    /// Readonly property Power of Card
    /// </summary>
    /// <value>int</value>
    public int Power { get; private set; }

    /// <summary>
    /// Readonly property CardTimeAbility of Card
    /// </summary>
    /// <value>CardTimeAbility</value>
    public CardTimeAbility CardTimeAbility { get; private set; }

    /// <summary>
    /// Readonly property CardAbility of Card
    /// </summary>
    /// <value>CardAbility</value>
    public CardAbility CardAbility { get; private set; }

    /// <summary>
    /// Public property CardStatus of Card
    /// </summary>
    /// <value></value>
    public CardStatus CardStatus { get; set; }

    public AbstractCard(int id, string name, string description, int cost, int power, CardTimeAbility cardTimeAbility, CardAbility cardAbility)
    {
        Id = id;
        Name = name;
        Description = description;
        Cost = cost;
        Power = power;
        CardTimeAbility = cardTimeAbility;
        CardAbility = cardAbility;
    }

    public abstract bool DoAbility();

}
