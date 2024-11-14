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
        ("VVVVV", "XXV"),
        ("XXXXX", "L"),
        ("LLLLL", "CCL"),
        ("CCCCC", "D"),
        ("DDDDD", "MMD"),

        // Groups of two
        ("VV", "X"),
        ("LL", "C"),
        ("DD", "M"),

        // Subtractive combinations
        ("VIIII", "IX"),
        ("IIII", "IV"),
        ("LXXXX", "XC"),
        ("XXXX", "XL"),
        ("DCCCC", "CM"),
        ("CCCC", "CD")
    ];
}