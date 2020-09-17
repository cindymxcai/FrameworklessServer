using System;
using System.Collections.Generic;
using System.IO;
using FrameworklessServer;
using Xunit;

namespace FrameworklessServerTests
{
    public class UserTests
    {
        private readonly UsersService _usersService = new UsersService();

        private void ResetList()
        {
             var  allUsers = _usersService.GetAllUsers();
             allUsers.RemoveAll(user => user.Name != "Cindy");
             _usersService.CreateNewJArray(allUsers);
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
            var expected = new List<User>
            {
                new User("Cindy"), new User("Bob")
            };
            
            Assert.Equal(2, result.Count);
            Assert.Equal(expected[0].Name, result[0].Name);
            Assert.Equal(expected[1].Name, result[1].Name);           

            ResetList();

        }
        
        [Fact]
        public void GivenUserNameShouldDeleteFromUsers()
        {
            _usersService.Add(new User("Mary"));
            _usersService.Add(new User("Bob"));

            Assert.Equal(3, _usersService.GetAllUsers().Count);
            _usersService.Delete("Bob");
            var expected = new List<User>
            {
                new User("Cindy"), new User("Mary")
            };

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
        public void GivenUserNameShouldReturnNameFromList()
        {
            _usersService.Add(new User("Bob"));
            _usersService.Add(new User("Mary"));

            var result = _usersService.Get("Mary");
            
            var expected = new User("Mary");
            
            Assert.Equal(expected.Name, result.Name);
            ResetList();
        }
    }
}