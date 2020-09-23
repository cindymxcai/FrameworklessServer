using System.Net;

namespace FrameworklessServer
{
    public class Request
    {
        public string Path;
        public string Method;
        public HttpListenerContext Body;
    }
}