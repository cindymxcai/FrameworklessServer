using System;
using System.Collections.Generic;
using FrameworklessServer.Data.Model;
using FrameworklessServer.Data.Services;
using Xunit;

namespace FrameworklessServerTests
{
    public class UsersServiceTests
    {
        private readonly UserService _userService = new UserService();

        public UsersServiceTests()
        {
            ResetList();
        }
        private void ResetList()
        {
             var  allUsers = _userService.GetAllUsers();
             allUsers.RemoveAll(user => user.Name != "Cindy");
             _userService.CreateNewJArray(allUsers);
        }

        [Fact]
        public void GetAllUsersShouldReturnListOfAllUsers()
        {
            var result = _userService.GetAllUsers();
            Assert.IsType<List<User>>(result);
            Assert.Equal("Cindy", result[0].Name);
        }
        
        [Fact]
        public void GivenListOfUsersShouldHaveCindyByDefault()
        {
            var result = _userService.GetAllUsers();

            var expected = new List<User>{new User("Cindy")};
           
            Assert.Equal(expected[0].Name, result[0].Name);
        }
        
        [Fact]
        public void GivenUserNameShouldAddToUsers()
        {
            _userService.Add(new User("Bob"));
            var result = _userService.GetAllUsers();
            var expected = new List<User> {new User("Cindy"), new User("Bob")};
            
            Assert.Equal(2, result.Count);
            Assert.Equal(expected[1].Name, result[1].Name);
        }

        [Fact]
        public void AddUserShouldThrowExceptionWhenUserIsNull()
        {
           Assert.Throws<ArgumentNullException>( () =>_userService.Add(null));
        }

        [Fact]
        public void AddUserShouldThrowExceptionWhenUserAlreadyExists()
        {
            Assert.Throws<ArgumentException>(() => _userService.Add(new User("Cindy")));
        }

        [Fact]
        public void GivenUserNameShouldDeleteFromUsers()
        {
            _userService.Add(new User("Mary"));
            _userService.Add(new User("Bob"));

            Assert.Equal(3, _userService.GetAllUsers().Count);
            _userService.Delete("Bob");
            var expected = new List<User> {new User("Cindy"), new User("Mary")};

            Assert.Equal(2, _userService.GetAllUsers().Count);
            Assert.Equal(expected[0].Name, _userService.GetAllUsers()[0].Name);
        }
        
        [Fact]
        public void GivenDeletingNameOfWorldOwnerShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => _userService.Delete("Cindy"));
        }

        [Fact]
        public void GivenDeletingNonExistentNameShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => _userService.Delete("Bob"));
        }

        [Fact]
        public void GivenUserNameShouldReturnNameFromList()
        {
            _userService.Add(new User("Bob"));
            _userService.Add(new User("Mary"));

            var result = _userService.Get("Mary");
            
            var expected = new User("Mary");
            
            Assert.Equal(expected.Name, result.Name);
        }

        [Fact]
        public void GivenUserNameShouldUpdateToNewName()
        {
            _userService.Add(new User("Bob"));
            var expected = new List<User> {new User("Cindy"), new User("Bob")};
            Assert.Equal(expected[1].Name, _userService.GetAllUsers()[1].Name);

            _userService.UpdateUser("Bob", "Mary");
            
             expected = new List<User> {new User("Cindy"), new User("Mary")};
            Assert.Equal(expected[1].Name, _userService.GetAllUsers()[1].Name);
        }

        [Fact]
        public void GivenNonExistentNameUpdateShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => _userService.UpdateUser("Sue", "Mary"));
        }

        [Fact]
        public void GivenNullUserNameUpdateShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => _userService.UpdateUser(null, "Mary"));
        }

        [Fact]
        public void GivenWorldOwnerNameUpdateShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => _userService.UpdateUser("Cindy", "Mary"));
        }
        
    }
}