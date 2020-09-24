using System.Collections.Generic;
using System.Net;
using FrameworklessServer.Controllers;
using FrameworklessServer.Data.Model;
using FrameworklessServer.Data.Services;
using Moq;
using Xunit;

namespace FrameworklessServerTests
{
    public class OldControllerTests
    {
        /*private static readonly IUserService UsersService = new UserService();
         private readonly Controller _controller = new Controller(UsersService);

         public OldControllerTests()
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
        public void GetAllUsersShouldReturnListOfAllUsers()
        {
            var expectedBody = @"[{""Name"":""Cindy""}]";
           var response = _controller.GetAllUsers();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expectedBody,response.Body);
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

        [Fact]
        public void PutMethodShouldReturnOkStatusIfUserSuccessfullyUpdated()
        {
            var userService = new Mock<IUserService>();
            userService.Setup(u => u.GetAllUsers()).Returns(new List<User> {new User("Cindy"), new User("Bob")});
            var controller = new Controller(userService.Object);
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
        }    */
    }
}