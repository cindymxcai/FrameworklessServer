using System;
using System.Net;
using FrameworklessServer.Controllers;
using FrameworklessServer.Data.Model;
using FrameworklessServer.Data.Services;
using Xunit;

namespace FrameworklessServerTests
{
    public class ControllerTests
    {
        private readonly UsersService _usersService = new UsersService();
        //todo inject test user service

        private void ResetList()
        {
            var  allUsers = _usersService.GetAllUsers();
            allUsers.RemoveAll(user => user.Name != "Cindy");
            _usersService.CreateNewJArray(allUsers);
        }
        
        [Fact]
        public void GetAllUsersShouldReturnListOfAllUsers()
        {
            //todo do this!!
            var controller = new Controller(_usersService);

           var expectedBody = @"[{""Name"":""Cindy""}]";
           var response = controller.GetAllUsers();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expectedBody,response.Body);
            ResetList();
        }

        [Fact]
        public void AddUserShouldReturnNoUserResponseWhenNullUser()
        {
            var controller = new Controller(_usersService);
            var response = controller.AddUser(null);
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            ResetList();
        }

        [Fact]
        public void AddUserShouldReturnOkResponseWhenValidUser()
        {
            var controller = new Controller(_usersService);
            var response = controller.AddUser(new User("Mary"));
            
            Assert.Equal("User added", response.Body);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            ResetList();
        }

        [Fact]
        public void DeleteUserShouldReturnSuccessResponseIfUserSuccessfullyDeleted()
        {
            var controller = new Controller(_usersService);
            controller.AddUser(new User("Bob"));
            var response = controller.DeleteUser( "Bob");
            
            Assert.Equal("User deleted", response.Body);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            ResetList();
        }

        [Fact]
        public void DeleteUserShouldReturnNotFoundResponseIfUserDoesNotExist()
        {
            var controller = new Controller(_usersService);
            var response = controller.DeleteUser( "Bob");
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            ResetList();
        }
        
        [Fact]
        public void DeleteUserShouldReturnNotFoundResponseIfUserNameIsNull()
        {
            var controller = new Controller(_usersService);
            var response = controller.DeleteUser( null);
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            ResetList();
        }

        [Fact]
        public void PutMethodShouldReturnOkStatusIfUserSuccessfullyUpdated()
        {
            var controller = new Controller(_usersService);
            var bob = new User("Bob");
            _usersService.Add(bob);
            Assert.Contains(_usersService.GetAllUsers(), u => u.Name == bob.Name);
            var response = controller.UpdateUser("Bob", "Sue");
            Assert.DoesNotContain(_usersService.GetAllUsers(), u => u.Name == bob.Name);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            ResetList();
        }

        [Fact]
        public void PutMethodShouldReturnNotFoundIfUpdatedNonExistentUserOrNullUser()
        {
           var controller = new Controller(_usersService);
           var response = controller.UpdateUser("Bob", "Sue");
           Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

           response = controller.UpdateUser(null, "Mary");
           Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
           ResetList();
        }
    }
}