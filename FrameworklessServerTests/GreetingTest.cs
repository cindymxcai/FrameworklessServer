using System;
using FrameworklessServer;
using Xunit;

namespace FrameworklessServerTests
{
    public class GreetingTest
    {
        [Fact]
        public void GivenNameShouldWriteMessageInCorrectFormat()
        {
            var users = new Users();
            var indexGreeting = new IndexGreetingResponse();
            
            var actual = indexGreeting.Write(users);
            
            var body =  $"Hello Cindy - the time on the server is {DateTime.Now.ToShortTimeString()} on " +
                        $"{DateTime.Now.ToLongDateString()}";

            var expected = new Response(body, "200");

            Assert.Equal(expected.Body, actual.Body);
            Assert.Equal(expected.StatusCode, actual.StatusCode);
        }
        
    }
    
}