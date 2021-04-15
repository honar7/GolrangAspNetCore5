using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlRouting.Middlewares;

namespace UrlRouting
{
    public class MyConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var value = values[routeKey];
            return true;
        }
    }
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(opts =>
            {
                opts.ConstraintMap.Add("mc",
                typeof(MyConstraint));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //app.UseMiddleware<CityPopulationMiddleware>();
            //app.UseMiddleware<ProvienceCenterMiddleware>();
            app.Use(async (context, next) =>
            {
                var endpoint = context.GetEndpoint();
                if(endpoint != null)
                {
                    await context.Response.WriteAsync(endpoint.DisplayName);
                }
            });
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/pc/{provience=tehran}", new ProvienceCenterMiddleware().Invoke);
                //endpoints.MapGet("/pc/{provience?}", new ProvienceCenterMiddleware().Invoke);

                //endpoints.MapGet("/cp/{city}", new CityPopulationMiddleware().Invoke).WithMetadata(new RouteNameMetadata("Pop"));
                //endpoints.MapGet("t/{first}/{seccond}", async context =>
                // {
                //     foreach (var item in context.Request.RouteValues.Keys)
                //     {
                //         await context.Response.WriteAsync($"{item}\n");
                //     }


                //     foreach (var item in context.Request.RouteValues.Values)
                //     {
                //         await context.Response.WriteAsync($"{item}\n");
                //     }
                // });

                //endpoints.MapGet("{t}/{first}/{seccond}", async context =>
                //{
                //    foreach (var item in context.Request.RouteValues.Keys)
                //    {
                //        await context.Response.WriteAsync($"{item}\n");
                //    }


                //    foreach (var item in context.Request.RouteValues.Values)
                //    {
                //        await context.Response.WriteAsync($"{item}\n");
                //    }
                //});

                //endpoints.MapGet("file/{filename}.{ext}", async context =>
                // {
                //     foreach (var item in context.Request.RouteValues.Keys)
                //     {
                //         await context.Response.WriteAsync($"{item}\n");
                //     }


                //     foreach (var item in context.Request.RouteValues.Values)
                //     {
                //         await context.Response.WriteAsync($"{item}\n");
                //     }
                // });
                //endpoints.MapGet("{first}/{seccond}/{*catchall}", async context =>
                // {
                //     foreach (var item in context.Request.RouteValues.Keys)
                //     {
                //         await context.Response.WriteAsync($"{item}\n");
                //     }


                //     foreach (var item in context.Request.RouteValues.Values)
                //     {
                //         await context.Response.WriteAsync($"{item}\n");
                //     }
                // });

                //endpoints.MapGet("{first:int}/{seccond:bool}", async context =>
                // {
                //     await context.Response.WriteAsync("NumAnd Bool\n");
                //     foreach (var item in context.Request.RouteValues.Keys)
                //     {
                //         await context.Response.WriteAsync($"{item}\n");
                //     }


                //     foreach (var item in context.Request.RouteValues.Values)
                //     {
                //         await context.Response.WriteAsync($"{item}\n");
                //     }
                // });
                //endpoints.MapGet("{first}/{seccond:length(4)}", async context =>
                //{
                //    await context.Response.WriteAsync("Len 4\n");
                //    foreach (var item in context.Request.RouteValues.Keys)
                //    {
                //        await context.Response.WriteAsync($"{item}\n");
                //    }


                //    foreach (var item in context.Request.RouteValues.Values)
                //    {
                //        await context.Response.WriteAsync($"{item}\n");
                //    }
                //});
                //endpoints.MapGet("{first}/{seccond}", async context =>
                //{
                //    await context.Response.WriteAsync("simple\n");
                //    foreach (var item in context.Request.RouteValues.Keys)
                //    {
                //        await context.Response.WriteAsync($"{item}\n");
                //    }


                //    foreach (var item in context.Request.RouteValues.Values)
                //    {
                //        await context.Response.WriteAsync($"{item}\n");
                //    }
                //});

                //endpoints.MapGet("t/{first:mc}", async context =>
                //{
                //    await context.Response.WriteAsync("My Constraint\n");
                //    foreach (var item in context.Request.RouteValues.Keys)
                //    {
                //        await context.Response.WriteAsync($"{item}\n");
                //    }


                //    foreach (var item in context.Request.RouteValues.Values)
                //    {
                //        await context.Response.WriteAsync($"{item}\n");
                //    }
                //});
                endpoints.MapGet("{first:int}", async context =>
                 {
                     await context.Response.WriteAsync("int\n");
                 }).WithDisplayName("Int Name").Add(d => ((RouteEndpointBuilder)d).Order = 1); ;
                endpoints.MapGet("{first:double}", async context =>
                {
                    await context.Response.WriteAsync("double\n");
                }).WithDisplayName("double Name").Add(d => ((RouteEndpointBuilder)d).Order = 2); ;
                endpoints.MapFallback(async context =>
                {
                    await context.Response.WriteAsync("fallback\n");
                    foreach (var item in context.Request.RouteValues.Keys)
                    {
                        await context.Response.WriteAsync($"{item}\n");
                    }


                    foreach (var item in context.Request.RouteValues.Values)
                    {
                        await context.Response.WriteAsync($"{item}\n");
                    }
                });
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware");
            });
        }
    }
}
