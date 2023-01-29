namespace DuplicateManagement.Models;

public class DuplicateScore
{
    /// <summary>
    ///     Sets the run Id to be stored for comparison later
    /// </summary>
    public Guid RunId { get; set; } = Guid.NewGuid();
    /// <summary>
    ///     Overall score assigned to the input item.
    /// </summary>
    public decimal Score { get; set; }
    /// <summary>
    ///     Individual scores and the corresponding item they derived from
    /// </summary>
    public IDictionary<string, decimal>? IndividualScores { get; set; }
    /// <summary>
    ///     The original item that was matched to the input item
    /// </summary>
    public string? DuplicateId { get; set; }
    /// <summary>
    ///     Any output notes from the matching process
    /// </summary>
    public string? Notes { get; set; } = null;

    public string ConvertToString(int duplicateId)
    {
        return Convert.ToString(duplicateId);
    }
}