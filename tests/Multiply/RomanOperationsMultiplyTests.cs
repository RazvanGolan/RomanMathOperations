namespace RomanMathOperations.Tests.Multiply;

public class RomanOperationsMultiplyTests : RomanOperationsTests
{
    [Fact]
    public void Multiply_GivenRomanNumerals_ReturnsExpectedProduct()
    {
        var random = new Random();

        for (var i = 1; i <= 20; i++)
        {
            var num1 = random.Next(1, 3999);
            var num2 = random.Next(1, 3999);

            var roman1 = RomanConverter.ConvertDecimalToRoman(num1);
            var roman2 = RomanConverter.ConvertDecimalToRoman(num2);

            var romanProduct = RomanOperations.Multiply(roman1, roman2);
            var product = RomanConverter.ConvertRomanToDecimal(romanProduct);
            Assert.Equal(num1 * num2, product);
        }
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