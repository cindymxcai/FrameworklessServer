using System.Net;

namespace FrameworklessServer
{
    public class Response
    {
        public string Body { get; set; }
        
        public HttpStatusCode StatusCode { get; set; }
    }
}