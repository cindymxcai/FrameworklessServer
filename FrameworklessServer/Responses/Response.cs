using System.Net;

namespace FrameworklessServer.Responses
{
    public class Response
    {
        public string Body { get; set; }
        
        public HttpStatusCode StatusCode { get; set; }
    }
}