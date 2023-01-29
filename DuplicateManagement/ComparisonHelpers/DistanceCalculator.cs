using System.Diagnostics.CodeAnalysis;

namespace DuplicateManagement.ComparisonHelpers;

public static class DistanceCalculator
{
    public static decimal CompareFullString(string inputString, string listItemString)
    {
        decimal score = 0;
        score = GetStringDistance(inputString, listItemString);
        return score;
    }

    public static decimal CompareIndividualStringComponents(string inpuString, string listItemString)
    {
        decimal score = 0;
        string[] inputArray = inpuString.Split(" ");
        string[] listItemArray = listItemString.Split(" ");

        var combinedArray = inputArray.Zip(listItemArray);
        
        //Compare the first and second string an add the score to list to be averaged
        var distanceScores = combinedArray.Select(item => CompareFullString(item.First, item.Second)).ToList();

        score = distanceScores.AsQueryable().Average();
        
        return Math.Round(score, 2);
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

        return matrix[bounds.Height - 1, bounds.Width - 1];
    }
}