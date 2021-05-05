using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;

namespace UrlRouting.Middlewares
{
    public class ProvienceCenterMiddleware
    {
        private readonly RequestDelegate _next;
        public ProvienceCenterMiddleware()
        {

        }
        public ProvienceCenterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //var path = httpContext.Request.Path.ToString().Split("/", StringSplitOptions.RemoveEmptyEntries);
            string centerName = "";
            //if (path != null && path.Length == 2 && path[0] == "pc")
            //{
                var provience = httpContext.Request.RouteValues["provience"] ?? "tehran";

                switch (provience)
                {
                    case "tehran":
                        centerName = "tehran";
                        break;
                    case "mhorasan":
                        centerName = "mashhad";
                        break;
                    case "gilan":
                        centerName = "rasht";
                        break;
                    case "rasht":
                    //httpContext.Response.Redirect($"/cp/{provience}");
                    var linkGenerator = httpContext.RequestServices.GetService<LinkGenerator>();
                    var path = linkGenerator.GetPathByRouteValues(httpContext, "Pop", new { city = provience });
                    httpContext.Response.Redirect(path);
                    break;
                }
           // }
            if (string.IsNullOrEmpty(centerName) && _next != null)
                await _next(httpContext);
            else
                await httpContext.Response.WriteAsync($"Capital of {provience} is {centerName}");
        }
    }
}
