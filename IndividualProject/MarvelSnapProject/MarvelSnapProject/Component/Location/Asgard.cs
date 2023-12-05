namespace MarvelSnapProject.Component.Location;

public class Asgard : AbstractLocation
{
    public Asgard() : base(1, "Asgard", "tempat para dewa", Enum.LocationAbility.Asgard)
    {
        
    }
    public override bool DoAbility(GameController game)
    {
        return true;
    }
}
