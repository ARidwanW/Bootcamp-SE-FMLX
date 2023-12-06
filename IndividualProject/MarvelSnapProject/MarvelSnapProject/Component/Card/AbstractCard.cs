using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
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
    /// Readonly property Ability of Card
    /// </summary>
    /// <value>CardAbility</value>
    public CardAbility CardAbility { get; private set; }
    private CardStatus _cardStatus;
    public bool _isOnGoing { get; }
    public bool _isOnReveal { get; }

    public AbstractCard(int id, string name, string description, 
                        int cost, int power, CardAbility cardAbility, 
                        bool isOnGoing = false, bool isOnReveal = false)
    {
        Id = id;
        Name = name;
        Description = description;
        Cost = cost;
        Power = power;
        CardAbility = cardAbility;
        _isOnGoing = isOnGoing;
        _isOnReveal = isOnReveal;
    }

    // public abstract bool DoAbility(GameController game, IPlayer player, AbstractLocation location);
    public abstract bool SpecialAbilityOnGoing(GameController game, IPlayer player, AbstractLocation location);
    public abstract bool SpecialAbilityOnReveal(GameController game, IPlayer player, AbstractLocation location);

    public CardStatus GetCardStatus()
    {
        return _cardStatus;
    }

    public bool SetCardStatus(CardStatus status)
    {
        _cardStatus = status;
        return true;
    }

}
