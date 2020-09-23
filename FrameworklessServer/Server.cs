using System.Linq;
using System.Net;
using Controller =  FrameworklessServer.Controllers.Controller;
namespace FrameworklessServer
{
    public class Server
    {
        private readonly Controller _controller;
        private readonly HttpListener _listener;

        public Server(Controller controller)
        {
            _controller = controller;
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:8080/");
        }

        
        //http://localhost:8080   /users/cindy
        public void Start()
        {
            _listener.Start();
            while (true)
            {
                var context = _listener.GetContext();
                var segmentedUrl = context.Request.Url.Segments.Aggregate("", (current, segment) => current + segment);
                var request = new Request {Method = context.Request.HttpMethod, Path = segmentedUrl, Body = context};
                //router to determine controller
                var response = _controller.HandleRequest(request).Body;
                
                var buffer = System.Text.Encoding.UTF8.GetBytes(response);
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}