using Microsoft.Extensions.DependencyInjection;
using RomanMathOperations.Operations;
using RomanMathOperations.Services;

namespace RomanMathOperations.Tests
{
    public class RomanOperationsTests
    {
        private readonly IRomanOperations _romanOperations;

        public RomanOperationsTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRomanService, RomanService>()
                .AddScoped<IRomanOperations, RomanOperations>()
                .BuildServiceProvider();

            _romanOperations = serviceProvider.GetService<IRomanOperations>()!;
        }

        [Fact]
        public void Add_GivenRomanNumerals_ReturnsExpectedSum()
        {
            const string first = "X";
            const string second = "V";
            const string expectedSum = "XV";
            
            var result = _romanOperations.Add(first, second);
            
            Assert.Equal(expectedSum, result);
        }
        
        [Fact]
        public void Subtract_GivenRomanNumerals_ReturnsExpectedDifference()
        {
            const string first = "X";
            const string second = "V";
            const string expectedSum = "V";
            
            var result = _romanOperations.Subtract(first, second);
            
            Assert.Equal(expectedSum, result);

        }
        
        [Fact]
        public void Add_InvalidRomanNumerals_ThrowsArgumentException()
        {
            const string invalidFirst = "ABC";
            const string validSecond = "V";
            
            Assert.Throws<ArgumentException>(() => _romanOperations.Add(invalidFirst, validSecond));
        }
        
        [Fact]
        public void Subtract_InvalidRomanNumerals_ThrowsArgumentException()
        {
            const string invalidFirst = "ABC";
            const string validSecond = "V";
            
            
            Assert.Throws<ArgumentException>(() => _romanOperations.Subtract(invalidFirst, validSecond));
        }
        
        [Fact]
        public void Subtract_LargerRomanNumeralFromSmaller_ThrowsArgumentException()
        {
            const string smaller = "V";
            const string larger = "X";
            
            Assert.Throws<ArgumentException>(() => _romanOperations.Subtract(smaller, larger));
        }

        [Fact]
        public void Subtract_TwoEqualNumbers_ThrowsException()
        {
            const string first = "X";
            const string second = "X";
            
            Assert.Throws<InvalidOperationException>(() => _romanOperations.Subtract(first, second));
        }
    }
}