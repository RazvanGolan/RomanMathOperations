namespace RomanMathOperations.Models;

public static class RomanNumbers
{
    internal static readonly Dictionary<string, string> Expansions = new()
    {
        {"CM", "DCCCC"},
        {"CD", "CCCC"},
        {"XC", "LXXXX"},
        {"XL", "XXXX"},
        {"IX", "VIIII"},
        {"IV", "IIII"}
    };

    internal static readonly List<(string From, string To)> Optimizations =
    [
        ("IIIII", "V"),
        ("VV", "X"),
        ("VVVVV", "XXV"),
        ("XXXXX", "L"),
        ("LL", "C"),
        ("LLLLL", "CCL"),
        ("CCCCC", "D"),
        ("DD", "M"),
        ("DDDDD", "MMD"),
        
        ("VIIII", "IX"),
        ("IIII", "IV"),
        ("LXXXX", "XC"),
        ("XXXX", "XL"),
        ("DCCCC", "CM"),
        ("CCCC", "CD")
    ];
    
    internal static readonly List<(string From, string To)> Decompozitions =
    [
        ("V", "IIIII"),
        ("X", "VV"),
        ("L", "XXXXX"),
        ("C", "LL"),
        ("D", "CCCCC"),
        ("M", "DD")
    ];
    
    internal static readonly Dictionary<char, int> RomanToDecimalMap = new()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };

    internal static readonly List<(int Value, string Symbol)> DecimalToRomanMap =
    [
        (1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I")
    ];
}