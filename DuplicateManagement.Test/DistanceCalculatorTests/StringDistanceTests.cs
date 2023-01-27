using DuplicateManagment.ComparisonHelpers;
using FluentAssertions;

namespace DuplicateManagement.Test.DistanceCalculatorTests;
[TestFixture]
public class StringDistanceTests
{
    [TestCase("103 Ledgestone", "103 Ledgestone")]
    [TestCase("Hello", "Hello")]
    public void StringsAreExactMatch_ScoreShouldBeZero(string a, string b)
    {
        decimal score = DistanceCalculator.EntireStringCompare(a,b);
        score.Should().Be(0M);
    }

    [TestCase("Rick", "Rivk")]
    [TestCase("John", "Johnf")]
    public void StringsDoNotMatch_ScoreShouldBeOne(string a, string b)
    {
        decimal score = DistanceCalculator.EntireStringCompare(a, b);
        score.Should().Be(1M);
    }
}