using System.Net;
using FrameworklessServer.Controllers;
using FrameworklessServer.Data.Services;
using Xunit;

namespace FrameworklessServerTests.ControllerTests
{
    public class InvalidControllerTests
    {
        [Fact]
        public void GivenInvalidRequestShouldReturnNotFound()
        {var userService = new UserService();
            var controller = new InvalidController(userService);
            var response = controller.InvalidRequest();

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}