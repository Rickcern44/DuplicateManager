namespace DuplicateManagement.Models;

[Serializable]
public class Configuration
{
    public Configuration(DateTime dateCached, params string[] comparisonKeys)
    {
        ComparisonKeys = comparisonKeys;
        DateCached = dateCached;
    }
    
    /// <summary>
    ///     Keys that will be used to decide which properties will be compared against
    /// </summary>
    public string[] ComparisonKeys { get; set; }
    /// <summary>
    ///     Output the result with a Duplicate Score model, default to true.
    /// </summary>
    public bool OutputResults { get; set; } = true;
    /// <summary>
    ///     Enable the comparison tool, easy way to switch on and off if issues are found.
    /// </summary>
    public bool Enabled { get; set; } = true;
    /// <summary>
    ///     Date to verify the last time the config settings were cached or updated.
    /// </summary>
    public DateTime DateCached { get; set; }
    /// <summary>
    ///     Merge the input item with the matched duplicate/duplicates
    /// </summary>
    public bool PerformMerge { get; set; } = false;
}