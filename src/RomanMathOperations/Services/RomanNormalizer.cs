namespace RomanMathOperations.Services;

public class RomanNormalizer
{
    public static string NormalizeRoman(string roman)
    {
        return roman
            .Replace("IIII", "IV")   // IV (4) instead of IIII
            .Replace("VIV", "IX")    // IX (9) instead of VIV
            .Replace("XXXX", "XL")   // XL (40) instead of XXXX
            .Replace("LXL", "XC")    // XC (90) instead of LXL
            .Replace("CCCC", "CD")   // CD (400) instead of CCCC
            .Replace("DCD", "CM");   // CM (900) instead of DCD
    }
}