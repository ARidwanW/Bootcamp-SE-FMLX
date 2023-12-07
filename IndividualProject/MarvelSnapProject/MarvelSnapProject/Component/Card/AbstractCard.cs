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

    /// <summary>
    /// Private variable Status of Card
    /// </summary>
    private CardStatus _cardStatus;

    /// <summary>
    /// Readonly Property OnGoing ability of Card
    /// </summary>
    /// <value>bool</value>
    public bool _isOnGoing { get; private set; }

    /// <summary>
    /// Readonly Property OnReveal ability of Card
    /// </summary>
    /// <value>bool</value>
    public bool _isOnReveal { get; private set; }

    /// <summary>
    /// Abstract Class of Card
    /// </summary>
    /// <param name="id">Id of Card</param>
    /// <param name="name">Name of Card</param>
    /// <param name="description">Description of Card Ability</param>
    /// <param name="cost">Cost or Energy of Card</param>
    /// <param name="power">Power or Point of Card</param>
    /// <param name="cardAbility">Ability type of Card</param>
    /// <param name="isOnGoing">Boolean: true if ability is OnGoing type</param>
    /// <param name="isOnReveal">Boolean: true if ability is OnReveal type</param>
    public AbstractCard(int id, string name, string description,
                        int cost, int power, CardAbility cardAbility,
                        CardStatus cardStatus = CardStatus.OnDeck,
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

    /// <summary>
    /// Abstract method for special ability on going.
    /// </summary>
    /// <param name="game">Game Controller</param>
    /// <param name="player">IPlayer implementation of players</param>
    /// <param name="location">AbstractLocation implementation of locations</param>
    /// <returns>true: if card successfully doing its ability on going</returns>
    public abstract bool SpecialAbilityOnGoing(GameController game, IPlayer player, AbstractLocation location);


    /// <summary>
    /// Abstract method for special ability on reveal.
    /// </summary>
    /// <param name="game">Game Controller</param>
    /// <param name="player">IPlayer implementation of players</param>
    /// <param name="location">AbstractLocation implementation of locations</param>
    /// <returns>true: if card has on reveal special ability</returns>
    public abstract bool SpecialAbilityOnReveal(GameController game, IPlayer player, AbstractLocation location);

    /// <summary>
    /// Getter status of Card
    /// </summary>
    /// <returns>CardStatus</returns>
    public CardStatus GetCardStatus()
    {
        return _cardStatus;
    }

    /// <summary>
    /// Setter status of Card
    /// </summary>
    /// <param name="status">Changed status</param>
    /// <returns>true: if card status successfully changed</returns>
    public bool SetCardStatus(CardStatus status)
    {
        _cardStatus = status;
        return true;
    }
}
