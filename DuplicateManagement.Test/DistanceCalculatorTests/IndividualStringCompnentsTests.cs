using DuplicateManagment.ComparisonHelpers;
using FluentAssertions;

namespace DuplicateManagement.Test.DistanceCalculatorTests;
[TestFixture]
public class IndividualStringComponentsTests
{
    [TestCase("103 Ledgestone Court", "103 Ledgestone Court")]
    [TestCase("123 maiN Street", "123 Main Street")]
    public void CompareIndividualStringComponents_ScoreShouldBeZero(string a, string b)
    {
        decimal score = DistanceCalculator.BreakoutStringCompare(a, b);
        score.Should().Be(0M);
    }
}