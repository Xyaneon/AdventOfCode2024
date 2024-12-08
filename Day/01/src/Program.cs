if (args.Length != 1)
{
    Console.Error.WriteLine($"Incorrect number of arguments (expected 1, got {args.Length})");
    Console.Error.WriteLine("Usage: dotnet Day1.exe input-file");
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

List<int> leftList = [];
List<int> rightList = [];

foreach (string line in lines) {
    string[] inputParts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    leftList.Add(int.Parse(inputParts[0]));
    rightList.Add(int.Parse(inputParts[1]));
}

leftList.Sort();
rightList.Sort();

List<int> differences = [];

for (int i = 0; i < leftList.Count; i++) {
    differences.Add(Math.Abs(leftList[i] - rightList[i]));
}

Console.WriteLine($"{differences.Sum()}");

return 0;
