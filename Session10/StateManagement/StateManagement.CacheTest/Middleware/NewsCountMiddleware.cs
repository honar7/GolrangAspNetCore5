using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement.CacheTest.Middleware
{
    public class NewsCountMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _memoryCache;

        public NewsCountMiddleware(RequestDelegate next,IMemoryCache memoryCache)
        {
            _next = next;
            _memoryCache = memoryCache;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var newsCount = _memoryCache.Get("NewsCount");

            if(newsCount == null)
            {
                newsCount = GetNewsCount();
                _memoryCache.Set("NewsCount", newsCount);
            }                        
            await httpContext.Response.WriteAsync($"Total news count is {newsCount}");
        }

        private int GetNewsCount()
        {
            System.Threading.Thread.Sleep(2000);
            return 10;
        }
    }
}
