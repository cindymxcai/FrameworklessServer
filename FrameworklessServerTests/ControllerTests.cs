using System.Net;
using System.Net.Http;
using FrameworklessServer;
using FrameworklessServer.Controller;
using Xunit;

namespace FrameworklessServerTests
{
    public class ControllerTests
    {
        [Fact]
        public void ShouldReturnAllUsersWhenPathIsUsersAndMethodIsGet()
        {
            var request = new Request{Method = HttpMethod.Get, Path = "/users"};
            var userService = new UsersService();
            var controller = new Controller(userService);

           var response = controller.HandleRequest(request);
           var expectedBody = @"[{""Name"":""Cindy""}]";
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expectedBody,response.Body);
        }

        [Fact]
        public void ShouldReturnNotFoundResponseWhenRouteUnknown()
        {
            var request = new Request{Method = HttpMethod.Get, Path = "/invalid"};
            var userService = new UsersService();
            var controller = new Controller(userService);

            var response = controller.HandleRequest(request);
            
            Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);
        }
    }
}