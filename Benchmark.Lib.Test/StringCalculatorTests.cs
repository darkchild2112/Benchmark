namespace Benchmark.Lib.Test;

public class StringCalculatorTests
{
    [Theory]
    [InlineData("", 0)]
    [InlineData("1", 1)]
    [InlineData("1,2", 3)]
    public void Strould_Return_The_Expected_Result(string input, int expectedResult)
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add(input);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("1\n2,3", 6)]
    [InlineData("1,2\n3", 6)]
    [InlineData("“//;\n1;2”", 3)]
    public void Strould_Allow_Different_Types_Of_Delimeters(string input, int expectedResult)
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add(input);

        // Assert
        Assert.Equal(expectedResult, result);
    }


    [Theory]
    [InlineData("//*%\n1*2%3", 6)]
    public void Strould_Allow_Multiple_Delimeters(string input, int expectedResult)
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add(input);

        // Assert
        Assert.Equal(expectedResult, result);
    }


    [Theory]
    [InlineData("1,1001", 1)]
    [InlineData("2,1001,13", 15)]
    public void Should_Ignore_Values_Greater_Than_1000(string input, int expectedResult)
    {
        // Arrange
        var calculator = new StringCalculator();

        // Act
        var result = calculator.Add(input);

        // Assert
        Assert.Equal(2, result);
    }

    [Theory]
    [InlineData("1,\n")]
    public void Strould_Throw_An_Exception_When_Given_Invalid_Input(string input)
    {
        var calculator = new StringCalculator();

        var result = Assert.Throws<ArgumentException>(() => calculator.Add(input));
    }

    [Theory]
    [InlineData("-1,\n")]
    [InlineData("-1,-10")]
    [InlineData("-1,3,4,5")]
    public void Strould_Throw_An_Exception_When_Given_Negative_Values(string input)
    {
        var calculator = new StringCalculator();

        var result = Assert.Throws<ArgumentException>(() => calculator.Add(input));

        // TODO: Assert the exception message   

    }
}
