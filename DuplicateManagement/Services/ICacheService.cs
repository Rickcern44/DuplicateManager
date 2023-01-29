using DuplicateManagement.Models;

namespace DuplicateManagement.Services;

public interface ICacheService
{
    /// <summary>
    ///     Cache the given input list to be stored for comparison
    /// </summary>
    /// <param name="list"></param>
    /// <returns>Boolean result of the caching operation</returns>
    public bool CacheInputList(IEnumerable<object> list);
    /// <summary>
    ///     Retrieves the previously cached list
    /// </summary>
    /// <returns>Enumerable of the input type to be compared</returns>
    public IEnumerable<object>? GetInputList();
    /// <summary>
    ///     Gets the configuration settings that have been cached to the server.
    /// </summary>
    /// <returns></returns>
    public Configuration? GetConfigurationSettings();
    /// <summary>
    ///     Sets the configuration settings on the redis server
    /// </summary>
    /// <param name="config"></param>
    /// <returns></returns>
    public bool SetConfigurationSettings(Configuration config);
}