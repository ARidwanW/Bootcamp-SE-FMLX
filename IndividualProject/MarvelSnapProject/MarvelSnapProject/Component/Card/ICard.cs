namespace MarvelSnapProject.Component.Card;

public interface ICard
{
    /// <summary>
    /// Readonly property Id of card
    /// </summary>
    /// <value>int</value>
    public int Id { get; }

    /// <summary>
    /// Readonly property Name of card
    /// </summary>
    /// <value>string</value>
    public string Name { get; }

    /// <summary>
    /// Readonly property Description of card
    /// </summary>
    /// <value>string</value>
    public string Description { get; }

    /// <summary>
    /// Readonly property Cost (Energy Cost) of card
    /// </summary>
    /// <value>int</value>
    public int Cost { get; }

    /// <summary>
    /// Readonly property Power of card
    /// </summary>
    /// <value>int</value>
    public int Power { get; }
}
