# String Calculator

This project is a C# class library built using .NET 9 that provides an 'Add' method for summing numbers from a delimited string. The solution was written using TDD (Test Driven Development) and used the xUnit test framework.

## Add Method Features
- Handles numbers separated by commas (`,`) or new lines (`\n`).
- Supports custom single-character delimiters using the format `//[delimiter]\n[numbers...]`.
- Throws an exception for negative numbers, listing all negatives in the message.
- Ignores numbers greater than 1000.
- Supports multiple custom delimiters, e.g., `//*%\n1*2%3` returns `6`.

## Prerequisites
- .NET 9 SDK

## Usage
You can use the `StringCalculator.Add(string numbers)` method in your application. Example:
```csharp
var result = StringCalculator.Add("1,2,3"); // Returns 6
```

For more details, check the test cases in the xUnit project.
