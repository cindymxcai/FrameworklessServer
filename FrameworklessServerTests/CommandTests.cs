using System;
using FrameworklessServer;
using Xunit;

namespace FrameworklessServerTests
{
    public class CommandTests
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
            var result = indexGreeting.Write(_users);

            Assert.Equal(expected.Body, result.Body);
            Assert.Equal(expected.StatusCode, result.StatusCode);
            ResetList();
        }
        
        [Fact]
        public void ShouldReturnCorrectResponseWhenExecuted()
        {
            var userResponse = new GetOneUserResponse("Bob");
            _users.Add(new User("Bob"));

            var result = userResponse.Write(_users);
            var expected = new Response("Bob", "200");

            Assert.Equal(expected.Body, result.Body);
            Assert.Equal(expected.StatusCode, result.StatusCode);

            ResetList();
        }
        
    }

    public class GetOneUserResponse
    {
        private readonly string _user;

        public GetOneUserResponse(string user)
        {
            _user = user;
        }

        public Response Write(Users users)
        {
            var person = users.Get(_user);
            return new Response(person.Name, "200");
        }
    }
}