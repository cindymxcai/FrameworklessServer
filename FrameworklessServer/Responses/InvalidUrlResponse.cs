using System.Net;
using FrameworklessServer.Data.Services;

namespace FrameworklessServer.Responses
{
    public class InvalidUrlResponse : IResponse
    {
        public  Response Write(IUserService usersService)
        {
            return new Response {Body = "404 Page Not Found", StatusCode = HttpStatusCode.NotFound};
        }
        
    }
}