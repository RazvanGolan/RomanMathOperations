using Microsoft.Extensions.DependencyInjection;
using RomanMathOperations.Operations;
using RomanMathOperations.Services;

var serviceProvider = new ServiceCollection()
    .AddScoped<IRomanService, RomanService>()
    .AddScoped<IRomanOperations, RomanOperations>()
    .AddScoped<IRomanConverter, RomanConverter>()
    .BuildServiceProvider();

var romanOperations = serviceProvider.GetRequiredService<IRomanOperations>();

const string one = "III";
const string two = "M";

Console.WriteLine($"First number: {one}");
Console.WriteLine($"Second number: {two}");
Console.WriteLine();

try
{
    var addition = romanOperations.Add(one, two);
    Console.WriteLine($"Addition of {one} and {two}: {addition}");
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to add {one} and {two}: {ex.Message}");
}

try
{
    var subtraction = romanOperations.Subtract(one, two);
    Console.WriteLine($"Subtraction of {two} from {one}: {subtraction}");
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to subtract {two} from {one}: {ex.Message}");
}

try
{
    var multiplication = romanOperations.Multiply(one, two);
    Console.WriteLine($"Multiplication of {one} and {two}: {multiplication}");
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to multiply {one} and {two}: {ex.Message}");
}

try
{
    var (quotient, remainder) = romanOperations.Divide(one, two);
    Console.WriteLine($"Division of {one} by {two}:");
    Console.WriteLine($" - Quotient: {quotient}");
    Console.WriteLine($" - Remainder: {remainder}");
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to divide {one} by {two}: {ex.Message}");
}