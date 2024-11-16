namespace RomanMathOperations.Tests.Add;

public class RomanOperationsAddTests : RomanOperationsTests
{
    [Fact]
    public void Add_GivenRomanNumerals_ReturnsExpectedSum()
    {
        const string first = "X";
        const string second = "V";
        const string expectedSum = "XV";
            
        var result = RomanOperations.Add(first, second);
            
        Assert.Equal(expectedSum, result);
    }
}