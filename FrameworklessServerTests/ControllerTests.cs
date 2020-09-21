using System.Net;
using System.Net.Http;
using FrameworklessServer;
using FrameworklessServer.Controllers;
using FrameworklessServer.Data.Model;
using FrameworklessServer.Data.Services;
using Xunit;

namespace FrameworklessServerTests
{
    public class ControllerTests
    {
        [Fact]
        public void GetAllUsersShouldReturnListOfAllUsers()
        {
            var userService = new UsersService();
            var controller = new Controller(userService);

           var expectedBody = @"[{""Name"":""Cindy""}]";
           var response = controller.GetAllUsers();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expectedBody,response.Body);
        }

        [Fact]
        public void AddUserShouldReturnNoUserResponseWhenNullUser()
        {
            var userService = new UsersService();
            var controller = new Controller(userService);
            var response = controller.AddUser(null);
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public void AddUserShouldReturnOkResponseWhenValidUser()
        {
            var userService = new UsersService();
            var controller = new Controller(userService);
            var response = controller.AddUser(new User("Cindy"));
            
            Assert.Equal("User added", response.Body);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}