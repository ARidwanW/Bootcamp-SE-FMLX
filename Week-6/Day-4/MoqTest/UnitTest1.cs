namespace MoqTest;

using System;
using NUnit.Framework;
using Moq;

public interface IPlayer
{
	int level{ get; set; }
	int id { get; set; }
	string GetName();
	bool SetName(string name);
}
public class GameController
{
	private IList<IPlayer> _players;

	public GameController(IList<IPlayer> players)
	{
		_players = players;
	}

	public IList<IPlayer> GetListPlayers()
	{
		return _players;
	}
}

[TestFixture]
public class GameControllerTests
{
	[Test]
	public void GetListPlayers_ReturnsCorrectPlayers()
	{
		// ARRANGE
		Mock<IPlayer> player1 = new Mock<IPlayer>();
		player1.SetupProperty(x => x.level,1);
		player1.SetupProperty(x => x.id,10);
		player1.Setup(u => u.GetName()).Returns(()=> "satrio");
		
		Mock<IPlayer> player2 = new Mock<IPlayer>();
		player2.SetupProperty(u => u.level, 3);
		player2.Setup(u => u.GetName()).Returns(()=> "joko");
		
		IList<IPlayer> players = new IPlayer[] { player2.Object, player2.Object };
		var GameRunner = new GameController(players);

		// ACT
		IList<IPlayer> result = GameRunner.GetListPlayers();

		// ASSERT
		Assert.That(result.Count(), Is.EqualTo(2));
		Assert.That(result[0].GetName(), Is.EqualTo("satrio"));
		Assert.That(result[1].GetName(), Is.EqualTo("joko"));
	}
}