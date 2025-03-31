# String Calculator

This project is a C# class library built using .NET 9 that provides an 'Add' method for summing numbers from a delimited string. The solution was written using TDD (Test Driven Development) using an xunit project.

## Add Method Features
- Handles numbers separated by commas (`,`) or new lines (`\n`).
- Supports custom single-character delimiters using the format `//[delimiter]\n[numbers...]`.
- Throws an exception for negative numbers, listing all negatives in the message.
- Ignores numbers greater than 1000.
- Supports multiple custom delimiters, e.g., `//*%\n1*2%3` returns `6`.

## Getting Started
### Prerequisites
- **.NET 9 SDK**

### Installation
1. **Clone the repository:**
   ```sh
   git clone https://github.com/your-repo/string-calculator.git
   cd string-calculator
   ```
2. **Restore dependencies:**
   ```sh
   dotnet restore
   ```
3. **Build the solution:**
   ```sh
   dotnet build
   ```

### Running Tests
Execute the unit tests with:
```sh
   dotnet test
```

## Usage
You can use the `StringCalculator.Add(string numbers)` method in your application. Example:
```csharp
var result = StringCalculator.Add("1,2,3"); // Returns 6
```

For more details, check the test cases in the xUnit project.
