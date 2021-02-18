using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace VsBeginingAsp
{
    public interface IStartup
    {
        void Configuer(IApplicationBuilder app, IWebHostEnvironment env);
        void ConfigureServices(IServiceCollection services);
    }
}