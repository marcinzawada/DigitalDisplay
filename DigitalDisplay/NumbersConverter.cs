namespace DigitalDisplay;

public class NumbersConverter
{
    private static readonly Dictionary<int, DigitalNumber> DigitalNumbers = new()
    {
        {
            0, new DigitalNumber
            {
                TopLine = " _ ",
                MidLine = "| |",
                BotLine = "|_|"
            }
        },
        {
            1, new DigitalNumber
            {
                TopLine = "   ",
                MidLine = "  |",
                BotLine = "  |"
            }
        },
        {
            2, new DigitalNumber
            {
                TopLine = " _ ",
                MidLine = " _|",
                BotLine = "|_ "
            }
        },
        {
            3, new DigitalNumber
            {
                TopLine = " _ ",
                MidLine = " _|",
                BotLine = " _|"
            }
        },
        {
            4, new DigitalNumber
            {
                TopLine = "   ",
                MidLine = "|_|",
                BotLine = "  |"
            }
        },
        {
            5, new DigitalNumber
            {
                TopLine = " _ ",
                MidLine = "|_ ",
                BotLine = " _|"
            }
        },
        {
            6, new DigitalNumber
            {
                TopLine = " _ ",
                MidLine = "|_ ",
                BotLine = "|_|"
            }
        },
        {
            7, new DigitalNumber
            {
                TopLine = " _ ",
                MidLine = "  |",
                BotLine = "  |"
            }
        },
        {
            8, new DigitalNumber
            {
                TopLine = " _ ",
                MidLine = "|_|",
                BotLine = "|_|"
            }
        },
        {
            9, new DigitalNumber
            {
                TopLine = " _ ",
                MidLine = "|_|",
                BotLine = " _|"
            }
        }
    };


    public List<DigitalNumber> ConvertNumbersToDigitalNumbers(string? numbersText)
    {
        if (string.IsNullOrEmpty(numbersText))
        {
            throw new ArgumentException("Invalid numbers.", nameof(numbersText));
        }

        var digitalNumbers = new List<DigitalNumber>();

        foreach (var numberChar in numbersText)
        {
            var number = (int)char.GetNumericValue(numberChar);

            var isNumberInDictionary = DigitalNumbers.TryGetValue(number, out var digitalNumber);
            if (!isNumberInDictionary)
            {
                throw new ArgumentException("Text contains invalid characters.", nameof(numbersText));
            }

            digitalNumbers.Add(digitalNumber!);
        }

        return digitalNumbers;
    }
}

