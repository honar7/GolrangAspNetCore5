using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Session08.DI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session08.DI.Middlewares
{
    public class TransientMiddleware
    {
        private readonly RequestDelegate _next;

        public TransientMiddleware(RequestDelegate next)
        {
            _next = next;


        }
        public async Task Invoke(HttpContext httpContext, TransientDependency transientDependency01, TransientDependency transientDependency02)
        {
            await httpContext.Response.WriteAsync($"{transientDependency01.guid}\n");
            await httpContext.Response.WriteAsync($"{transientDependency02.guid}\n");
            await _next(httpContext);
        }
    }


    public class ScopeMiddleware
    {
        private readonly RequestDelegate _next;

        public ScopeMiddleware(RequestDelegate next)
        {
            _next = next;


        }
        public async Task Invoke(HttpContext httpContext, ScopDependency scopDependency01, ScopDependency scopDependency02)
        {
            await httpContext.Response.WriteAsync($"{scopDependency01.guid}\n");
            await httpContext.Response.WriteAsync($"{scopDependency02.guid}\n");
            await _next(httpContext);
        }
    }

    public class SingletoneMiddleware
    {
        private readonly RequestDelegate _next;

        public SingletoneMiddleware(RequestDelegate next)
        {
            _next = next;


        }
        public async Task Invoke(HttpContext httpContext, SingletonDependency singletonDependency01, SingletonDependency singletonDependency02)
        {
            await httpContext.Response.WriteAsync($"{singletonDependency01.guid}\n");
            await httpContext.Response.WriteAsync($"{singletonDependency02.guid}\n");
            await _next(httpContext);
        }
    }


    public class ServiceLocatorMiddleware
    {
        private readonly RequestDelegate _next;

        public ServiceLocatorMiddleware(RequestDelegate next)
        {
            _next = next;


        }
        public async Task Invoke(HttpContext httpContext,IEnumerable<int> i,IEnumerable<string> s)
        {
            var sd = httpContext.RequestServices.GetService(typeof(SingletonDependency));
            //await httpContext.Response.WriteAsync($"{singletonDependency01.guid}\n");
            //await httpContext.Response.WriteAsync($"{singletonDependency02.guid}\n");
            await _next(httpContext);
        }
    }
}
