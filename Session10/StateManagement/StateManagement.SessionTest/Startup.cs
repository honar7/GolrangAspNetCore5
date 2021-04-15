using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagement.SessionTest
{
    public static class SessionExtentions
    {
        public static T Get<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return JsonConvert.DeserializeObject<T>(key);
        }

        public static void Set<T>(this ISession session, string key, T input)
        {
            var sessionData = JsonConvert.SerializeObject(input);
            session.SetString(key, sessionData);
        }
    }
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.IsEssential = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseRouting();
            app.Use(async (context, next) =>
            {
                context.Session.SetString("DateTime", DateTime.Now.ToString());
                var result = context.Session.GetString("DateTime");
                var dtNow = DateTime.Now;
                context.Session.Set<DateTime>("MyDateTime", dtNow);
                var db = context.Session.Get<DateTime>("MyDateTime");
                await context.Session.LoadAsync();

                await context.Response.WriteAsync($"{context.Session.Id}\n");
                await next();
            });
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
