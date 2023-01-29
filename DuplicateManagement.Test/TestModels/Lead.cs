using System.Diagnostics.CodeAnalysis;
using DuplicateManagement.Attributes;

namespace DuplicateManagement.Test.TestModels;
[ExcludeFromCodeCoverage]
[Serializable]
public class Lead
{
    public Lead()
    {
    }
    public Lead(int id, string name, string streetAddress, string zip, string phoneNumber, string emailAddress)
    {
        Id = id;
        Name = name;
        StreetAddress = streetAddress;
        Zip = zip;
        PhoneNumber = phoneNumber;
        EmailAddress = emailAddress;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    [ComparisonKey(comparisonKey: "address")]
    public string? StreetAddress { get; set; }
    [ComparisonKey(comparisonKey:"zip")]
    public string? Zip { get; set; }
    [ComparisonKey(comparisonKey: "phone")]
    public string? PhoneNumber { get; set; }
    [ComparisonKey(comparisonKey: "email")]
    public string? EmailAddress { get; set; }
}