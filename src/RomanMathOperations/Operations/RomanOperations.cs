using RomanMathOperations.Models;
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
                    throw new ArgumentException("Cannot subtract a larger number from a smaller one");
                }
            }
        }

        if (string.IsNullOrEmpty(expanded1))
        {
            throw new Exception("The result is 0, but romans did not have a concept for that");
        }
        
        return romanService.OptimizeNumber(expanded1);
    }
}