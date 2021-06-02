using Microsoft.AspNetCore.Mvc.Testing;
using Session13.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Session13.ApiTest
{
    public class EndToEndTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _fixture;
        public EndToEndTests(WebApplicationFactory<Startup> fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task HelloRequest_ReturnsHello()
        {
            HttpClient client = _fixture.CreateClient();
            var response = await client.GetAsync("/hello");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal("Hello. How are you?", content);
        }
    }
}
