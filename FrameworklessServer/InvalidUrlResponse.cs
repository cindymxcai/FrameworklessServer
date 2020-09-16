using FrameworklessServerTests;

namespace FrameworklessServer
{
    public class InvalidUrlResponse : IResponse
    {
        public Response Write(Users users)
        {
            
            return new Response("404 Page Not Found", "404");
        }
    }
}