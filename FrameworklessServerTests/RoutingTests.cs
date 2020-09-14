using System;
using System.IO;
using FrameworklessServer;
using Xunit;

namespace FrameworklessServerTests
{
    public class RoutingTests
    {
        [Theory]
        [InlineData("http://localhost:8080/", typeof(IndexGreetingResponse))]
        [InlineData("http://localhost:8080/users", typeof(GetUsersResponse))]

        public void GivenUrlShouldReturnCorrectRequestType(string url, Type expectedType)
        {
            var router = new Router();
            var result = router.GetRequestControl(url);
            Assert.IsType(expectedType, result);
        }
        
        [Fact]
        public void GivenInvalidUrlShouldThrowException()
        {
            var router = new Router();
            Assert.Throws<DirectoryNotFoundException>(() => router.GetRequestControl("http://localhost:8080/aninvalidurl"));
        }
    }
}