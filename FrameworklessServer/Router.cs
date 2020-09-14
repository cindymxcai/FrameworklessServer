using System.IO;
using FrameworklessServerTests;

namespace FrameworklessServer
{
    public class Router
    {
        public IResponse GetRequestControl(string url)
        {
            return url switch
            {
                "http://localhost:8080/" => new IndexGreetingResponse(),
                "http://localhost:8080/users" => new GetUsersResponse(),
                _ =>  throw new DirectoryNotFoundException()
            };

        }
    }
}