using System.Linq;
using System.Net;

namespace FrameworklessServer
{
    public class Server
    {
        private readonly Router _router;
        private readonly HttpListener _listener;

        public Server(Router router)
        {
            _router = router;
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:8080/");
        }
        
        public void Start()
        {
            _listener.Start();
            while (true)
            {
                var context = _listener.GetContext();
                var segmentedUrl = context.Request.Url.Segments.Aggregate("", (current, segment) => current + segment);
                var request = new Request {Method = context.Request.HttpMethod, Path = segmentedUrl, Body = context};
                var controller = _router.GetController(request.Path);
                
                var response = controller.HandleRequest(request).Body;

                var buffer = System.Text.Encoding.UTF8.GetBytes(response);
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                
                context.Response.OutputStream.Flush();
                context.Response.OutputStream.Close();
            }
        }
    }
} 