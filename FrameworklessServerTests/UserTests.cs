using System;
using System.Collections.Generic;
using FrameworklessServer;
using Xunit;

namespace FrameworklessServerTests
{
    public class UserTests
    {

        private void ResetList()
        {
             var users = new Users();
             var  allUsers = users.GetAllUsers();
             allUsers.RemoveAll(user => user.Name != "Cindy");
             users.CreateNewJArray(allUsers);
        }
        
        [Fact]
        public void GivenListOfUsersShouldHaveCindyByDefault()
        {
            var users = new Users();
            var result = users.GetAllUsers();

            var expected = new List<User>{new User("Cindy")};
           
            Assert.Equal(expected[0].Name, result[0].Name);
            ResetList();
        }
        
        
        [Fact]
        public void GivenUserNameShouldAddToUsers()
        {
            var users = new Users();

            users.Add(new User("Bob"));
            var result = users.GetAllUsers();
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
            var users = new Users();
            users.Add(new User("Mary"));
            users.Add(new User("Bob"));

            Assert.Equal(3, users.GetAllUsers().Count);
            users.Delete("Bob");
            var expected = new List<User>
            {
                new User("Cindy"), new User("Mary")
            };

            Assert.Equal(2, users.GetAllUsers().Count);
            Assert.Equal(expected[0].Name, users.GetAllUsers()[0].Name);
            ResetList();
        }
        
        [Fact]
        public void GivenDeletingNameOfWorldOwnerShouldThrowException()
        {
            var users = new Users();
            Assert.Throws<ArgumentException>(() => users.Delete("Cindy"));
            ResetList();
        }

        [Fact]
        public void GivenUserNameShouldReturnNameFromList()
        {
            var users = new Users();
            users.Add(new User("Bob"));
            users.Add(new User("Mary"));

            var result = users.Get("Bob");
            
            var expected = new User("Bob");
            
            Assert.Equal(expected.Name, result.Name);
        }
    }
}