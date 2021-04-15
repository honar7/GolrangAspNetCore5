using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace UrlRouting.Middlewares
{
    public class CityPopulationMiddleware
    {
        private readonly RequestDelegate _next;

        public CityPopulationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public CityPopulationMiddleware()
        {

        }
        public async Task Invoke(HttpContext httpContext)
        {

            //var path = httpContext.Request.Path.ToString().Split("/", StringSplitOptions.RemoveEmptyEntries);
            int population = 0;
            //if (path != null && path.Length == 2 && path[0] == "citypopulation")
            //{
                var city = httpContext.Request.RouteValues["city"];
                switch (city)
                {
                    case "tehran":
                        population = 10_000_000;
                        break;
                    case "mashhad":
                        population = 5_000_000;
                        break;
                    case "rasht":
                        population = 2_000_000;
                        break;
                }
            //}
            if (population == 0 && _next != null)
                await _next(httpContext);
            else
                await httpContext.Response.WriteAsync($"Population of {city} is {population}");
        }
    }
}
