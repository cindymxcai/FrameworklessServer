using System.Net;
using FrameworklessServerTests;

namespace FrameworklessServer
{
    public class InvalidUrlResponse : IResponse
    {
        public Response Write(UsersService usersService)
        {

            return new Response {Body = "404 Page Not Found", StatusCode = HttpStatusCode.NotFound};
        }
    }
}