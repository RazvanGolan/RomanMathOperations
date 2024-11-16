using RomanMathOperations.Exceptions;
using RomanMathOperations.Models;

namespace RomanMathOperations.Services;

public class RomanService : IRomanService
{
    public string ExpandNumber(string roman)
    {
        IsValidRomanNumber(roman);
        
        string previous;
        do
        {
            previous = roman;
            foreach (var expansion in RomanNumbers.Expansions)
            {
                roman = roman.Replace(expansion.Key, expansion.Value);
            }
        } while (previous != roman);

        return roman;
    }

    public string OptimizeNumber(string roman)
    {
        var sorted = OrderRoman(roman);

        string previous;
        do
        {
            previous = sorted;
            foreach (var (from, to) in RomanNumbers.Optimizations)
            {
                sorted = sorted.Replace(from, to);
            }
        } while (previous != sorted);

        return sorted;
    }

    public string DecomposeNumber(string roman)
    {
        var sorted = OrderRoman(roman);
        
        foreach (var (from, to) in RomanNumbers.Decompozitions)
        {
            sorted = sorted.Replace(from, to);
        }

        return sorted;
    }

    private static string OrderRoman(string roman)
    {
        return new string(roman.OrderByDescending(c => 
            c switch
            {
                'M' => 7,
                'D' => 6,
                'C' => 5,
                'L' => 4,
                'X' => 3,
                'V' => 2,
                'I' => 1,
                _ => throw new InvalidRomanCharacter(roman, c)
            }).ToArray());
    }
    
    public void IsValidRomanNumber(string roman)
    {
        if (string.IsNullOrWhiteSpace(roman))
            throw new ResultIsZeroException();

        const string validCharacters = "IVXLCDM";
    
        foreach (var c in roman.ToUpper())
        {
            if (!validCharacters.Contains(c))
            {
                throw new InvalidRomanCharacter(roman, c);
            }
        }
        
        const string romanPattern = @"^(?!(.*IIII|.*XXXX|.*CCCC|.*VV|.*LL|.*DD))M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";;

        if (!System.Text.RegularExpressions.Regex.IsMatch(roman, romanPattern))
        {
            throw new InvalidRomanFormat(roman);
        }
    }
}