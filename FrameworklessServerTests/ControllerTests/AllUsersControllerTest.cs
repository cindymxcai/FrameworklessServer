using System.Net;
using FrameworklessServer;
using FrameworklessServer.Controllers;
using FrameworklessServer.Data.Model;
using FrameworklessServer.Data.Services;
using Xunit;

namespace FrameworklessServerTests.ControllerTests
{
    public class AllUsersControllerTest
    {
        public AllUsersControllerTest()
        {
            ResetList();
        }
        
        private static void ResetList()
        {
            var  allUsers = UsersService.GetAllUsers();
            allUsers.RemoveAll(user => user.Name != "Cindy");
            UsersService.CreateNewJArray(allUsers);
        }

        private static readonly IUserService UsersService = new UserService();
        private readonly AllUsersController _controller = new AllUsersController(UsersService);

        [Fact]
        public void GetAllUsersShouldReturnListOfAllUsers()
        {
            var expectedBody = @"[{""Name"":""Cindy""}]";
            var response = _controller.GetAllUsers();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expectedBody, response.Body);
        }

        [Fact]
        public void AddUserShouldReturnNoUserResponseWhenNullUser()
        {
            var response = _controller.AddUser(null);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public void AddUserShouldReturnOkResponseWhenValidUser()
        {
            var response = _controller.AddUser(new User("Mary"));

            Assert.Equal("User added", response.Body);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Fact]
        public void DeleteUserShouldReturnSuccessResponseIfUserSuccessfullyDeleted()
        {
            _controller.AddUser(new User("Bob"));
            var response = _controller.DeleteUser( "Bob");
            
            Assert.Equal("User deleted", response.Body);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void DeleteUserShouldReturnNotFoundResponseIfUserDoesNotExist()
        {
            var response = _controller.DeleteUser( "Bob");
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        
        [Fact]
        public void DeleteUserShouldReturnNotFoundResponseIfUserNameIsNull()
        {
            var response = _controller.DeleteUser( null);
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}