using System.Net;
using System.Net.Http;

namespace FrameworklessServer
{
    public class Request
    {
        public string Path;
        public string Method;
        public HttpListenerContext Body;
    }
}