using DuplicateManagment;
using DuplicateManagment.Models;
using DuplicateManagment.Services;

namespace DuplicateManagement.Test;

public class Tests
{
    private List<Lead> saveList = new()
    {
        new Lead(1, "Ricky", "103 Ledgestone Court", "44107" , "4405395661", "cerny.ricky@gmail.com"),
        new Lead(2, "Shelley", "1548 Alameda Dr", "44107" , "7659939578", "shelley.cerny@gmail.com"),
    };
    private Initialize<Lead> init;
    private readonly ICacheService _cacheService = new RedisService();

    
    [OneTimeSetUp]
    public void Setup()
    {
        init = new Initialize<Lead>(saveList);
    }

    [Test]
    public void CachedListIsNotNull()
    {
        var cached = _cacheService.GetRedisCache("List");
        
        Assert.IsNotNull(cached);
    }
}