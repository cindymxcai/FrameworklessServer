using System;
using System.Collections.Generic;
using System.IO;
using FrameworklessServer;
using Xunit;

namespace FrameworklessServerTests
{
    public class RoutingTests
    {
        [Theory]
        [MemberData(nameof(UriData))]
        public void GivenUrlShouldReturnCorrectRequestType(Uri url, Type expectedType)
        {
            var router = new Router();
            var result = router.GetRequestControl(url.Segments );
            Assert.IsType(expectedType, result);
        }

        public static IEnumerable<object[]> UriData()
        {
            yield return new object[]{ new Uri("http://localhost:8080/"), typeof(IndexGreetingResponse)};
            yield return new object[] {new Uri("http://localhost:8080/users"), typeof(GetUsersResponse)};
            yield return new object[] {new Uri("http://localhost:8080/users/cindy"), typeof(GetSingleUserResponse) };
            yield return new object[] {new Uri("http://localhost:8080/invalidurl"), typeof(InvalidUrlResponse) };

            
        }
        
    }
}