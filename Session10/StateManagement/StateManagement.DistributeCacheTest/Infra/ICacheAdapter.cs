using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement.DistributeCacheTest.Infra
{
    public interface ICacheAdapter
    {
        public void Set<T>(string key, T input);
        public T Get<T>(string key);
    }

    public class DistributedCache : ICacheAdapter
    {
        private readonly IDistributedCache _distributedCache;

        public DistributedCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public T Get<T>(string key)
        {
            var outputString = _distributedCache.GetString(key);
            T output = default(T);
            if (string.IsNullOrEmpty(outputString))
                output =  JsonConvert.DeserializeObject<T>(outputString);
            return output;
        }

        public void Set<T>(string key, T input)
        {
            var inputAsstring = JsonConvert.SerializeObject(input);
            _distributedCache.SetString(key, inputAsstring);
        }
    }

    public class MemoryCache : ICacheAdapter
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public void Set<T>(string key, T input)
        {
            _memoryCache.Set(key, input);
        }
    }
}
