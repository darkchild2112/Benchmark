using System;

namespace Benchmark.Lib;

public class StringCalculator
{
    private static readonly string[] defaultDelimiters = [",", "\n"];

    public int Add(string numbers)
    {
        if(string.IsNullOrEmpty(numbers))
            return 0;

        var split = numbers.Split(defaultDelimiters, StringSplitOptions.None);

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
}
