using System;
using System.Collections.Generic;
using System.IO;
using FrameworklessServer;
using Xunit;

namespace FrameworklessServerTests
{
    public class UserTests
    {
        private readonly Users _users = new Users();

        private void ResetList()
        {
             var  allUsers = _users.GetAllUsers();
             allUsers.RemoveAll(user => user.Name != "Cindy");
             _users.CreateNewJArray(allUsers);
        }
        
        [Fact]
        public void GivenListOfUsersShouldHaveCindyByDefault()
        {
            var result = _users.GetAllUsers();

            var expected = new List<User>{new User("Cindy")};
           
            Assert.Equal(expected[0].Name, result[0].Name);
            ResetList();
        }
        
        
        [Fact]
        public void GivenUserNameShouldAddToUsers()
        {
            _users.Add(new User("Bob"));
            var result = _users.GetAllUsers();
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
            _users.Add(new User("Mary"));
            _users.Add(new User("Bob"));

            Assert.Equal(3, _users.GetAllUsers().Count);
            _users.Delete("Bob");
            var expected = new List<User>
            {
                new User("Cindy"), new User("Mary")
            };

            Assert.Equal(2, _users.GetAllUsers().Count);
            Assert.Equal(expected[0].Name, _users.GetAllUsers()[0].Name);
            ResetList();
        }
        
        [Fact]
        public void GivenDeletingNameOfWorldOwnerShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => _users.Delete("Cindy"));
            ResetList();
        }

        [Fact]
        public void GivenUserNameShouldReturnNameFromList()
        {
            _users.Add(new User("Bob"));
            _users.Add(new User("Mary"));

            var result = _users.Get("Bob");
            
            var expected = new User("Bob");
            
            Assert.Equal(expected.Name, result.Name);
            ResetList();
        }
    }
}