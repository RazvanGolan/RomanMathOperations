using RomanMathOperations.Services;

namespace RomanMathOperations.Operations;

public class RomanOperations
{
    public static string Addition(string roman1, string roman2)
    {
        string result = roman1 + roman2;

        result = SortRoman(result);

        return RomanNormalizer.NormalizeRoman(result);
    }

    private static string SortRoman(string roman)
    {
        return string.Concat(roman.OrderByDescending(c => RomanValue(c)));
    }
    
    private static int RomanValue(char romanChar)
    {
        return romanChar switch
        {
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            'C' => 100,
            'D' => 500,
            'M' => 1000,
            _ => throw new ArgumentException("Invalid Roman numeral character")
        };
    }
}