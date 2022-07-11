using DigitalDisplay;
using FluentAssertions;

namespace UnitTests;

public class DisplayTests
{
    private static readonly List<DigitalNumber> Numbers = new()
    {
        new DigitalNumber
        {
            TopLine = "   ",
            MidLine = "  |",
            BotLine = "  |"
        },
        new DigitalNumber
        {
            TopLine = " _ ",
            MidLine = " _|",
            BotLine = "|_ "
        },
        new DigitalNumber
        {
            TopLine = " _ ",
            MidLine = " _|",
            BotLine = " _|"
        }
    };

    [Theory]
    [InlineData(4)]
    [InlineData(128)]
    public void Run_ForValidInput_ShouldWorkWithoutExceptions(int consoleWidth)
    {
        //arrange

        var display = new Display();

        //act 

        var action = () => display.Run(Numbers, consoleWidth);

        //assert

        action.Should().NotThrow<Exception>();
    }

    [Theory]
    [InlineData(-10)]
    [InlineData(0)]
    [InlineData(3)]
    public void Run_ForInvalidConsoleWidth_ShouldThrowArgumentException(int consoleWidth)
    {
        //arrange

        var display = new Display();


        var action = () => display.Run(Numbers, consoleWidth);


        action.Should().Throw<ArgumentException>().And.ParamName.Should().Be(nameof(consoleWidth));
    }

    public static IEnumerable<object?[]> GetNumbers()
    {
        yield return new object?[]
        {
            new List<DigitalNumber>
            {
                new()
                {
                    MidLine = "  |",
                    BotLine = "  |"
                }
            }
        };
        yield return new object?[]
        {
            new List<DigitalNumber>
            {
                new()
                {
                TopLine = "   ",
                BotLine = "  |"
                }
            }
        };
        yield return new object?[]
        {
            new List<DigitalNumber>
            {
                new()
                {
                    TopLine = "   ",
                    MidLine = "  |"
                }
            }
        };
        yield return new object?[]
        {
            new List<DigitalNumber>
            {
                new()
                {
                    TopLine = "   ",
                    MidLine = "  |"
                }
            }
        };
        yield return new object?[]
        {
            new List<DigitalNumber>()
        };
        yield return new object?[]
        {
            null
        };
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]

    public void Run_ForInvalidNumbers_ShouldThrowArgumentException(List<DigitalNumber> numbers)
    {
        //arrange

        var display = new Display();

        //act 

        var func = () => display.Run(numbers, 128);

        //assert

        func.Should().Throw<ArgumentException>().And.ParamName.Should().Be(nameof(numbers));
    }
}