using System.Diagnostics.CodeAnalysis;

namespace DuplicateManagment.Test.TestModels;
[ExcludeFromCodeCoverage]
[Serializable]
public class Lead
{
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
    public string Name { get; set; }
    public string StreetAddress { get; set; }
    public string Zip { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
}