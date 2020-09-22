using System;
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

        public void Start()
        {
            _listener.Start();
            while (true)
            {
                var context = _listener.GetContext();
                Console.WriteLine($"{context.Request.HttpMethod} {context.Request.Url}");
                var segmentedUrl = context.Request.Url.Segments.Aggregate("", (current, segment) => current + segment);
                
                var request = new Request {Method = context.Request.HttpMethod, Path = segmentedUrl, Body = context};

                //TODO put this stuff in Router
               // var response = _router.GetRequestControl(context.Request.Url.Segments);
               var response = _controller.HandleRequest(request);
                Console.Write(response.Body);
                var responseBody = response.Body;
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseBody);
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}