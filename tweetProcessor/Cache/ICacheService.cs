using tweetProcessor.Models;

namespace tweetProcessor.Cache;

public interface ICacheService
{
    /// <summary>
    /// Get Data using key
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="keyValues"></param>
    /// <returns></returns>
    IEnumerable<Tweet> GetData(string key);

    /// <summary>
    /// Set Data with Value and Expiration Time of Key
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="keyValues"></param>
    /// <param name="value"></param>
    /// <param name="expirationTime"></param>
    /// <returns></returns>
    bool SetData<T>(string key , T value, TimeSpan expirationTime);

    /// <summary>
    /// Remove Data
    /// </summary>
    /// <param name="keyValues"></param>
    /// <returns></returns>
    object RemoveData(string key);

    public long SetTimeline(string key, Tweet tweet);
}