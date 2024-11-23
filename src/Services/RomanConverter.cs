using System.Text;
using RomanMathOperations.Exceptions;
using RomanMathOperations.Models;

namespace RomanMathOperations.Services;

public class RomanConverter(IRomanService romanService) : IRomanConverter
{

    public int ConvertRomanToDecimal(string roman)
    {
        if (string.IsNullOrEmpty(roman))
            throw new ResultIsZeroException();

        var decimalValue = 0;
        var previousValue = 0;

        foreach (var c in roman)
        {
            if (!RomanNumbers.RomanToDecimalMap.TryGetValue(c, out var value))
                throw new InvalidRomanCharacter(roman, c);

            if (value > previousValue)
            {
                decimalValue += value - 2 * previousValue;
            }
            else
            {
                decimalValue += value;
            }

            previousValue = value;
        }

        return decimalValue;
    }

    public string ConvertDecimalToRoman(int number)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be greater than zero");

        var roman = new StringBuilder();

        // Handle numbers larger than 4000 with repeated M's
        while (number >= 4000)
        {
            roman.Append('M');
            number -= 1000;
        }

        foreach (var (value, symbol) in RomanNumbers.DecimalToRomanMap)
        {
            while (number >= value)
            {
                roman.Append(symbol);
                number -= value;
            }
        }

        return roman.ToString();
    }
}