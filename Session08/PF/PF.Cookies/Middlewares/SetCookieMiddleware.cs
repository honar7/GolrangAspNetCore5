using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF.Cookies.Middlewares
{
    public class SetCookieMiddleware
    {
        private readonly RequestDelegate _next;

        public SetCookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            if(context.Request.Query.ContainsKey("cookies"))
            {
                var strCounter = context.Request.Cookies["counter01"];
                var intCounr = int.Parse(string.IsNullOrEmpty(strCounter) ? "0" : strCounter);
                intCounr++;
                var option01 = new CookieOptions
                {
                    IsEssential = true
                };
                context.Response.Cookies.Append("counter01", intCounr.ToString(), option01);


                var strCounter02 = context.Request.Cookies["counter02"];
                var intCounr02 = int.Parse(string.IsNullOrEmpty(strCounter02) ? "0" : strCounter02);
                intCounr02++;
                var option02 = new CookieOptions
                {
                    IsEssential = false
                };
                context.Response.Cookies.Append("counter01", intCounr.ToString(), option01);
                context.Response.Cookies.Append("counter02", intCounr02.ToString(), option02);



                await context.Response.WriteAsync($"The counter 01 value is: {intCounr}\n");
                await context.Response.WriteAsync($"The counter 02 value is: {intCounr02}\n");

            }

            if (context.Request.Query.ContainsKey("clrcookies"))
            {

                context.Response.Cookies.Delete("counter");

            }
            await _next(context);
        }
    }
}
