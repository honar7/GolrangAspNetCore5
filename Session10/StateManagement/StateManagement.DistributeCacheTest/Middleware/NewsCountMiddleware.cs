using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using StateManagement.DistributeCacheTest.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement.DistributeCacheTest.Middleware
{
    //public class NewsCountMiddleware
    //{
    //    private readonly RequestDelegate _next;
    //    private readonly IDistributedCache _distributedCache;

    //    public NewsCountMiddleware(RequestDelegate next, IDistributedCache distributedCache)
    //    {
    //        _next = next;
    //        _distributedCache = distributedCache;

    //    }

    //    public async Task Invoke(HttpContext httpContext)
    //    {
    //        var newCount = _distributedCache.GetString("NewsCount");


    //        if (string.IsNullOrEmpty(newCount))
    //        {
    //            newCount = GetNewsCount().ToString();
    //            _distributedCache.SetString("NewsCount", newCount);
    //        }
    //        await httpContext.Response.WriteAsync($"Total news count is {newCount}");
    //    }

    //    private int GetNewsCount()
    //    {
    //        System.Threading.Thread.Sleep(2000);
    //        return 10;
    //    }
    //}

    public class NewsCountMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ICacheAdapter _cacheAdapter;

        public NewsCountMiddleware(RequestDelegate next, ICacheAdapter cacheAdapter )
        {
            _next = next;
            _cacheAdapter = cacheAdapter;

        }

        public async Task Invoke(HttpContext httpContext)
        {
            var newCount = _cacheAdapter.Get<string>("NewsCount");


            if (string.IsNullOrEmpty(newCount))
            {
                newCount = GetNewsCount().ToString();
                _cacheAdapter.Set("NewsCount", newCount);
            }
            await httpContext.Response.WriteAsync($"Total news count is {newCount}");
        }

        private int GetNewsCount()
        {
            System.Threading.Thread.Sleep(2000);
            return 10;
        }
    }
}
