using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace BookMonkey.Tests
{
    public class AuthenticationIntegrationTest
    {
        [Fact]
        public async Task Attempt_succesful_login_and_access_protected_action()
        {
            var host = new WebHostBuilder().UseContentRoot(Directory.GetCurrentDirectory()).UseStartup<Startup>();
            var testServer = new TestServer(host);
            var client = testServer.CreateClient();

            var stringContent = new StringContent("{ Username: 'Test', Password: 'Test' }");
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var loginResult = await client.PostAsync("api/login/signin", stringContent);
            Assert.Equal(HttpStatusCode.OK, loginResult.StatusCode);

            var cookies = loginResult.Headers.GetValues("Set-Cookie");
            client.DefaultRequestHeaders.Add("Cookie", cookies);
            var accessProtectedActionResult = await client.GetAsync("api/books");
            Assert.Equal(HttpStatusCode.OK, accessProtectedActionResult.StatusCode);
        }
    }
}