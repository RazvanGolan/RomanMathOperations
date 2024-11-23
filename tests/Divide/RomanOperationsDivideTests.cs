namespace RomanMathOperations.Tests.Divide;

public class RomanOperationsDivideTests : RomanOperationsTests
{
    [Fact]
    public void Divide_GivenRomanNumberals_ReturnsExpectedQuotientAndRemainder()
    {
        var random = new Random();

        for (var i = 1; i <= 20; i++)
        {
            var num1 = random.Next(1, 3999);
            var num2 = random.Next(1, 3999);

            var roman1 = RomanConverter.ConvertDecimalToRoman(num1);
            var roman2 = RomanConverter.ConvertDecimalToRoman(num2);

            var romanQuotient = string.Empty;
            var romanRemainder = string.Empty;
            
            try
            {
                (romanQuotient, romanRemainder) = RomanOperations.Divide(roman1, roman2);
            }
            catch (Exception)
            {
                var quotient = RomanConverter.ConvertRomanToDecimal(romanQuotient);
                var remainder = RomanConverter.ConvertRomanToDecimal(romanRemainder);

                var result = (double)num1 / num2;
                var integerPart = (int)Math.Floor(result);

                Assert.Equal(result - integerPart, quotient);
                Assert.Equal(integerPart, remainder);
            }
        }
    }
    
    
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