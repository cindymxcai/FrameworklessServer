using System.Collections.Generic;
using FrameworklessServer;
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

            var expected = new List<User>{new User("cindy")};
           
            Assert.Equal(expected[0].Name, result[0].Name);
        }
        
        
        [Fact]
        public void GivenNewPersonShouldAddToUsers()
        {
            var users = new Users();

            users.Add(new User("bob"));
            var result = users.AllUsers;
            var expected = new List<User>
            {
                new User("cindy"), new User("bob")
            };

            Assert.Equal(2, result.Count);
            Assert.Equal(expected[0].Name, result[0].Name);
            Assert.Equal(expected[1].Name, result[1].Name);

        }
    }
}