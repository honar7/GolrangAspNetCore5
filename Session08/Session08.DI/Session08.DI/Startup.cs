using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Session08.DI.Middlewares;
using Session08.DI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session08.DI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddSingleton<IPersonRepository, PersonFakeRepository>();
            services.AddSingleton<IPersonRepository, PersonEfRepository>();
            services.AddSingleton<PersonService>();
            
            services.AddTransient<TransientDependency>();
            services.AddScoped<ScopDependency>();
            services.AddSingleton<SingletonDependency>();
            services.AddTransient(typeof(IEnumerable<>),typeof( List<>));
            services.AddTransient(typeof(ILogger<>), typeof(FileLogger<>));

            services.AddSingleton<DependencyWithConstructor>(factory=> {
                if(DateTime.Now.Hour == 12)
                    return new DependencyWithConstructor(12);
                return new DependencyWithConstructor(20);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseMiddleware<TestMiddleware>();
            //app.UseMiddleware<TransientMiddleware>();

            //app.UseMiddleware<ScopeMiddleware>();
            app.UseMiddleware<SingletoneMiddleware>();

            app.UseRouting();

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
