using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FrameworklessServer;
using FrameworklessServer.Controllers;
using Xunit;

namespace FrameworklessServerTests
{
    public class ServerTests
    {
        [Fact]
        public async Task SendingAGetRequestShouldReturnCorrectStatusCode()
        {
            var router = new Router();
            var users = new UsersService();
            var controller = new Controller(users);
            var server = new Server( controller, router, users);
            _ = Task.Run(server.Start);
            
            var client = new HttpClient();
            var message = await client.GetAsync("http://localhost:8080");
            Assert.Equal(HttpStatusCode.OK, message.StatusCode);
        }
    }
}