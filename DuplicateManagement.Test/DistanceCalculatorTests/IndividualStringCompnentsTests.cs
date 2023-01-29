using System.Diagnostics.CodeAnalysis;
using DuplicateManagement.ComparisonHelpers;
using FluentAssertions;

namespace DuplicateManagement.Test.DistanceCalculatorTests;
[TestFixture]
[ExcludeFromCodeCoverage]
public class IndividualStringComponentsTests
{
    [TestCase("103 Ledgestone Court", "103 Ledgestone Court")]
    [TestCase("123 Main Street", "123 Main Street")]
    public void CompareIndividualStringComponents_ScoreShouldBeZero(string a, string b)
    {
        decimal score = DistanceCalculator.CompareIndividualStringComponents(a, b);
        score.Should().Be(0M);
    }

    [TestCase("103 Ledgestone Court", "103 Ledgestone")]
    public void CompareIndividualComponents_OneHasAdditionalStrings(string a, string b)
    {
        decimal score = DistanceCalculator.CompareIndividualStringComponents(a, b);
        score.Should().Be(0M);
    }
    [TestCase("103 Ledgestone Court", "103 Ledgewstome Court")]
    [TestCase("103 Ledgestone Court", "104 Ledgesstone Court")]
    public void CompareIndividualComponents_ScoreShouldBePointSixSeven(string a, string b)
    {
        decimal score = DistanceCalculator.CompareIndividualStringComponents(a, b);
        score.Should().Be(.67M);
    }
    [TestCase("103 Ledgestone Court", "104 Ledgston Cournt")]
    [TestCase("103 Ledgestone Court", "104 Ledgestone Ct")]
    public void CompareIndividualComponents_ScoreShouldBeOnePointThreeThree(string a, string b)
    {
        decimal score = DistanceCalculator.CompareIndividualStringComponents(a, b);
        score.Should().Be(1.33M);
    }
    [TestCase("103 Ledgestone Court", "122 Ledgstonre Courntt")]
    [TestCase("103 Ledgestone Court", "111 Ledgeestore Courte3")]
    public void CompareIndividualComponents_ScoreShouldBeTwo(string a, string b)
    {
        decimal score = DistanceCalculator.CompareIndividualStringComponents(a, b);
        score.Should().Be(2M);
    }
}