namespace RomanMathOperations.Tests.Divide;

public class RomanOperationsDivideTests : RomanOperationsTests
{
    [Fact]
    public void Divide_LargerBySmaller_ReturnsCorrectQuotientAndEmptyRemainder()
    {
        const string dividend = "X";
        const string divisor = "V";
        const string expectedQuotient = "II";
        const string expectedRemainder = "";

        var (quotient, remainder) = RomanOperations.Divide(dividend, divisor);

        Assert.Equal(expectedQuotient, quotient);
        Assert.Equal(expectedRemainder, remainder);
    }
    
    [Fact]
    public void Divide_LargerBySmaller_ReturnsCorrectQuotientAndNonEmptyRemainder()
    {
        const string dividend = "XIII";
        const string divisor = "V";
        const string expectedQuotient = "II";
        const string expectedRemainder = "III";

        var (quotient, remainder) = RomanOperations.Divide(dividend, divisor);

        Assert.Equal(expectedQuotient, quotient);
        Assert.Equal(expectedRemainder, remainder);
    }
    
    [Fact]
    public void Divide_SmallerByLarger_ReturnsEmptyQuotientAndDividendAsRemainder()
    {
        const string dividend = "V";
        const string divisor = "X";
        const string expectedQuotient = "";
        const string expectedRemainder = "V";

        var (quotient, remainder) = RomanOperations.Divide(dividend, divisor);

        Assert.Equal(expectedQuotient, quotient);
        Assert.Equal(expectedRemainder, remainder);
    }
    
    [Fact]
    public void Divide_ByOne_ReturnsSameNumberAsQuotient()
    {
        const string dividend = "X";
        const string divisor = "I";
        const string expectedQuotient = "X";
        const string expectedRemainder = "";

        var (quotient, remainder) = RomanOperations.Divide(dividend, divisor);

        Assert.Equal(expectedQuotient, quotient);
        Assert.Equal(expectedRemainder, remainder);
    }
    
    [Fact]
    public void Divide_EqualNumbers_ReturnsOneAndEmptyRemainder()
    {
        const string dividend = "X";
        const string divisor = "X";
        const string expectedQuotient = "I";
        const string expectedRemainder = "";

        var (quotient, remainder) = RomanOperations.Divide(dividend, divisor);

        Assert.Equal(expectedQuotient, quotient);
        Assert.Equal(expectedRemainder, remainder);
    }
}