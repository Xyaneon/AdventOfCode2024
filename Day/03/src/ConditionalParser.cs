static class ConditionalParser
{
    private static readonly string DisableToken = "don't()";
    private static readonly string EnableToken = "do()";

    public static IEnumerable<string> ParseEnabledSections(string input)
    {
        var sections = new List<string>();

        var enabled = true;
        var tokenPosition = input.IndexOf(DisableToken);
        var lastTokenPosition = 0;

        while (tokenPosition != -1)
        {
            if (enabled)
            {
                var section = input[lastTokenPosition..tokenPosition];
                sections.Add(section);
                lastTokenPosition = tokenPosition;
                enabled = false;

                tokenPosition = input.IndexOf(EnableToken, lastTokenPosition);
            }
            else
            {
                lastTokenPosition = tokenPosition;
                enabled = true;

                tokenPosition = input.IndexOf(DisableToken, lastTokenPosition);
            }
        }

        if (enabled)
        {
            sections.Add(input[lastTokenPosition..]);
        }

        return sections;
    }
}
