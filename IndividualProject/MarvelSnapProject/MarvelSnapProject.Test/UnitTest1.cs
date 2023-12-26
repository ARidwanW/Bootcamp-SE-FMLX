using MarvelSnapProject;
using MarvelSnapProject.Enum;
namespace MarvelSnapProject.Test;

[TestFixture]
public class Tests
{
    private GameController game;
    [SetUp]
    public void Setup()
    {
        game = new GameController();
    }

    [Test]
    public void GetGameStatus_ShouldReturnGameStatusNone_WhenGameControllerIsNew()
    {
        GameStatus expected = GameStatus.None;
        var status = game.GetGameStatus();

        Assert.That(status, Is.EqualTo(expected));
    }

    //* TestCaseSource for GameStatus
    public static IEnumerable<GameStatus> GameStatusTestCases()
    {
        yield return GameStatus.None;
        yield return GameStatus.Running;
        yield return GameStatus.Finished;
    }

    [TestCaseSource(nameof(GameStatusTestCases))]
    public void SetAndGetGameStatus_ReturnSameValueAsInput(GameStatus inputStatus)
    {
        Assert.That(game.SetGameStatus(inputStatus), Is.EqualTo(true));

        var outputStatus = game.GetGameStatus();

        Assert.That(outputStatus, Is.EqualTo(inputStatus));
    }
}