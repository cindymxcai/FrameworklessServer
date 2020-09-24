using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FrameworklessServer;
using FrameworklessServer.Controllers;
using FrameworklessServer.Data.Services;
using Xunit;

namespace FrameworklessServerTests
{
    public class ServerTests
    {
        [Fact]
        public async Task SendingAGetRequestShouldReturnCorrectStatusCode()
        {
            var userService = new UserService();
            var router = new Router(userService);
            var server = new Server(router);
            _ = Task.Run(server.Start);
            
            var client = new HttpClient();
            var message = await client.GetAsync("http://localhost:8080");
            Assert.Equal(HttpStatusCode.OK, message.StatusCode);
        }
    }
}