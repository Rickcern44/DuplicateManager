using System.Linq.Expressions;
using DuplicateManagment.Services;
using StackExchange.Redis;

namespace DuplicateManagment;

public class InitializeManager<T> where T : class
{
    private readonly ICacheService _cacheService = new RedisService();
    private readonly IEnumerable<T>? _comparisonList;
    private readonly Action<DuplicateConfiguration> _config;

    public InitializeManager(Action<DuplicateConfiguration> config, IEnumerable<T>? comparisonList = null)
    {
        _comparisonList = comparisonList;
        _config = config;
    }
}