using StackExchange.Redis;

namespace DuplicateManagment.Services;

public interface ICacheService
{
    Task<bool> CacheList(IEnumerable<object> cacheItem);
    Task<RedisValue?> GetRedisCache(string cacheKey);
}