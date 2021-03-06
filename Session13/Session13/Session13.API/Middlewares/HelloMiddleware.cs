using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session13.API.Middlewares
{
    public class HelloMiddleware
    {
        private readonly RequestDelegate _next;
        public HelloMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/hello"))
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Hello. How are you?");
                return;
            }
            await _next(context);
        }
    }
}
