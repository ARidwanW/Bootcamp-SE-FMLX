using MarvelSnapProject.Enum;

namespace MarvelSnapProject.Component.Database;

public class Location
{
    public int LocationId { get; set; }
    public string LocationName { get; set; }
    public string Description { get; set; }
    public LocationAbility Ability { get; set; }
    public bool IsOnGoing { get; set; }
    public bool IsOnReveal { get; set; }
}
