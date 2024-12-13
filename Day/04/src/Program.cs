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

// DEBUG: Output all lines in puzzle

Console.WriteLine("All lines from left to right:");
foreach (string line in WordSearchReader.GetAllLinesFromLeftToRight(lines))
{
    Console.WriteLine("\t" + line);
}

Console.WriteLine("All lines from right to left:");
foreach (string line in WordSearchReader.GetAllLinesFromRightToLeft(lines))
{
    Console.WriteLine("\t" + line);
}

Console.WriteLine("All lines from top to bottom:");
foreach (string line in WordSearchReader.GetAllLinesFromTopToBottom(lines))
{
    Console.WriteLine("\t" + line);
}

Console.WriteLine("All lines from bottom to top:");
foreach (string line in WordSearchReader.GetAllLinesFromBottomToTop(lines))
{
    Console.WriteLine("\t" + line);
}

Console.WriteLine("All lines from top-left to bottom-right:");
foreach (string line in WordSearchReader.GetAllLinesFromTopLeftToBottomRight(lines))
{
    Console.WriteLine("\t" + line);
}

Console.WriteLine("All lines from bottom-right to top-left:");
foreach (string line in WordSearchReader.GetAllLinesFromBottomRightToTopLeft(lines))
{
    Console.WriteLine("\t" + line);
}

Console.WriteLine("All lines from top-right to bottom-left:");
foreach (string line in WordSearchReader.GetAllLinesFromTopRightToBottomLeft(lines))
{
    Console.WriteLine("\t" + line);
}

Console.WriteLine("All lines from bottom-left to top-right:");
foreach (string line in WordSearchReader.GetAllLinesFromBottomLeftToTopRight(lines))
{
    Console.WriteLine("\t" + line);
}

return 0;
