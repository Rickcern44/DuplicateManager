using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Metadata;
using DuplicateManagement.Attributes;
using DuplicateManagement.Test.TestModels;
using FluentAssertions;

namespace DuplicateManagement.Test.AttributeTests;
[TestFixture]
[ExcludeFromCodeCoverage]
public class ComparisonAttributeTests
{
    [Test]
    public void GetComparisonKey_ShouldBeZip()
    {
        var type = typeof(Lead);

        var properties = type.GetProperties()
            .Select(x => x.GetCustomAttribute<ComparisonKeyAttribute>()?.GetComparisonKey());

        properties.Should().HaveCount(4);
   }
}