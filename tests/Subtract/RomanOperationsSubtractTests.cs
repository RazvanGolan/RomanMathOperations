using RomanMathOperations.Exceptions;

namespace RomanMathOperations.Tests.Subtract;

public class RomanOperationsSubtractTests : RomanOperationsTests
{
    [Fact]
    public void Subtract_GivenRomanNumerals_ReturnsExpectedDifference()
    {
        var random = new Random();

        for (var i = 1; i <= 10; i++)
        {
            var num1 = random.Next(1, 3999);
            var num2 = random.Next(1, 3999);

            var roman1 = RomanConverter.ConvertDecimalToRoman(num1);
            var roman2 = RomanConverter.ConvertDecimalToRoman(num2);

            try
            {
                var romanDifference = RomanOperations.Subtract(roman1, roman2);
                var difference = RomanConverter.ConvertRomanToDecimal(romanDifference);

                Assert.Equal(num1 - num2, difference);
            }
            catch (ResultIsZeroException)
            {
                Assert.Equal(num1, num2);
            }
            catch (InvalidRomanSubtractionException)
            {
                Assert.True(num1 < num2);
            }
        }
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