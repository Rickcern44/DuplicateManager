using DuplicateManagement.Models;
using StackExchange.Redis;

namespace DuplicateManagement.Services;

public interface ICacheService
{
    public string? GetValue_Test();
    public bool SetValue_Test();
    public bool CacheInputList(IEnumerable<object> list);
    public IEnumerable<object>? GetInputList();
    public Configuration? GetConfigurationSettings();
    public bool SetConfigurationSettings(Configuration config);
}