using System.Diagnostics.CodeAnalysis;
using DuplicateManagement.ComparisonHelpers;
using FluentAssertions;

namespace DuplicateManagement.Test.DistanceCalculatorTests;
[TestFixture]
[ExcludeFromCodeCoverage]
public class StringDistanceTests
{
    [TestCase("103 Ledgestone", "103 Ledgestone")]
    [TestCase("Hello", "Hello")]
    public void StringsAreExactMatch_ScoreShouldBeZero(string a, string b)
    {
        decimal score = DistanceCalculator.CompareFullString(a,b);
        score.Should().Be(0M);
    }

    [TestCase("Rick", "Rivk")]
    [TestCase("John", "Johnf")]
    public void StringsDoNotMatch_ScoreShouldBeOne(string a, string b)
    {
        decimal score = DistanceCalculator.CompareFullString(a, b);
        score.Should().Be(1M);
    }
}