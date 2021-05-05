using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Session11.WebAPIs.Models;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;

namespace Session11.WebAPIs
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            services.AddControllers().AddNewtonsoftJson().AddXmlSerializerFormatters();
            
            services.Configure<MvcNewtonsoftJsonOptions>(opts => {
                opts.SerializerSettings.NullValueHandling
                = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.Configure<MvcOptions>(opts => {
                opts.RespectBrowserAcceptHeader = true;
                opts.ReturnHttpNotAcceptable = true;
            });


            //services.Configure<JsonOptions>(opts => {
            //    opts.SerializerOptions.DefaultIgnoreCondition.
            //    opts.SerializerOptions.ig.IgnoreNullValues = true;
            //});

            services.AddScoped<Session11DbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                //endpoints.MapGet("/my/GetName", async context =>
                // {

                // });
                endpoints.MapControllers();
                //endpoints.MapGet("/api/products", async context =>
                //{
                //    var dbcontext = context.RequestServices.GetService<Session11DbContext>();
                //    var product = dbcontext.Products.ToList();
                //    context.Response.ContentType = "application/json";
                //    var serializedProduct = JsonConvert.SerializeObject(product);
                //    context.Response.StatusCode = 200;
                //    await context.Response.WriteAsync(serializedProduct);
                //});

                //endpoints.MapGet("/api/products/{id}", async context =>
                //{
                //    var dbcontext = context.RequestServices.GetService<Session11DbContext>();
                //    var id = int.Parse(context.Request.RouteValues["id"].ToString());
                //    var product = dbcontext.Products.FirstOrDefault(c=>c.ProductId == id);
                //    context.Response.ContentType = "application/json";
                //    if (product != null)
                //    {
                //        var serializedProduct = JsonConvert.SerializeObject(product);
                //        context.Response.StatusCode = 200;
                //        await context.Response.WriteAsync(serializedProduct);
                //    }
                //    else
                //    {
                //        context.Response.StatusCode = 404;
                //        await context.Response.WriteAsync("محصول مورد نظر یافت نشد");
                //    }
                //});

                //endpoints.MapPost("/api/products", async context =>
                //{
                //    var data = context.RequestServices.GetService<Session11DbContext>();
                //    Product p = await
                //    System.Text.Json.JsonSerializer.DeserializeAsync<Product>(context.Request.Body);
                //    await data.AddAsync(p);
                //    await data.SaveChangesAsync();
                //    context.Response.StatusCode = StatusCodes.Status200OK;
                //});
            });
        }
    }
}
