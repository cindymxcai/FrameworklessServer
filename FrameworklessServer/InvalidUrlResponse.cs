using System.Net;
using FrameworklessServer.Data.Services;
using FrameworklessServerTests;

namespace FrameworklessServer
{
    public class InvalidUrlResponse : IResponse
    {
        public  Response Write(IUserService usersService)
        {

            return new Response {Body = "404 Page Not Found", StatusCode = HttpStatusCode.NotFound};
        }
        
    }
}