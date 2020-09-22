using System;
using System.Collections.Generic;
using FrameworklessServer.Data.Model;
using FrameworklessServer.Data.Services;
using Xunit;

namespace FrameworklessServerTests
{
    public class UsersServiceTests
    {
        private readonly UsersService _usersService = new UsersService();

        private void ResetList()
        {
             var  allUsers = _usersService.GetAllUsers();
             allUsers.RemoveAll(user => user.Name != "Cindy");
             _usersService.CreateNewJArray(allUsers);
        }

        [Fact]
        public void GetAllUsersShouldReturnListOfAllUsers()
        {
            var result = _usersService.GetAllUsers();
            Assert.IsType<List<User>>(result);
            Assert.Equal("Cindy", result[0].Name);
            ResetList();
        }
        
        [Fact]
        public void GivenListOfUsersShouldHaveCindyByDefault()
        {
            var result = _usersService.GetAllUsers();

            var expected = new List<User>{new User("Cindy")};
           
            Assert.Equal(expected[0].Name, result[0].Name);
            ResetList();
        }
        
        [Fact]
        public void GivenUserNameShouldAddToUsers()
        {
            _usersService.Add(new User("Bob"));
            var result = _usersService.GetAllUsers();
            var expected = new List<User> {new User("Cindy"), new User("Bob")};
            
            Assert.Equal(2, result.Count);
            Assert.Equal(expected[0].Name, result[0].Name);
            Assert.Equal(expected[1].Name, result[1].Name);           

            ResetList();
        }

        [Fact]
        public void AddUserShouldThrowExceptionWhenUserIsNull()
        {
           Assert.Throws<ArgumentNullException>( () =>_usersService.Add(null));
        }

        [Fact]
        public void AddUserShouldThrowExceptionWhenUserAlreadyExists()
        {
            Assert.Throws<ArgumentException>(() => _usersService.Add(new User("Cindy")));
        }

        [Fact]
        public void GivenUserNameShouldDeleteFromUsers()
        {
            _usersService.Add(new User("Mary"));
            _usersService.Add(new User("Bob"));

            Assert.Equal(3, _usersService.GetAllUsers().Count);
            _usersService.Delete("Bob");
            var expected = new List<User> {new User("Cindy"), new User("Mary")};

            Assert.Equal(2, _usersService.GetAllUsers().Count);
            Assert.Equal(expected[0].Name, _usersService.GetAllUsers()[0].Name);
            ResetList();
        }
        
        [Fact]
        public void GivenDeletingNameOfWorldOwnerShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => _usersService.Delete("Cindy"));
            ResetList();
        }

        [Fact]
        public void GivenDeletingNonExistentNameShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => _usersService.Delete("Bob"));
            ResetList();
        }

        [Fact]
        public void GivenUserNameShouldReturnNameFromList()
        {
            _usersService.Add(new User("Bob"));
            _usersService.Add(new User("Mary"));

            var result = _usersService.Get("Mary");
            
            var expected = new User("Mary");
            
            Assert.Equal(expected.Name, result.Name);
            ResetList();
        }

        [Fact]
        public void GivenUserNameShouldUpdateToNewName()
        {
            _usersService.Add(new User("Bob"));
            var expected = new List<User> {new User("Cindy"), new User("Bob")};
            Assert.Equal(expected[1].Name, _usersService.GetAllUsers()[1].Name);

            _usersService.UpdateUser("Bob", "Mary");
            
             expected = new List<User> {new User("Cindy"), new User("Mary")};
            Assert.Equal(expected[1].Name, _usersService.GetAllUsers()[1].Name);
            ResetList();
        }

        [Fact]
        public void GivenNullUserNameWorldOwnerNameOrNonExistentNameShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => _usersService.UpdateUser("Sue", "Mary"));
            Assert.Throws<InvalidOperationException>(() => _usersService.UpdateUser(null, "Mary"));
            Assert.Throws<InvalidOperationException>(() => _usersService.UpdateUser("Cindy", "Mary"));
        }
    }
}