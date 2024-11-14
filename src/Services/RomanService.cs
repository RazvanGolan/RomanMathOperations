using RomanMathOperations.Models;

namespace RomanMathOperations.Services;

public class RomanService : IRomanService
{
    public string ExpandNumber(string roman)
    {
        var expanded = roman;
        foreach (var expansion in RomanNumbers.Expansions)
        {
            expanded = expanded.Replace(expansion.Key, expansion.Value);
        }
        return expanded;
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
                _ => throw new ArgumentException($"The number {roman} contains an invalid roman character {c}")
            }).ToArray());
    }
}