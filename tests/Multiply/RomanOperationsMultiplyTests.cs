namespace RomanMathOperations.Tests.Multiply;

public class RomanOperationsMultiplyTests : RomanOperationsTests
{
    [Fact]
    public void Multiply_GivenRomanNumerals_ReturnsExpectedProduct()
    {
        const string first = "X";
        const string second = "V";
        const string expectedProduct = "L"; 

        var result = RomanOperations.Multiply(first, second);

        Assert.Equal(expectedProduct, result);
    }
    
    [Fact]
    public void Multiply_ByOne_ReturnsSameNumber()
    {
        const string first = "X";
        const string second = "I";
        const string expectedProduct = "X";

        var result = RomanOperations.Multiply(first, second);

        Assert.Equal(expectedProduct, result);
    }
}