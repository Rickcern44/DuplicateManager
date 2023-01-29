using DuplicateManagement.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace DuplicateManagement.Services;

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
        return _database.StringSet("LeadList", JsonConvert.SerializeObject(list));
    }

    public IEnumerable<object>? GetInputList()
    {
        var leads = _database.StringGet("LeadList");
        var deserializeLeads = JsonConvert.DeserializeObject<List<object>>(leads);

        return deserializeLeads;
    }
    public bool SetConfigurationSettings(Configuration config)
    {
        return _database.StringSet(key: "Config", value:JsonConvert.SerializeObject(config));
    }
    public Configuration? GetConfigurationSettings()
    {
        var configSettings = _database.StringGet("Config ");
        Configuration? config = null;

        if (configSettings.HasValue)
        {
            config = JsonConvert.DeserializeObject<Configuration>(configSettings);
        }

        return config;
    }
}