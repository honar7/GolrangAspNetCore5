using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VsBeginingAsp
{
    public class MyMiddleware
    {
        private readonly RequestDelegate next;

        public MyMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Query.ContainsKey("b"))
            {
                await context.Response.WriteAsync("MyMiddleware works\n");
            }
            await next(context);
        }
    }
}
