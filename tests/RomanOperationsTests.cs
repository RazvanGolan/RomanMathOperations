using Microsoft.Extensions.DependencyInjection;
using RomanMathOperations.Exceptions;
using RomanMathOperations.Operations;
using RomanMathOperations.Services;

namespace RomanMathOperations.Tests
{
    public class RomanOperationsTests
    {
        protected readonly IRomanOperations RomanOperations;
        protected readonly IRomanConverter RomanConverter;

        public RomanOperationsTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRomanService, RomanService>()
                .AddScoped<IRomanOperations, RomanOperations>()
                .AddScoped<IRomanConverter, RomanConverter>()
                .BuildServiceProvider();

            RomanOperations = serviceProvider.GetRequiredService<IRomanOperations>();
            RomanConverter = serviceProvider.GetRequiredService<IRomanConverter>();
        }
        
        [Theory]
        [InlineData("ABC", "V")]
        [InlineData("X", "DEF")]
        [InlineData("XYZ", "DEF")]
        public void Operations_InvalidRomanCharacters_ThrowsInvalidRomanCharacter(string first, string second)
        {
            Assert.Throws<InvalidRomanCharacter>(() => RomanOperations.Add(first, second));
            Assert.Throws<InvalidRomanCharacter>(() => RomanOperations.Subtract(first, second));
            Assert.Throws<InvalidRomanCharacter>(() => RomanOperations.Multiply(first, second));
            Assert.Throws<InvalidRomanCharacter>(() => RomanOperations.Divide(first, second));
        }
        
        [Theory]
        [InlineData("XXXX", "V")]
        [InlineData("X", "VVVV")]
        [InlineData("XXXX", "VVVV")]
        public void Operations_InvalidRomanFormat_ThrowsInvalidRomanFormat(string first, string second)
        {
            Assert.Throws<InvalidRomanFormat>(() => RomanOperations.Add(first, second));
            Assert.Throws<InvalidRomanFormat>(() => RomanOperations.Subtract(first, second));
            Assert.Throws<InvalidRomanFormat>(() => RomanOperations.Multiply(first, second));
            Assert.Throws<InvalidRomanFormat>(() => RomanOperations.Divide(first, second));
        }
    }
}