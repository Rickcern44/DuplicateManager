using Newtonsoft.Json;
using StackExchange.Redis;

namespace DuplicateManagment.Services;

public class RedisService : ICacheService
{
    private readonly ConnectionMultiplexer? _redis = ConnectionMultiplexer.Connect("192.168.1.79:6379");
    private readonly IDatabase _database;

    public RedisService()
    {
        _database = _redis.GetDatabase();
    }

    public string? GetValue_Test()
    {
        return _database.StringGet("TestKey");
    }

    public bool SetValue_Test()
    {
        return _database.StringSet("TestKey", "Hello World");
    }

    public bool CacheInputList(IEnumerable<object> list)
    {
        return _database.StringSet("LeadList",JsonConvert.SerializeObject(list));
    }

    public IEnumerable<object>? GetInputList()
    {
        var leads =  _database.StringGet("LeadList");
        var deserializeLeads = JsonConvert.DeserializeObject<List<object>>(leads);

        return deserializeLeads;
    }
}