using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StateManagement.DistributeCacheTest.Infra;
using StateManagement.DistributeCacheTest.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement.DistributeCacheTest
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            bool useDistibutedCache = true;
            if(useDistibutedCache)
            {
                services.AddDistributedSqlServerCache(options =>
                {
                    options.ConnectionString = "Server=.;Database=CacheDb; User Id=sa; Password=1qaz!QAZ";
                    options.TableName = "tblCache";
                    options.SchemaName = "dbo";
                });
                services.AddScoped<ICacheAdapter, DistributedCache>();
            }
            else
            {
                services.AddMemoryCache();
                services.AddScoped<ICacheAdapter, MemoryCache>();
            }
            //services.AddDistributedMemoryCache();
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMiddleware<NewsCountMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
