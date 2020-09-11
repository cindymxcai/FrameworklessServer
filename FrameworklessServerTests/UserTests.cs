using System;
using System.Collections.Generic;
using FrameworklessServer;
using Newtonsoft.Json;
using Xunit;

namespace FrameworklessServerTests
{
    public class UserTests
    {

        [Fact]
        public void GivenListOfUsersShouldHaveCindyByDefault()
        {
            var users = new Users();
            var result = users.AllUsers;

            var expected = new List<User>{new User("Cindy")};
           
            Assert.Equal(expected[0].Name, result[0].Name);
        }
        
        
        [Fact]
        public void GivenUserNameShouldAddToUsers()
        {
            var users = new Users();

            users.Add(new User("Bob"));
            var result = users.AllUsers;
            var expected = new List<User>
            {
                new User("Cindy"), new User("Bob")
            };

            Assert.Equal(2, result.Count);
            Assert.Equal(expected[0].Name, result[0].Name);
            Assert.Equal(expected[1].Name, result[1].Name);
        }
        
        [Fact]
        public void GivenUserNameShouldDeleteFromUsers()
        {
            var users = new Users();
            users.Add(new User("Mary"));
            users.Add(new User("Bob"));

            Assert.Equal(3, users.AllUsers.Count);
            users.Delete("Bob");
            var expected = new List<User>
            {
                new User("Cindy"), new User("Mary")
            };

            Assert.Equal(2, users.AllUsers.Count);
            Assert.Equal(expected[0].Name, users.AllUsers[0].Name);
        }
        
                
        [Fact]
        public void GivenDeletingNameOfWorldOwnerShouldThrowException()
        {
            var users = new Users();
            Assert.Throws<ArgumentException>(() => users.Delete("Cindy"));
        }
    }
}