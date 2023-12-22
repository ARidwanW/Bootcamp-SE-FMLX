namespace MoqTest2;

using System;
using Moq;

class GameController
{
	private IDice dice;
	public GameController(IDice dice)
	{
		this.dice = dice;
	}
	public int Roll()
	{
		return dice.Roll() * 10;
	}
	public string Roll(int total)
	{
		List<int> totalDice = new();
		if (total > 1)
			for (int i = 0; i < total; i++)
			{
				totalDice.Add(dice.Roll());
			}
		if (totalDice.Distinct().ToList().Count == 1) return "Double";
		return "Different";
	}
}
public interface IDice
{
	int Roll();
}
public class GameControllerTest
{
	[Theory]
	[InlineData(2, 2, "Double")]
	public void Roll_ValueResult(int first, int second, string expected)
	{
		//Arrange
		var mockDice = new Mock<IDice>();
		mockDice.SetupSequence(dice => dice.Roll())
				.Returns(first)
				.Returns(second);
		GameController game = new GameController(mockDice.Object);

		//Act
		string result = game.Roll(2);

		//Assert
		Assert.Equal(expected, result);
	}
}