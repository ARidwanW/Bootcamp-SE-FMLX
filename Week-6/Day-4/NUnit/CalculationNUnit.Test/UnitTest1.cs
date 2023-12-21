using Calculation;

namespace CalculationNUnit.Test;

[TestFixture]
public class NumberCalculationTests
{
    private NumberCalculation numberCalculation;

    [SetUp] //* --> new instance every test case
    //[OneTimeSetUp] //* --> one instance for all test case
    public void Setup()
    {
        numberCalculation = new NumberCalculation();
    }

    [TestCase(5, 4, 9)] //[Fact]
    [TestCase(2, 3, 5)]
    [TestCase(6, 1, 7)]
    [TestCase(0, 0, 0)]
    public void Add_ReturnCorrectNumber_AdditionOfTwoNumber(int a, int b, int expected)
    {
        //Arrange

        //Act
        int actual = numberCalculation.Add(a, b);

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Subtract_ReturnCorrectNumber_SubstractionOfTwoNumbers()
    {
        int a = 10;
        int b = 12;
        int expected = -2;

        int actual = numberCalculation.Subtract(a, b);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Multiply_ReturnCorrectNumber_MultiplicationOfTwoNumber()
    {
        int a = 10;
        int b = 12;
        int expected = 120;

        int actual = numberCalculation.Multiply(a, b);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Divide_ReturnCorrectNumber_DivisionOfTwoNumber()
    {
        int a = 10;
        int b = 2;
        int expected = 5;

        int actual = numberCalculation.Divide(a, b);


        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Divide_ShouldThrowDivideByZeroException_DivideByZero()
    {
        int a = 10;
        int b = 0;

        Assert.Throws<DivideByZeroException>(() => numberCalculation.Divide(a, b));
    }
}