using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Session13.API;
using Session13.API.TestInputModels;

namespace Session13.ApiTest
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(
        IWebHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureTestServices(services =>
            {
                services.RemoveAll<ICustomeService>();
                services.AddSingleton<ICustomeService, FakeService>();
            });
        }
    }
}
