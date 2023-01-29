namespace DuplicateManagement.Attributes;
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class ComparisonKeyAttribute : Attribute
{
    private readonly string _comparisonKey;
    
    public ComparisonKeyAttribute(string comparisonKey)
    {
        _comparisonKey = comparisonKey;
    }

    public string GetComparisonKey()
    {
        return _comparisonKey;
    }
}