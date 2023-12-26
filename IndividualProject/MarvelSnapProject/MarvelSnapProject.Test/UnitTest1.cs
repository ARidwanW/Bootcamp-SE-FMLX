using MarvelSnapProject;
using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Component.Player;
using MarvelSnapProject.Enum;
using Moq;

namespace MarvelSnapProject.Test;

[TestFixture]
public class Tests
{
    private GameController _game;
    private Mock<IPlayer> _player;
    private Mock<PlayerInfo> _playerInfo;
    private Mock<AbstractCard> _card;
    private Mock<AbstractLocation> _location;

    [SetUp]
    public void Setup()
    {
        _game = new GameController();
        _player = new Mock<IPlayer>();
        _playerInfo = new Mock<PlayerInfo>();
        _card = new Mock<AbstractCard>();
        _location = new Mock<AbstractLocation>();
    }

    [Test]
    public void GetGameStatus_ShouldReturnGameStatusNone_GameControllerIsNew()
    {
        GameStatus expected = GameStatus.None;
        var status = _game.GetGameStatus();

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
    public void SetGameStatus_ReturnsTrue_SetGameStatusSuccessfully(GameStatus status)
    {
        var gameStatus = _game.SetGameStatus(status);

        // Assert.That(gameStatus, Is.EqualTo(true));
        Assert.That(gameStatus, Is.True);
    }

    [TestCaseSource(nameof(GameStatusTestCases))]
    public void SetAndGetGameStatus_ReturnSameValueAsInput(GameStatus inputStatus)
    {
        Assert.That(_game.SetGameStatus(inputStatus), Is.True);

        var outputStatus = _game.GetGameStatus();

        Assert.That(outputStatus, Is.EqualTo(inputStatus));
    }

    [Test]
    public void GetCurrentRound_ReturnZero_GameControllerIsNew()
    {
        var round = _game.GetCurrentRound();

        Assert.That(round, Is.EqualTo(0));
    }

    [Test]
    public void GetTargetInvoke_ShouldReturnCorrectNames()
    {
        var testInstance1 = new TestInvokeClass { Name = "test1" };
        var testInstance2 = new TestInvokeClass { Name = "test2" };
        Action testDelegate1 = testInstance1.Run;
        Action testDelegate2 = testInstance2.Run;
        var combinedDelegate = (Action)Delegate.Combine(testDelegate1, testDelegate2);

        var result = _game.GetTargetInvoke<TestInvokeClass>(combinedDelegate);

        Assert.That(result, Is.EquivalentTo(new List<string> { "test1", "test2" }));
    }

    //* TestCaseSource for GameStatus
    public static IEnumerable<int> RoundsTestCases()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return i;
        }
    }

    [TestCaseSource(nameof(RoundsTestCases))]
    public void NextRound_ShouldReturnTrue_SetRoundSuccessfullyIfPlain(int round)
    {
        var result = _game.NextRound(round, true);

        Assert.That(result, Is.True);
    }

    [TestCaseSource(nameof(RoundsTestCases))]
    public void NextRound_ShouldSetRound_SetRoundSuccessfullyIfPlain(int round)
    {
        var result = _game.NextRound(round, true);

        Assert.That(result, Is.True);
        Assert.That(_game.GetCurrentRound(), Is.EqualTo(round));
    }

    [Test]
    public void NextRound_ShouldReturnTrue_IfPlainNoParameter()
    {
        var result = _game.NextRound(true);

        Assert.That(result, Is.True);
    }

    [Test]
    public void NextRound_ShoudSetRoundPlusOne_IfPlainNoParameter()
    {
        var result = _game.NextRound(true);

        Assert.That(result, Is.True);
        Assert.That(_game.GetCurrentRound(), Is.EqualTo(1));
    }

    [TestCaseSource(nameof(RoundsTestCases))]
    public void NextRound_ShouldSetRound(int round)
    {
        var result = _game.NextRound(round);

        Assert.That(result, Is.True);
        Assert.That(_game.GetCurrentRound(), Is.EqualTo(round));
    }

    [Test]
    public void AssignPlayer_ShouldAddPlayersCorrectly()
    {
        Mock<IPlayer> player2 = new();
        var result = _game.AssignPlayer(_player.Object, player2.Object);

        Assert.That(result, Is.True);

        var players = _game.GetPlayer();
        
        Assert.That(players, Contains.Item(_player.Object));
        Assert.That(players, Contains.Item(player2.Object));
    }

}

//* test GetTargetInvoke
public class TestInvokeClass
{
    public string? Name { get; set; }

    public void Run()
    { }
}