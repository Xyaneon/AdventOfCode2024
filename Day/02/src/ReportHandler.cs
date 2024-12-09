using System.Collections.Immutable;

static class ReportHandler
{
    public static bool IsReportSafe(IReadOnlyList<int> levels)
    {
        if (IsReportSafeBase(levels))
        {
            return true;
        }

        IEnumerable<IReadOnlyList<int>> dampenedReports = ProblemDampener
            .ProduceDampenedReports(levels)
            .ToImmutableList();

        return dampenedReports.Any(IsReportSafeBase);
    }

    private static bool IsReportSafeBase(IReadOnlyList<int> levels) =>
        (AreAllIncreasing(levels) || AreAllDecreasing(levels))
            && AllHaveDifferenceWithinTolerance(levels);

    private static bool AreAllIncreasing(IReadOnlyList<int> levels)
    {
        for (int i = 1; i < levels.Count; i++)
        {
            if (levels[i] <= levels[i - 1])
            {
                return false;
            }
        }

        return true;
    }

    private static bool AreAllDecreasing(IReadOnlyList<int> levels)
    {
        for (int i = 1; i < levels.Count; i++)
        {
            if (levels[i] >= levels[i - 1])
            {
                return false;
            }
        }

        return true;
    }

    private static bool AllHaveDifferenceWithinTolerance(IReadOnlyList<int> levels)
    {
        for (int i = 1; i < levels.Count; i++)
        {
            int difference = Math.Abs(levels[i] - levels[i - 1]);
            if (difference < 1 || difference > 3)
            {
                return false;
            }
        }

        return true;
    }
}
