using Microsoft.Extensions.DependencyInjection;
using RomanMathOperations.Operations;
using RomanMathOperations.Services;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IRomanService, RomanService>()
    .AddSingleton<IRomanOperations, RomanOperations>()
    .BuildServiceProvider();

var romanOperations = serviceProvider.GetRequiredService<IRomanOperations>();

const string one = "XIX";
const string two = "V";

var result = romanOperations.Add(one, two);

Console.WriteLine(result);