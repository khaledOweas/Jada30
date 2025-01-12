using Jada30.Logging.Filter;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Framework.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly ILogger<ExceptionLogFilter> _logger;
        public CacheService(IConnectionMultiplexer connectionMultiplexer, ILogger<ExceptionLogFilter> logger)
        {

            _connectionMultiplexer = connectionMultiplexer;
            _logger = logger;
        }

        public async Task<string> GetCacheValueAsync(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return await db.StringGetAsync(key);
        }

        public async Task SetCacheValueAsync(string key, string value)
        {
            var db = _connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(key, value, expiry: new TimeSpan(24, 0, 0));
        }

        public async Task SetObject<T>(string key, T value) where T : class
        {
            var db = _connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(GenerateCompositeKey(typeof(T).Name, Key: key), JsonConvert.SerializeObject(value), expiry: new TimeSpan(24, 0, 0));
        }
        public async Task SetObjectDuration(string key, string value, int duration)
        {
            var db = _connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(key, value, expiry: new TimeSpan(duration, 45, 0));
        }

        public async Task<T> GetObject<T>(string key) where T : class
        {
            try
            {
                var db = _connectionMultiplexer.GetDatabase();
                var value = await db.StringGetAsync(GenerateCompositeKey(typeof(T).Name, Key: key));

                if (string.IsNullOrEmpty(value))
                    return null;

                return JsonConvert.DeserializeObject<T>(value);
            }
            catch (Exception ex)
            {
                _logger.LogError("cacheError: \n{0}", ex.GetBaseException().Message);
                return null;
            }

        }
        private string GenerateCompositeKey(string type, string Key)
        {
            string compositekey = String.Join("_", new string[] { type, Key });
            return compositekey;
        }
        public async Task DeleteKeyAsync(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();

            await db.KeyDeleteAsync(key);
        }

        public async Task KeyDeleteAsync<T>(string key) where T : class
        {
            var db = _connectionMultiplexer.GetDatabase();
            var value = await db.KeyDeleteAsync(GenerateCompositeKey(typeof(T).Name, Key: key));
        }

        public T GetObjectWithoutAsync<T>(string key) where T : class
        {
            var db = _connectionMultiplexer.GetDatabase();
            var value = db.StringGet(GenerateCompositeKey(typeof(T).Name, Key: key));

            if (string.IsNullOrEmpty(value))
                return null;

            return JsonConvert.DeserializeObject<T>(value);
        }

        //public Task SetObjectDuration<T>(string key, T value, int duration) where T : class
        //{
        //    throw new NotImplementedException();
        //}
    }
}
