using System.Collections.Immutable;

using Day5.Domain;

static class PuzzleInputParser
{
    public static PuzzleInput Parse(IReadOnlyList<string> lines)
    {
        int index = 0;
        var rules = new List<PageOrderingRule>();
        
        while (lines[index].Contains('|'))
        {
            string[] lineParts = lines[index].Split('|');
            var pageBefore = int.Parse(lineParts[0]);
            var pageAfter = int.Parse(lineParts[1]);
            
            rules.Add(new PageOrderingRule(pageBefore, pageAfter));
            
            index++;
        }

        index++;

        var updates = new List<Update>();
        for (int i = index; i < lines.Count; i++)
        {
            string[] lineParts = lines[i].Split(',');
            var pages = lineParts.Select(int.Parse).ToImmutableList();

            updates.Add(new Update(pages));
        }

        return new PuzzleInput(rules.AsReadOnly(), updates.AsReadOnly());
    }
}
