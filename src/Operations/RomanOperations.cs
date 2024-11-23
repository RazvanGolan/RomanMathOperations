using RomanMathOperations.Exceptions;
using RomanMathOperations.Services;

namespace RomanMathOperations.Operations;

public class RomanOperations(IRomanService romanService) : IRomanOperations
{
    public string Add(string first, string second)
    {
        var expanded1 = romanService.ExpandNumber(first);
        var expanded2 = romanService.ExpandNumber(second);
        
        var result = romanService.OptimizeNumber(expanded1 + expanded2);
        
        return result;
    }
    
    public string Subtract(string first, string second)
    {
        var expanded1 = romanService.ExpandNumber(first);
        var expanded2 = romanService.ExpandNumber(second);

        foreach (var c in expanded2)
        {
            var index = expanded1.IndexOf(c);
            if (index >= 0)
            {
                expanded1 = expanded1.Remove(index, 1);
            }
            else
            {
                if (string.IsNullOrEmpty(expanded1))
                {
                    throw new InvalidRomanSubtractionException();
                }
                
                // If "first" does not contain the character 'c', decompose it repeatedly until either:
                // 1. It contains 'c', or
                // 2. It becomes a string made up entirely of 'I' characters
                var simplified = romanService.DecomposeNumber(expanded1);

                while (!simplified.Contains(c) && simplified[0] != 'I')
                {
                    simplified = romanService.DecomposeNumber(simplified);
                }
                
                if (simplified.Contains(c))
                {
                    index = simplified.IndexOf(c);
                    expanded1 = simplified.Remove(index, 1);
                }
                else
                {
                    throw new InvalidRomanSubtractionException();
                }
            }
        }

        if (string.IsNullOrEmpty(expanded1))
        {
            throw new ResultIsZeroException();
        }
        
        return romanService.OptimizeNumber(expanded1);
    }

    public string Multiply(string first, string second)
    {
        romanService.IsValidRomanNumber(first);
        romanService.IsValidRomanNumber(second);
        var result = first;

        if (second.Equals("I"))
        {
            return result;
        }

        while (!second.Equals("I"))
        {
            result = Add(result, first);
            second = Subtract(second, "I");
        }

        return result;
    }

    public (string, string) Divide(string first, string second)
    {
        romanService.IsValidRomanNumber(first);
        romanService.IsValidRomanNumber(second);
        var quotient = string.Empty;
        var remainder = string.Empty;

        if (second.Equals("I"))
        {
            return (first, remainder);
        }

        if (first.Equals(second))
        {
            return ("I", string.Empty);
        }

        try
        {
            while (true)
            {
                first = Subtract(first, second);
                quotient = string.IsNullOrEmpty(quotient) ? "I" : Add(quotient, "I");
            }
        }
        catch (ResultIsZeroException)
        {
            // If there is no remainder
            quotient = Add(quotient, "I");

            return (quotient, remainder);
        }
        catch (InvalidRomanSubtractionException)
        {
            // If there is remainder
            remainder = first;

            return (quotient, remainder);
        }
    }
}