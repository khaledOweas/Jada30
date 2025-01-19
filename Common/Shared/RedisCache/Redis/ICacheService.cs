using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis
{
    public interface ICacheService
    {
        Task<string> GetCacheValueAsync(string key);
        Task SetCacheValueAsync(string key, string value);
        Task<T> GetObject<T>(string key) where T : class;
        Task SetObject<T>(string key, T value) where T : class;
        Task DeleteKeyAsync(string key);
        T GetObjectWithoutAsync<T>(string key) where T : class;
        Task KeyDeleteAsync<T>(string key) where T : class;
        Task SetObjectDuration(string key, string value, int duration);

        //  Task SetObjectDuration<T>(string key, T value, int duration) where T : class;
    }
}
