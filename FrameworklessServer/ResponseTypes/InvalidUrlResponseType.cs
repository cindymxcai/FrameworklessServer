using System.Net;

namespace FrameworklessServer.ResponseTypes
{
    public class InvalidUrlResponseType 
    {
        public Response Write()
        {
            return new Response {Body = "404 Page Not Found", StatusCode = HttpStatusCode.NotFound};
        }
        
    }
}