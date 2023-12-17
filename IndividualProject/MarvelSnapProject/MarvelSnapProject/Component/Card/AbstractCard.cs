using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Card;

public abstract class AbstractCard
{
    /// <summary>
    /// Gets the identifier of the card.
    /// </summary>
    /// <value>int</value>
    public int Id { get; private set; }

    /// <summary>
    /// Gets the name of the card.
    /// </summary>
    /// <value>string</value>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the description of the card.
    /// </summary>
    /// <value>string</value>
    public string Description { get; private set; }

    /// <summary>
    /// Represents the cost of the card.
    /// </summary>
    /// <value>int</value>
    private int _cost;

    /// <summary>
    /// Represents the power of the card.
    /// </summary>
    /// <value>int</value>
    private int _power;

    /// <summary>
    /// Gets the abilities associated with the card.
    /// </summary>
    /// <value>CardAbility</value>
    public CardAbility CardAbility { get; private set; }

    /// <summary>
    /// Represents the status of the card.
    /// </summary>
    private CardStatus _cardStatus;

    /// <summary>
    /// Gets a value indicating whether the card has the ongoing ability.
    /// </summary>
    /// <value>bool</value>
    public bool _isOnGoing { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the card has the on reveal ability.
    /// </summary>
    /// <value>bool</value>
    public bool _isOnReveal { get; private set; }

    /// <summary>
    /// Initializes a new instance of the AbstractCard class.
    /// </summary>
    /// <param name="id">The identifier of the card.</param>
    /// <param name="name">The name of the card.</param>
    /// <param name="description">The description of the card's ability.</param>
    /// <param name="cost">The cost or energy required to use the card.</param>
    /// <param name="power">The power or point value of the card.</param>
    /// <param name="cardAbility">The type of ability the card has.</param>
    /// <param name="cardStatus">The status of the card (default is None).</param>
    /// <param name="isOnGoing">A value indicating whether the card has the ongoing ability.</param>
    /// <param name="isOnReveal">A value indicating whether the card has the on reveal ability.</param>
    public AbstractCard(int id, string name, string description,
                        int cost, int power, CardAbility cardAbility,
                        CardStatus cardStatus = CardStatus.None,
                        bool isOnGoing = false, bool isOnReveal = false)
    {
        Id = id;
        Name = name;
        Description = description;
        _cost = cost;
        _power = power;
        CardAbility = cardAbility;
        _cardStatus = cardStatus;
        _isOnGoing = isOnGoing;
        _isOnReveal = isOnReveal;
    }

    /// <summary>
    /// Creates a copy of the card.
    /// </summary>
    /// <returns>A copy of the card.</returns>
    public abstract AbstractCard Clone();

    /// <summary>
    /// Executes the ongoing special ability of the card.
    /// </summary>
    /// <param name="game">The game controller instance.</param>
    /// <returns>True if the ongoing ability was successfully executed; 
    /// otherwise false.</returns>
    public abstract bool SpecialAbilityOnGoing(GameController game);

    /// <summary>
    /// Executes the on reveal special ability of the card.
    /// </summary>
    /// <param name="game">The game controller instance.</param>
    /// <returns>True if the on reveal ability was successfully executed; 
    /// otherwise false.</returns>
    public abstract bool SpecialAbilityOnReveal(GameController game);

    /// <summary>
    /// Gets the current status of the card.
    /// </summary>
    /// <returns>The current status of the card.</returns>
    public CardStatus GetCardStatus()
    {
        return _cardStatus;
    }

    /// <summary>
    /// Sets the status of the card.
    /// </summary>
    /// <param name="status">The new status to set.</param>
    /// <returns>True if successfully setting the new status; otherwise false.</returns>
    public bool SetCardStatus(CardStatus status)
    {
        _cardStatus = status;
        return true;
    }

    /// <summary>
    /// Gets the cost of the card.
    /// </summary>
    /// <returns>The cost of the card.</returns>
    public int GetCost()
    {
        return _cost;
    }

    /// <summary>
    /// Sets the cost of the card.
    /// </summary>
    /// <param name="cost">The new cost to set.</param>
    /// <returns>True if successfully setting the new cost; otherwise false.</returns>
    public bool SetCost(int cost)
    {
        _cost = cost;
        return true;
    }

    /// <summary>
    /// Gets the power of the card.
    /// </summary>
    /// <returns>The power of the card.</returns>
    public int GetPower()
    {
        return _power;
    }

    /// <summary>
    /// Sets the power of the card.
    /// </summary>
    /// <param name="power">The new power to set.</param>
    /// <returns>True if successfully setting the new power; otherwise false.</returns>
    public bool SetPower(int power)
    {
        _power = power;
        return true;
    }

    /// <summary>
    /// Checks if the card is deployed.
    /// </summary>
    /// <returns>True if the card is deployed; otherwise false.</returns>
    public bool IsDeployed()
    {
        if (GetCardStatus() == CardStatus.OnLocation)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Deploys the card.
    /// </summary>
    /// <param name="game">The game controller instance.</param>
    /// <param name="player">The player deploying the card.</param>
    /// <param name="location">The location where the card is deployed.</param>
    /// <returns>True if the card was successfully deployed; otherwise false.</returns>
    public virtual bool DeployCard(GameController game, IPlayer player, AbstractLocation location)
    {
        return true;
    }
}
