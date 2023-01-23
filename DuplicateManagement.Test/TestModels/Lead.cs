namespace DuplicateManagment.Models;

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

    private int Id { get; set; }
    private string Name { get; set; }
    private string StreetAddress { get; set; }
    private string Zip { get; set; }
    private string PhoneNumber { get; set; }
    private string EmailAddress { get; set; }
}