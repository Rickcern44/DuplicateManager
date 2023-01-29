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
        RedisKey configKey = new RedisKey("Config");
        RedisValue configValue = new RedisValue(JsonConvert.SerializeObject(config));
        
        return _database.StringSet(key: configKey, value:configValue);
    }
    public Configuration? GetConfigurationSettings()
    {
        RedisKey configKey = new RedisKey("Config");

        RedisValue? configSettings = _database.StringGet(configKey);
        
        var config = JsonConvert.DeserializeObject<Configuration>(configSettings.Value);
        
        return config;
    }
}