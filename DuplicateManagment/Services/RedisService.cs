using System.Text.Json;
using StackExchange.Redis;

namespace DuplicateManagment.Services;

public class RedisService : ICacheService
{
    private ConnectionMultiplexer? _redis;

    public RedisService()
    {
        ConnectionProperties();
    }
    
    public async Task<bool> CacheList(IEnumerable<object> cacheItem)
    {
        var db = _redis?.GetDatabase();

        RedisKey key = new RedisKey("List");
        RedisValue value = new RedisValue(GetJsonString(cacheItem));
        
        return await db.SetAddAsync(key, value);
    }
    public async Task<RedisValue?> GetRedisCache(string cacheKey)
    {
        RedisValue? cachedItems = new RedisValue(); 
        RedisKey key = new RedisKey(cacheKey);
        var db = _redis?.GetDatabase();
        if (db is not null)
        {
        }

        return cachedItems;
    }
    private void ConnectionProperties()
    {
        _redis = ConnectionMultiplexer.Connect(
            new ConfigurationOptions()
            {
                EndPoints = { "127.0.0.1:6379"},
            });
    }
    private string GetJsonString(object inputString)
    {
        return JsonSerializer.Serialize((inputString));
    }
}