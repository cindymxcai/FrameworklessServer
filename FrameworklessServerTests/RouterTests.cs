using System;
using FrameworklessServer;
using FrameworklessServer.Controllers;
using FrameworklessServer.Data.Services;
using Xunit;

namespace FrameworklessServerTests
{
    public class RouterTests
    {
        [Theory]
        [InlineData("/", typeof(IndexController))]
        [InlineData("/users", typeof(AllUsersController))]
        [InlineData("/users/cindy", typeof(SingleUserController))]

        public void GivenPathShouldCallReturnCorrectController(string path, Type expectedType)
        {
            var userService = new UserService();
            var router = new Router(userService);
            var result = router.GetController(path);
            Assert.IsType(expectedType, result);
        }
    }
}