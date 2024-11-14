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
}