global using Coordinates = (int Row, int Column);

using System.Text;

static class WordSearchReader
{
    public static IEnumerable<string> GetAllLinesFromLeftToRight(IReadOnlyList<string> lines)
    {
        for (int row = 0; row < lines.Count; row++)
        {
            yield return GetLineFromLeftToRight(lines, row);
        }
    }

    public static IEnumerable<string> GetAllLinesFromRightToLeft(IReadOnlyList<string> lines)
    {
        for (int row = 0; row < lines.Count; row++)
        {
            yield return GetLineFromRightToLeft(lines, row);
        }
    }

    public static IEnumerable<string> GetAllLinesFromTopToBottom(IReadOnlyList<string> lines)
    {
        for (int column = 0; column < lines[0].Length; column++)
        {
            yield return GetLineFromTopToBottom(lines, column);
        }
    }

    public static IEnumerable<string> GetAllLinesFromBottomToTop(IReadOnlyList<string> lines)
    {
        for (int column = 0; column < lines[0].Length; column++)
        {
            yield return GetLineFromBottomToTop(lines, column);
        }
    }

    public static IEnumerable<string> GetAllLinesFromTopLeftToBottomRight(IReadOnlyList<string> lines)
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

    public static IEnumerable<string> GetAllLinesFromBottomRightToTopLeft(IReadOnlyList<string> lines)
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

    public static IEnumerable<string> GetAllLinesFromBottomLeftToTopRight(IReadOnlyList<string> lines)
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

    public static IEnumerable<string> GetAllLinesFromTopRightToBottomLeft(IReadOnlyList<string> lines)
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

    public static string GetLineFromLeftToRight(IReadOnlyList<string> lines, int row) =>
        lines[row];

    public static string GetLineFromRightToLeft(IReadOnlyList<string> lines, int row) =>
        new(lines[row].Reverse().ToArray());

    public static string GetLineFromTopToBottom(IReadOnlyList<string> lines, int column) =>
        string.Join(null, lines.Select(l => l.ElementAt(column)));

    public static string GetLineFromBottomToTop(IReadOnlyList<string> lines, int column) =>
        string.Join(null, lines.Select(l => l.ElementAt(column)).Reverse());

    public static string GetLineFromTopLeftToBottomRight(IReadOnlyList<string> lines, Coordinates coordinates)
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

    public static string GetLineFromBottomRightToTopLeft(IReadOnlyList<string> lines, Coordinates coordinates)
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

    public static string GetLineFromBottomLeftToTopRight(IReadOnlyList<string> lines, Coordinates coordinates)
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

    public static string GetLineFromTopRightToBottomLeft(IReadOnlyList<string> lines, Coordinates coordinates)
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
