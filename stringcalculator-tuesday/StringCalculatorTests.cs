
namespace StringCalculator;

public class StringCalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("", ',');

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("5", 5)]
    [InlineData("20", 20)]
    public void SingleDigits(string input, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(input, ',');
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,1", 2)]
    [InlineData("3,5,6", 14)]
    [InlineData("3,15,36", 54)]
    public void TwoDigits(string input, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(input, ',');
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n2,3", 6)]
    [InlineData("1\n3,15\n34,6", 59)]
    public void MultiDigitsWithNewLine(string input, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(input, ',');
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n2%3", 6, '%')]
    [InlineData("1?3?6", 10, '?')]
    [InlineData("1\n3;15\n34;6", 59, ';')]
    [InlineData("//;\n1;2", 3, ';')]
    public void MultiDigitsWithNewLineAndDelimiters(string input, int expected, char delimiter)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(input, delimiter);
        Assert.Equal(expected, result);
    }


}
