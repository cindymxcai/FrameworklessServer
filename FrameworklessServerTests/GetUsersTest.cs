using System;
using FrameworklessServer;
using Xunit;

namespace FrameworklessServerTests
{
    public class GetUsersTest
    {
        private readonly Users _users = new Users();
        private void ResetList()
        {
            var  allUsers = _users.GetAllUsers();
            allUsers.RemoveAll(user => user.Name != "Cindy");
            _users.CreateNewJArray(allUsers);
        }
        
       [Fact]
        public void GivenUserNamesShouldListOutNames()
        {
            var usersResponse = new GetUsersResponse();

            _users.Add(new User("Bob"));
            _users.Add(new User("Mary"));
            
            var expected = new Response("Cindy\nBob\nMary", "200");
            var result = usersResponse.Write(_users);

            Assert.Equal(expected.Body, result.Body);
            Assert.Equal(expected.StatusCode, result.StatusCode);
            ResetList();
        }
        
        [Fact]
        public void GivenNameShouldWriteMessageInCorrectFormat()
        {
       var indexGreeting = new IndexGreetingResponse();
            
            var expected = new Response( $"Hello Cindy - the time on the server is {DateTime.Now.ToShortTimeString()} on {DateTime.Now.ToLongDateString()}", "200");
            var actual = indexGreeting.Write(_users);

            Assert.Equal(expected.Body, actual.Body);
            Assert.Equal(expected.StatusCode, actual.StatusCode);
            ResetList();
        }
    }
}