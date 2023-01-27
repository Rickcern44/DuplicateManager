using StackExchange.Redis;

namespace DuplicateManagment.Services;

public interface ICacheService
{
    public string? GetValue_Test();
    public bool SetValue_Test();
    public bool CacheInputList(IEnumerable<object> list);
    public IEnumerable<object>? GetInputList();
}