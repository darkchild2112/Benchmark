namespace Benchmark.Lib.Test;

public sealed class StringCalculatorTests
{
    [Theory]
    [InlineData("", 0)]
    [InlineData("1", 1)]
    [InlineData("1,2", 3)]
    [InlineData("10,20,30,40,50", 150)]
    [InlineData("5, 15, 45, 2, 3", 70)]
    public void Should_Return_The_Expected_Result(string input, int expectedResult)
    {
        var result = StringCalculator.Add(input);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("1\n2,3", 6)]
    [InlineData("1,2\n3", 6)]
    [InlineData("//;\n1;2", 3)]
    public void Should_Allow_Different_Types_Of_Delimeters(string input, int expectedResult)
    {
        var result = StringCalculator.Add(input);

        Assert.Equal(expectedResult, result);
    }


    [Theory]
    [InlineData("//*%\n1*2%3", 6)]
    public void Should_Allow_Multiple_Delimeters(string input, int expectedResult)
    {
        var result = StringCalculator.Add(input);

        Assert.Equal(expectedResult, result);
    }


    [Theory]
    [InlineData("1,1001", 1)]
    [InlineData("2,1001,13", 15)]
    public void Should_Ignore_Values_Greater_Than_1000(string input, int expectedResult)
    {
        var result = StringCalculator.Add(input);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("1,\n")]
    [InlineData("1,^")]
    [InlineData("1,abz")]
    public void Should_Throw_An_Exception_When_Given_Invalid_Input(string input) => 
        Assert.Throws<ArgumentException>(() => StringCalculator.Add(input));

    [Theory]
    [InlineData("-1,-10", "-1, -10")]
    [InlineData("-1,3,4,5", "-1")]
    public void Should_Throw_An_Exception_When_Given_Negative_Values(string input, string rejectedNumbers)
    {
        var result = Assert.Throws<ArgumentException>(() => StringCalculator.Add(input));
 
        Assert.True(result.Message == $"Negatives are not allowed: {rejectedNumbers}");
    }
}
