namespace RomanMathOperations.Models;

public static class RomanNumbers
{
    public static readonly Dictionary<string, string> Expansions = new()
    {
        {"CM", "DCCCC"},
        {"CD", "CCCC"},
        {"XC", "LXXXX"},
        {"XL", "XXXX"},
        {"IX", "VIIII"},
        {"IV", "IIII"}
    };

    public static readonly List<(string From, string To)> Optimizations =
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
    
    public static readonly List<(string From, string To)> Decompozitions =
    [
        ("V", "IIIII"),
        ("X", "VV"),
        ("L", "XXXXX"),
        ("C", "LL"),
        ("D", "CCCCC"),
        ("M", "DD")
    ];
}