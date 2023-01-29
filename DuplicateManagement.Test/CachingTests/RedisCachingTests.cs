using System.Diagnostics.CodeAnalysis;
using DuplicateManagement.Models;
using DuplicateManagement.Services;
using DuplicateManagement.Test.TestModels;
using FluentAssertions;

namespace DuplicateManagement.Test.CachingTests;

[ExcludeFromCodeCoverage]
public class RedisCachingTests
{
    private List<Lead> saveList = new()
    {
        new Lead(1, "Ricky", "103 Ledgestone Court", "44107" , "4405395661", "cerny.ricky@gmail.com"),
        new Lead(2, "Shelley", "1548 Alameda Dr", "44107" , "7659939578", "shelley.cerny@gmail.com"),
    };
    private readonly ICacheService _cacheService = new RedisService();
    
    [OneTimeSetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void CanCacheInputList()
    {
        var result = _cacheService.CacheInputList(saveList);
        Assert.That(result, Is.True);
    }

    [Test]
    public void CanGetCachedList()
    {
        var result = _cacheService.GetInputList()?.ToList();
        Assert.That(result?.Count > 0);
    }
    [Test]
    public void CanCacheConfigSettings()
    {
        Configuration config = new Configuration(DateTime.Now, "zip","phone");
        bool result = _cacheService.SetConfigurationSettings(config);

        result.Should().BeTrue();
    }
    [Test]
    public void CanGetConfigurationSettings()
    {
        Configuration? config = _cacheService.GetConfigurationSettings();

        config.Should().NotBeNull();
        config.ComparisonKeys.Should().Contain("zip");
    }
    
}