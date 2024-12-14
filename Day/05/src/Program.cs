using Day5.Domain;

if (args.Length != 1)
{
    Console.Error.WriteLine($"Incorrect number of arguments (expected 1, got {args.Length})");
    Console.Error.WriteLine("Usage: dotnet Day5.exe input-file");
    return 1;
}

IReadOnlyList<string> lines;

try
{
    lines = File.ReadAllLines(args[0]).AsReadOnly();
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Failed to read input file: {ex.Message}");
    return 2;
}

PuzzleInput puzzleInput = PuzzleInputParser.Parse(lines);

// DEBUG
foreach (PageOrderingRule rule in puzzleInput.Rules)
{
    Console.WriteLine($"{rule.PageBefore}|{rule.PageAfter}");
}
Console.WriteLine("");
foreach (Update update in puzzleInput.Updates)
{
    Console.WriteLine(string.Join(",", update.Pages));
}

return 0;
