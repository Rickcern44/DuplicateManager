using DuplicateManagment;
using DuplicateManagment.Services;
using DuplicateManagment.Test.TestModels;

namespace DuplicateManagement.Test.CachingTests;

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
    public void CanStoreHelloWorld()
    {
        var result = _cacheService.SetValue_Test();
        Assert.IsTrue(result);
    }
    [Test]
    public void CanRetrieveHelloWorld()
    {
        var result = _cacheService.GetValue_Test();
        Assert.That(result, Is.EqualTo("Hello World"));
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
    
}