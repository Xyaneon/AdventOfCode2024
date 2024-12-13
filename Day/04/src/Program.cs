if (args.Length != 1)
{
    Console.Error.WriteLine($"Incorrect number of arguments (expected 1, got {args.Length})");
    Console.Error.WriteLine("Usage: dotnet Day4.exe input-file");
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

int xmasCount = WordSearchReader.CountOccurrencesOfXmas(lines);

Console.WriteLine("Occurrences of XMAS found: " + xmasCount);

return 0;
