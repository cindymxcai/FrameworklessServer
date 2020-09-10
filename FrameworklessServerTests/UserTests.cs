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
    }
}