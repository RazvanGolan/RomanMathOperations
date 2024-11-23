namespace RomanMathOperations.Tests.Add;

public class RomanOperationsAddTests : RomanOperationsTests
{
    [Fact]
    public void Add_GivenRomanNumerals_ReturnsExpectedSum()
    {
        var random = new Random();

        for (var i = 1; i <= 20; i++)
        {
            var num1 = random.Next(1, 3999);
            var num2 = random.Next(1, 3999);

            var roman1 = RomanConverter.ConvertDecimalToRoman(num1);
            var roman2 = RomanConverter.ConvertDecimalToRoman(num2);

            var romanSum = RomanOperations.Add(roman1, roman2);
            var sum = RomanConverter.ConvertRomanToDecimal(romanSum);
            Assert.Equal(num1 + num2, sum);
        }
    }
}