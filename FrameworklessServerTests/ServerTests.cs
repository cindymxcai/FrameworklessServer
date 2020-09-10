using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FrameworklessServer;
using Xunit;

namespace FrameworklessServerTests
{
    public class ServerTests
    {
        [Fact]
        public async Task SendingAGetRequestShouldReturnCorrectStatusCode()
        {
            var server = new Server();
            _ = Task.Run(server.Start);
            
            var client = new HttpClient();
            var message = await client.GetAsync("http://localhost:8080");
            Assert.Equal(HttpStatusCode.OK, message.StatusCode);
        }
    }
}