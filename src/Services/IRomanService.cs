namespace RomanMathOperations.Services;

public interface IRomanService
{
    string ExpandNumber(string roman);
    string OptimizeNumber(string roman);
    string DecomposeNumber(string roman);
}