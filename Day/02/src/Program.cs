if (args.Length != 1)
{
    Console.Error.WriteLine($"Incorrect number of arguments (expected 1, got {args.Length})");
    Console.Error.WriteLine("Usage: dotnet Day2.exe input-file");
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

int safeReportCount = 0;

foreach (string line in lines)
{
    IReadOnlyList<int> levels = line
        .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .Select(int.Parse)
        .ToList()
        .AsReadOnly();

    if (ReportHandler.IsReportSafe(levels))
    {
        safeReportCount++;
    }
}

Console.WriteLine("Safe reports: " + safeReportCount);

return 0;
