using System.Text.RegularExpressions;

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

var mulRegex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");

int sum = 0;

foreach (var line in lines)
{
    var matches = mulRegex.Matches(line);
    foreach (Match match in matches)
    {
        var firstOperand = int.Parse(match.Groups[1].Value);
        var secondOperand = int.Parse(match.Groups[2].Value);
        sum += firstOperand * secondOperand;
    }
}

Console.WriteLine($"Sum of multiplications: {sum}");

var sumEnabledSections = 0;

var singleLine = string.Join("", lines).Trim();
IEnumerable<string> enabledSections = ConditionalParser.ParseEnabledSections(singleLine);

foreach (var section in enabledSections)
{
    var matches = mulRegex.Matches(section);
    foreach (Match match in matches)
    {
        var firstOperand = int.Parse(match.Groups[1].Value);
        var secondOperand = int.Parse(match.Groups[2].Value);
        sumEnabledSections += firstOperand * secondOperand;
    }
}

Console.WriteLine($"Sum of multiplications (enabled sections only): {sumEnabledSections}");

return 0;
