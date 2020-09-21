using System;
using System.Net;
using FrameworklessServer;
using FrameworklessServer.Data.Model;
using FrameworklessServer.Data.Services;
using Xunit;

namespace FrameworklessServerTests
{
    public class CommandTests
    {
        private readonly UsersService _usersService = new UsersService();
        private void ResetList()
        {
            var  allUsers = _usersService.GetAllUsers();
            allUsers.RemoveAll(user => user.Name != "Cindy");
            _usersService.CreateNewJArray(allUsers);
        }
        
        [Fact]
        public void GivenUserNamesShouldListOutNames()
        {
            var usersResponse = new GetUsersResponse();

            _usersService.Add(new User("Bob"));
            _usersService.Add(new User("Mary"));
            
            var expected = new Response{Body = @"[{""Name"":""Cindy""},{""Name"":""Bob""},{""Name"":""Mary""}]", StatusCode = HttpStatusCode.OK};
            var result = usersResponse.Write(_usersService);

            Assert.Equal(expected.Body, result.Body);
            Assert.Equal(expected.StatusCode, result.StatusCode);
            ResetList();
        }
        
        [Fact]
        public void GivenNameShouldWriteMessageInCorrectFormat()
        {
            var indexGreeting = new IndexGreetingResponse();
            
            var expected = new Response{Body = $"Hello Cindy - the time on the server is {DateTime.Now.ToShortTimeString()} on {DateTime.Now.ToLongDateString()}", StatusCode = HttpStatusCode.OK};
            var result = indexGreeting.Write(_usersService);

            Assert.Equal(expected.Body, result.Body);
            Assert.Equal(expected.StatusCode, result.StatusCode);
            ResetList();
        }
        
        [Fact]
        public void ShouldReturnCorrectResponseWhenExecuted()
        {
            var userResponse = new GetSingleUserResponse("Bob");
            _usersService.Add(new User("Bob"));

            var result = userResponse.Write(_usersService);
            var expected = new Response{Body ="Bob", StatusCode = HttpStatusCode.OK};

            Assert.Equal(expected.Body, result.Body);
            Assert.Equal(expected.StatusCode, result.StatusCode);

            ResetList();
        }
        
    }
}