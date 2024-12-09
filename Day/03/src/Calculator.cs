using System.Text.RegularExpressions;

static class Calculator
{
    private static readonly Regex MulRegex = new(@"mul\((\d{1,3}),(\d{1,3})\)");

    public static int SumOperations(IEnumerable<string> strings)
    {
        int sum = 0;

        foreach (var element in strings)
        {
            var matches = MulRegex.Matches(element);
            foreach (Match match in matches)
            {
                var firstOperand = int.Parse(match.Groups[1].Value);
                var secondOperand = int.Parse(match.Groups[2].Value);
                sum += firstOperand * secondOperand;
            }
        }

        return sum;
    }
}
