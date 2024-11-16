namespace RomanMathOperations.Exceptions;

public class ResultIsZeroException() : Exception("The result is 0, but Romans did not have a concept for that.");

public class InvalidRomanSubtractionException() : Exception("Cannot subtract a larger number from a smaller one.");

public class InvalidRomanCharacter(string number, char character)
    : Exception($"The number {number} contains an invalid roman character {character}");

public class InvalidRomanFormat(string number) : Exception($"The string {number} is not a valid roman number");
