using DuplicateManagment.Services;

namespace DuplicateManagment;

public class Initialize<T> where T : class
{
    private readonly ICacheService _cacheService = new RedisService();
    public Initialize(IEnumerable<T> comparisonList)
    {
        var cached =_cacheService.GetRedisCache("List");
        if (cached.Result is null)
        {
            _cacheService.CacheList(comparisonList);
        }
    }
}