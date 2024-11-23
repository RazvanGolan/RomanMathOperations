namespace RomanMathOperations.Services;

public interface IRomanConverter
{
    int ConvertRomanToDecimal(string roman);
    string ConvertDecimalToRoman(int number);
}