class ReportHandler
{
    public static bool IsReportSafe(IList<int> levels) =>
        (AreAllIncreasing(levels) || AreAllDecreasing(levels))
            && AllHaveDifferenceWithinTolerance(levels);

    private static bool AreAllIncreasing(IList<int> levels) {
        for (int i = 1; i < levels.Count; i++) {
            if (levels[i] <= levels[i - 1])
            {
                return false;
            }
        }

        return true;
    }
    
    private static bool AreAllDecreasing(IList<int> levels)
    {
        for (int i = 1; i < levels.Count; i++) {
            if (levels[i] >= levels[i - 1])
            {
                return false;
            }
        }

        return true;
    }

    private static bool AllHaveDifferenceWithinTolerance(IList<int> levels)
    {
        for (int i = 1; i < levels.Count; i++) {
            int difference = Math.Abs(levels[i] - levels[i - 1]);
            if (difference < 1 || difference > 3)
            {
                return false;
            }
        }

        return true;
    }
}
