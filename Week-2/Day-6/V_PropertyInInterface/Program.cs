//Implement properties get;private set; for interfaces
public interface IGameController {
	//public int x; We cant declare variable inside interface
	void X();
	int MyProp {get;}
}
public class GameController : IGameController
{
	public int MyProp { get; private set; }

	public void X()
	{
		throw new NotImplementedException();
	}
}