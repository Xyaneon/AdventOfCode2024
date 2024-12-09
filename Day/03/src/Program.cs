if (args.Length != 1)
{
    Console.Error.WriteLine($"Incorrect number of arguments (expected 1, got {args.Length})");
    Console.Error.WriteLine("Usage: dotnet Day3.exe input-file");
    return 1;
}

string[] lines;

try
{
    lines = File.ReadAllLines(args[0]);
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Failed to read input file: {ex.Message}");
    return 2;
}

int sum = Calculator.SumOperations(lines);

Console.WriteLine($"Sum of multiplications: {sum}");

var singleLine = string.Join("", lines).Trim();
IEnumerable<string> enabledSections = ConditionalParser.ParseEnabledSections(singleLine);

var sumEnabledSections = Calculator.SumOperations(enabledSections);

Console.WriteLine($"Sum of multiplications (enabled sections only): {sumEnabledSections}");

return 0;
