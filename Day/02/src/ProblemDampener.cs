static class ProblemDampener
{
    public static IEnumerable<IReadOnlyList<int>> ProduceDampenedReports(IReadOnlyList<int> levels)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            var levelsCopy = levels.ToList();
            levelsCopy.RemoveAt(i);
            yield return levelsCopy;
        }
    }
}
