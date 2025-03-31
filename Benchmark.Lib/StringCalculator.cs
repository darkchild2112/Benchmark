namespace Benchmark.Lib;

public static class StringCalculator
{
    private static readonly char[] defaultDelimiters = [',', '\n'];

    public static int Add(string numbers)
    {
        if(string.IsNullOrEmpty(numbers))
            return 0;

        var delimeters = GetDelimeters(numbers);
        var formattedInput = FormatInput(numbers);

        var numArr = formattedInput.Split(delimeters, StringSplitOptions.None);

        var validNumbers = new List<int>();
        var invalidNumbers = new List<int>();

        for (int i = 0; i < numArr.Length; i++)
        {
            var parsed = int.TryParse(numArr[i], out int num);

            if(!parsed)
                throw new ArgumentException($"Invalid number given: {numArr[i]}");

            if (num < 0)
                invalidNumbers.Add(num);

            if (num > 0 && num < 1000)
                validNumbers.Add(num);
        }

        if(invalidNumbers.Count > 0)
            throw new ArgumentException($"Negatives are not allowed: {string.Join(", ", invalidNumbers)}");

        return validNumbers.Sum();
    }

    private static char[] GetDelimeters(string input)
    {
        if (input.StartsWith("//"))
        {
            var delimeters = input.Substring(2, input.IndexOf("\n") - 2);

            return [..defaultDelimiters, ..delimeters.ToArray()];
        }

        return defaultDelimiters;
    }

    private static string FormatInput(string input)
    {
        if (input.StartsWith("//"))
            // Could have used a range operator here but I find them less readable (especially for junior devs)
            return input.Substring(input.IndexOf("\n") + 1);

        return input;
    }
}
