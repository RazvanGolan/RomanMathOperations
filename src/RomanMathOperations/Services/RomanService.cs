using RomanMathOperations.Models;

namespace RomanMathOperations.Services;

public class RomanService : IRomanService
{
    public string ExpandNumber(string roman)
    {
        string expanded = roman;
        foreach (var expansion in RomanNumbers.Expansions)
        {
            expanded = expanded.Replace(expansion.Key, expansion.Value);
        }
        return expanded;
    }

    public string OptimizeNumber(string roman)
    {
        // First sort the characters by their value
        var sorted = new string(roman.OrderByDescending(c => 
            c switch
            {
                'M' => 7,
                'D' => 6,
                'C' => 5,
                'L' => 4,
                'X' => 3,
                'V' => 2,
                'I' => 1,
                _ => 0
            }).ToArray());

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
}