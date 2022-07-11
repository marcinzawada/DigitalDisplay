namespace DigitalDisplay;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Please enter text with the numbers only.");

        var numbersString = Console.ReadLine();

        var converter = new NumbersConverter();

        try
        {
            var digitalNumbers = converter.ConvertNumbersToDigitalNumbers(numbersString);

            var display = new Display();

            display.Run(digitalNumbers, Console.WindowWidth);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid input.");
        }
    }
}
