using System.Collections.Generic;
using System.Net;
using FrameworklessServer.Controllers;
using FrameworklessServer.Data.Model;
using FrameworklessServer.Data.Services;
using Moq;
using Xunit;

namespace FrameworklessServerTests.ControllerTests
{
    public class SingleUserControllerTests
    {
        private static readonly IUserService UsersService = new UserService();
        private readonly SingleUserController _controller = new SingleUserController(UsersService);

        public SingleUserControllerTests()
        {
            ResetList();
        }
        
        private static void ResetList()
        {
            var  allUsers = UsersService.GetAllUsers();
            allUsers.RemoveAll(user => user.Name != "Cindy");
            UsersService.CreateNewJArray(allUsers);
        }
        
        
        [Fact]
        public void PutMethodShouldReturnOkStatusIfUserSuccessfullyUpdated()
        {
            var userService = new Mock<IUserService>();
            userService.Setup(u => u.GetAllUsers()).Returns(new List<User> {new User("Cindy"), new User("Bob")});
            var controller = new SingleUserController(userService.Object);
            var response = controller.UpdateUser("Bob", "Sue");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public void PutMethodShouldReturnNotFoundIfUpdatedNonExistentUser()
        {
            var response = _controller.UpdateUser("Bob", "Sue");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public void PutMethodShouldReturnNotFoundIfUpdatedNullUser()
        {
            var response = _controller.UpdateUser(null, "Mary");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public void GetMethodShouldReturnOkIfUserIsValid()
        {
            var response = _controller.GetNameFromUrl("/users/cindy");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}