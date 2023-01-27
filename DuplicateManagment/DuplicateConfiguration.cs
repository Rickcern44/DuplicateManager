namespace DuplicateManagment;

public class DuplicateConfiguration
{
    public DuplicateConfiguration(bool enabled)
    {
        Enabled = enabled;
    }
    public bool Enabled { get; set; } = true;
    
}