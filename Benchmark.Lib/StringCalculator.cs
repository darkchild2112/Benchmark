using System;

namespace Benchmark.Lib;

public class StringCalculator
{
    private static readonly char[] defaultDelimiters = [',', '\n'];

    public int Add(string numbers)
    {
        // Add Extension method to check for empty or white space
        if(string.IsNullOrEmpty(numbers))
            return 0;

        var delimeters = GetDelimeters(numbers);
        var formattedInput = FormatInput(numbers);

        var split = formattedInput.Split(delimeters, StringSplitOptions.None);

        var validNumbers = new List<int>();
        var invalidNumbers = new List<int>();

        for (int i = 0; i < split.Length; i++)
        {
            var parsed = int.TryParse(split[i], out int num);

            if(!parsed)
                throw new ArgumentException($"Invalid number given: {split[i]}");

            if (num < 0)
                invalidNumbers.Add(num);

            if (num > 0 && num < 1000)
                validNumbers.Add(num);
        }

        if(invalidNumbers.Count > 0)
            throw new ArgumentException($"Negatives not allowed: {string.Join(", ", invalidNumbers)}");

        return validNumbers.Sum();
    }

    private char[] GetDelimeters(string input)
    {
        if (input.StartsWith("//"))
        {
            var delimeters = input.Substring(2, input.IndexOf("\n") - 2);
            return [..defaultDelimiters, ..delimeters.ToArray()];
        }

        return defaultDelimiters;
    }

    private string FormatInput(string input)
    {
        if (input.StartsWith("//"))
            return input.Substring(input.IndexOf("\n") + 1);

        return input;
    }
}
