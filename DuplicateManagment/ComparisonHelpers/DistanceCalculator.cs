using System.Diagnostics.CodeAnalysis;

namespace DuplicateManagment.ComparisonHelpers;

public static class DistanceCalculator
{
    public static decimal EntireStringCompare(string inputString, string listItemString )
    {
        decimal score = 0;
        score = GetStringDistance(inputString, listItemString);
        return score;
    }

    public static decimal BreakoutStringCompare(string inpuString, string listItemString)
    {
        decimal score = 0;
        string[] inputArray = inpuString.Split(" ");
        string[] listItemArray = listItemString.Split(" ");
        List<decimal> distanceScores = null;

        for (int i = 0; i < inputArray.Length; i++)
        {
            for (int j = 0; j < listItemArray.Length; j++)
            {
                distanceScores?.Add(EntireStringCompare(inputString: inputArray[i], listItemString: listItemArray[j]));
            }
        }

        score = distanceScores.AsQueryable().Average();
        
        return score;
    }

    public static decimal ConvertToPercentage(decimal? currentScore)
    {
        decimal result;

        if (currentScore == 0)
        {
            result = 100.00M;
        }
        else
        {
            result = 100 * (currentScore ?? decimal.Zero);
        }

        return result;
    }
    [ExcludeFromCodeCoverage]
    private static decimal GetStringDistance(string s, string t)
    {
        var bounds = new { Height = s.Length + 1, Width = t.Length + 1 };

        var matrix = new int[bounds.Height, bounds.Width];

        for (int height = 0; height < bounds.Height; height++) { matrix[height, 0] = height; };
        for (int width = 0; width < bounds.Width; width++) { matrix[0, width] = width; };

        for (int height = 1; height < bounds.Height; height++)
        {
            for (int width = 1; width < bounds.Width; width++)
            {
                int cost = (s[height - 1] == t[width - 1]) ? 0 : 1;
                int insertion = matrix[height, width - 1] + 1;
                int deletion = matrix[height - 1, width] + 1;
                int substitution = matrix[height - 1, width - 1] + cost;

                int distance = Math.Min(insertion, Math.Min(deletion, substitution));

                if (height > 1 && width > 1 && s[height - 1] == t[width - 2] && s[height - 2] == t[width - 1])
                {
                    distance = Math.Min(distance, matrix[height - 2, width - 2] + cost);
                }

                matrix[height, width] = distance;
            }
        }

        return (decimal)matrix[bounds.Height - 1, bounds.Width - 1];
    }
}