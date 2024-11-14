﻿using Microsoft.Extensions.DependencyInjection;
using RomanMathOperations.Operations;
using RomanMathOperations.Services;

var serviceProvider = new ServiceCollection()
    .AddScoped<IRomanService, RomanService>()
    .AddScoped<IRomanOperations, RomanOperations>()
    .BuildServiceProvider();

var romanOperations = serviceProvider.GetRequiredService<IRomanOperations>();

const string one = "MCCCLXXVII"; // 1377
const string two = "MXCII"; // 1092

// const string one = "IX"; // 1377
// const string two = "I"; // 1092

var addition = romanOperations.Add(one, two);
var subtraction = romanOperations.Subtract(one, two);

Console.WriteLine(addition);
Console.WriteLine(subtraction);