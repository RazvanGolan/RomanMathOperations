using RomanMathOperations.Exceptions;

namespace RomanMathOperations.Tests.Subtract;

public class RomanOperationsSubtractTests : RomanOperationsTests
{
    [Fact]
    public void Subtract_GivenRomanNumerals_ReturnsExpectedDifference()
    {
        const string first = "X";
        const string second = "V";
        const string expectedSum = "V";
            
        var result = RomanOperations.Subtract(first, second);
            
        Assert.Equal(expectedSum, result);
    }
    
    [Fact]
    public void Subtract_LargerRomanNumeralFromSmaller_Throws()
    {
        const string smaller = "V";
        const string larger = "X";
            
        Assert.Throws<InvalidRomanSubtractionException>(() => RomanOperations.Subtract(smaller, larger));
    }
    
    
    [Fact]
    public void Subtract_TwoEqualNumbers_Throws()
    {
        const string first = "X";
        const string second = "X";
            
        Assert.Throws<ResultIsZeroException>(() => RomanOperations.Subtract(first, second));
    }
}