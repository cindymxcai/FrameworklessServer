using System.Net;
using FrameworklessServer.Data.Services;

namespace FrameworklessServer.ResponseTypes
{
    public class InvalidUrlResponseType 
    {
        public Response Write(IUserService usersService)
        {
            return new Response {Body = "404 Page Not Found", StatusCode = HttpStatusCode.NotFound};
        }
        
    }
}