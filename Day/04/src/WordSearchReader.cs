global using Coordinates = (int Row, int Column);

using System.Text;

static class WordSearchReader
{
    public static int CountOccurrencesOfXmas(IReadOnlyList<string> lines) =>
        GetAllLinesInEveryDirection(lines)
            .Select(CountOccurrencesOfXmas)
            .Sum();

    public static int CountOccurrencesOfMasCross(IReadOnlyList<string> lines)
    {
        var lastRowIndex = lines.Count - 1;
        var lastColumnIndex = lines[0].Length - 1;

        var count = 0;
        for (int row = 0; row <= lastRowIndex; row++)
        {
            for (int column = 0; column <= lastColumnIndex; column++)
            {
                if (IsXMasCenteredAtPosition(lines, (row, column)))
                {
                    count++;
                }
            }
        }

        return count;
    }

    private static bool IsXMasCenteredAtPosition(IReadOnlyList<string> lines, Coordinates coordinates)
    {
        int lastRowIndex = lines.Count - 1;
        int lastColumnIndex = lines[0].Length - 1;

        (int row, int column) = coordinates;

        if (row == 0
            || row == lastRowIndex
            || column == 0
            || column == lastColumnIndex)
        {
            return false;
        }

        if (GetCharAtPosition(lines, row, column) != 'A')
        {
            return false;
        }

        bool isMasFromTopLeftToBottomRight =
            GetCharAtPosition(lines, row - 1, column - 1) == 'M' && GetCharAtPosition(lines, row + 1, column + 1) == 'S'
            || GetCharAtPosition(lines, row - 1, column - 1) == 'S' && GetCharAtPosition(lines, row + 1, column + 1) == 'M';

        bool isMasFromTopRightToBottomLeft =
            GetCharAtPosition(lines, row - 1, column + 1) == 'M' && GetCharAtPosition(lines, row + 1, column - 1) == 'S'
            || GetCharAtPosition(lines, row - 1, column + 1) == 'S' && GetCharAtPosition(lines, row + 1, column - 1) == 'M';

        return isMasFromTopLeftToBottomRight && isMasFromTopRightToBottomLeft;
    }

    private static char GetCharAtPosition(IReadOnlyList<string> lines, int row, int column) =>
        lines[row].ElementAt(column);

    private static int CountOccurrencesOfXmas(string line)
    {
        int count = 0;
        int startIndex = 0;
        int foundIndex = line.IndexOf("XMAS", startIndex);

        while (foundIndex != -1)
        {
            count++;
            startIndex = foundIndex + 1;
            foundIndex = line.IndexOf("XMAS", startIndex);
        }

        return count;
    }

    private static IEnumerable<string> GetAllLinesInEveryDirection(IReadOnlyList<string> lines) =>
        GetAllLinesFromLeftToRight(lines)
            .Concat(GetAllLinesFromRightToLeft(lines))
            .Concat(GetAllLinesFromTopToBottom(lines))
            .Concat(GetAllLinesFromBottomToTop(lines))
            .Concat(GetAllLinesFromTopLeftToBottomRight(lines))
            .Concat(GetAllLinesFromBottomRightToTopLeft(lines))
            .Concat(GetAllLinesFromTopRightToBottomLeft(lines))
            .Concat(GetAllLinesFromBottomLeftToTopRight(lines));

    private static IEnumerable<string> GetAllLinesFromLeftToRight(IReadOnlyList<string> lines)
    {
        for (int row = 0; row < lines.Count; row++)
        {
            yield return GetLineFromLeftToRight(lines, row);
        }
    }

    private static IEnumerable<string> GetAllLinesFromRightToLeft(IReadOnlyList<string> lines)
    {
        for (int row = 0; row < lines.Count; row++)
        {
            yield return GetLineFromRightToLeft(lines, row);
        }
    }

    private static IEnumerable<string> GetAllLinesFromTopToBottom(IReadOnlyList<string> lines)
    {
        for (int column = 0; column < lines[0].Length; column++)
        {
            yield return GetLineFromTopToBottom(lines, column);
        }
    }

    private static IEnumerable<string> GetAllLinesFromBottomToTop(IReadOnlyList<string> lines)
    {
        for (int column = 0; column < lines[0].Length; column++)
        {
            yield return GetLineFromBottomToTop(lines, column);
        }
    }

    private static IEnumerable<string> GetAllLinesFromTopLeftToBottomRight(IReadOnlyList<string> lines)
    {
        int lastRowIndex = lines.Count - 1;
        int lastColumnIndex = lines[0].Length - 1;

        // Starting from left edge, going up
        for (int row = lastRowIndex; row >= 0; row--)
        {
            yield return GetLineFromTopLeftToBottomRight(lines, (row, 0));
        }

        // Starting from top edge, going right
        for (int column = 1; column <= lastColumnIndex; column++)
        {
            yield return GetLineFromTopLeftToBottomRight(lines, (0, column));
        }
    }

    private static IEnumerable<string> GetAllLinesFromBottomRightToTopLeft(IReadOnlyList<string> lines)
    {
        int lastRowIndex = lines.Count - 1;
        int lastColumnIndex = lines[0].Length - 1;

        // Starting from bottom edge, going right
        for (int column = 0; column <= lastColumnIndex; column++)
        {
            yield return GetLineFromBottomRightToTopLeft(lines, (lastRowIndex, column));
        }

        // Starting from right edge, going up
        for (int row = lastRowIndex - 1; row >= 0; row--)
        {
            yield return GetLineFromBottomRightToTopLeft(lines, (row, lastColumnIndex));
        }
    }

    private static IEnumerable<string> GetAllLinesFromBottomLeftToTopRight(IReadOnlyList<string> lines)
    {
        int lastRowIndex = lines.Count - 1;
        int lastColumnIndex = lines[0].Length - 1;

        // Starting from left edge, going down
        for (int row = 0; row <= lastRowIndex; row++)
        {
            yield return GetLineFromBottomLeftToTopRight(lines, (row, 0));
        }

        // Starting from bottom edge, going right
        for (int column = 1; column <= lastColumnIndex; column++)
        {
            yield return GetLineFromBottomLeftToTopRight(lines, (lastRowIndex, column));
        }
    }

    private static IEnumerable<string> GetAllLinesFromTopRightToBottomLeft(IReadOnlyList<string> lines)
    {
        int lastRowIndex = lines.Count - 1;
        int lastColumnIndex = lines[0].Length - 1;

        // Starting from top edge, going right
        for (int column = 0; column <= lastColumnIndex; column++)
        {
            yield return GetLineFromTopRightToBottomLeft(lines, (0, column));
        }

        // Starting from right edge, going down
        for (int row = 1; row <= lastRowIndex; row++)
        {
            yield return GetLineFromTopRightToBottomLeft(lines, (row, lastColumnIndex));
        }
    }

    private static string GetLineFromLeftToRight(IReadOnlyList<string> lines, int row) =>
        lines[row];

    private static string GetLineFromRightToLeft(IReadOnlyList<string> lines, int row) =>
        new(lines[row].Reverse().ToArray());

    private static string GetLineFromTopToBottom(IReadOnlyList<string> lines, int column) =>
        string.Join(null, lines.Select(l => l.ElementAt(column)));

    private static string GetLineFromBottomToTop(IReadOnlyList<string> lines, int column) =>
        string.Join(null, lines.Select(l => l.ElementAt(column)).Reverse());

    private static string GetLineFromTopLeftToBottomRight(IReadOnlyList<string> lines, Coordinates coordinates)
    {
        int lastRowIndex = lines.Count - 1;
        int lastColumnIndex = lines[0].Length - 1;

        if (coordinates.Row != 0 && coordinates.Column != 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(coordinates),
                "The provided coordinates are not along the top or left edge of the word search."
                );
        }

        int currentRow = coordinates.Row;
        int currentColumn = coordinates.Column;
        var stringBuilder = new StringBuilder();

        while (currentRow <= lastRowIndex && currentColumn <= lastColumnIndex)
        {
            stringBuilder.Append(lines[currentRow].ElementAt(currentColumn));
            currentRow++;
            currentColumn++;
        }

        return stringBuilder.ToString();
    }

    private static string GetLineFromBottomRightToTopLeft(IReadOnlyList<string> lines, Coordinates coordinates)
    {
        int lastRowIndex = lines.Count - 1;
        int lastColumnIndex = lines[0].Length - 1;
        if (coordinates.Row != lastRowIndex && coordinates.Column != lastColumnIndex)
        {
            throw new ArgumentOutOfRangeException(
                nameof(coordinates),
                "The provided coordinates are not along the bottom or right edge of the word search."
                );
        }

        int currentRow = coordinates.Row;
        int currentColumn = coordinates.Column;
        var stringBuilder = new StringBuilder();

        while (currentRow >= 0 && currentColumn >= 0)
        {
            stringBuilder.Append(lines[currentRow].ElementAt(currentColumn));
            currentRow--;
            currentColumn--;
        }

        return stringBuilder.ToString();
    }

    private static string GetLineFromBottomLeftToTopRight(IReadOnlyList<string> lines, Coordinates coordinates)
    {
        int lastRowIndex = lines.Count - 1;
        int lastColumnIndex = lines[0].Length - 1;
        if (coordinates.Row != lastRowIndex && coordinates.Column != 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(coordinates),
                "The provided coordinates are not along the bottom or left edge of the word search."
                );
        }

        int currentRow = coordinates.Row;
        int currentColumn = coordinates.Column;
        var stringBuilder = new StringBuilder();

        while (currentRow >= 0 && currentColumn <= lastColumnIndex)
        {
            stringBuilder.Append(lines[currentRow].ElementAt(currentColumn));
            currentRow--;
            currentColumn++;
        }

        return stringBuilder.ToString();
    }

    private static string GetLineFromTopRightToBottomLeft(IReadOnlyList<string> lines, Coordinates coordinates)
    {
        int lastRowIndex = lines.Count - 1;
        int lastColumnIndex = lines[0].Length - 1;
        if (coordinates.Row != 0 && coordinates.Column != lastColumnIndex)
        {
            throw new ArgumentOutOfRangeException(
                nameof(coordinates),
                "The provided coordinates are not along the top or right edge of the word search."
                );
        }

        int currentRow = coordinates.Row;
        int currentColumn = coordinates.Column;
        var stringBuilder = new StringBuilder();

        while (currentRow <= lastRowIndex && currentColumn >= 0)
        {
            stringBuilder.Append(lines[currentRow].ElementAt(currentColumn));
            currentRow++;
            currentColumn--;
        }

        return stringBuilder.ToString();
    }
}
