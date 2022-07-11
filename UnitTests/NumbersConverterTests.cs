using DigitalDisplay;
using FluentAssertions;

namespace UnitTests;

public class NumbersConverterTests
{
    [Theory]
    [InlineData("1234567890")]
    [InlineData("13241564156448")]
    [InlineData("1")]
    public void ConvertNumbersToDigitalNumbers_ForValidInput_ShouldReturnDigitalNumbersList(string input)
    {
        //arrange

        var converter = new NumbersConverter();

        //act 

        var result = converter.ConvertNumbersToDigitalNumbers(input);

        //assert

        result.Should().NotBeNull().And.NotBeEmpty();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void ConvertNumbersToDigitalNumbers_ForEmptyString_ShouldThrowArgumentException(string input)
    {
        //arrange

        var converter = new NumbersConverter();

        //act 

        var func = () => converter.ConvertNumbersToDigitalNumbers(input);

        //assert

        func.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("123a")]
    [InlineData("-123")]
    [InlineData("#asd!$%$36")]
    public void ConvertNumbersToDigitalNumbers_ForInvalidInput_ShouldThrowArgumentException(string input)
    {
        //arrange

        var converter = new NumbersConverter();

        //act 

        var func = () => converter.ConvertNumbersToDigitalNumbers(input);

        //assert

        func.Should().Throw<ArgumentException>();
    }
}