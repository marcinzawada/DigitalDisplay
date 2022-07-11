using System.Text;

namespace DigitalDisplay;

public class Display
{
    private const int NumberWithSpaceWidth = 4;

    private readonly StringBuilder _topLine = new();
    private readonly StringBuilder _midLine = new();
    private readonly StringBuilder _botLine = new();


    public void Run(List<DigitalNumber> numbers, int consoleWidth)
    {
        if (consoleWidth < 4)
        {
            throw new ArgumentException($"Console width must be at least {NumberWithSpaceWidth}.", nameof(consoleWidth));
        }

        CheckNumbers(numbers);

        var lineWidth = 0;

        foreach (var number in numbers)
        {
            if (!NextNumberWillFitInConsole(lineWidth, consoleWidth))
            {
                WriteNumbersToConsole();
                lineWidth = 0;
            }

            AddNumberToOutput(number);
            lineWidth += NumberWithSpaceWidth;
        }

        WriteNumbersToConsole();
    }

    private static void CheckNumbers(List<DigitalNumber> numbers)
    {
        if (numbers == null ||
            !numbers.Any() ||
            numbers.Any(x =>
                string.IsNullOrEmpty(x.TopLine) ||
                string.IsNullOrEmpty(x.MidLine) ||
                string.IsNullOrEmpty(x.BotLine)))
        {
            throw new ArgumentException("Invalid digital numbers.", nameof(numbers));
        }
    }

    private bool NextNumberWillFitInConsole(int lineWidth, int consoleWidth)
    {
        return consoleWidth - lineWidth > NumberWithSpaceWidth;
    }

    private void WriteNumbersToConsole()
    {
        Console.WriteLine();
        Console.WriteLine(_topLine);
        Console.WriteLine(_midLine);
        Console.WriteLine(_botLine);
        _topLine.Clear();
        _midLine.Clear();
        _botLine.Clear();
    }

    private void AddNumberToOutput(DigitalNumber number)
    {
        _topLine.Append(number.TopLine).Append(' ');
        _midLine.Append(number.MidLine).Append(' ');
        _botLine.Append(number.BotLine).Append(' ');
    }
}