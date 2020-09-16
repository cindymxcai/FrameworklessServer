using System;
using System.Net;

namespace FrameworklessServer
{
    public class Server
    {
        private readonly Router _router;
        private readonly Users _users;
        private readonly HttpListener _listener;

        public Server(Router router, Users users)
        {
            _router = router;
            _users = users;
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

                var response = _router.GetRequestControl(context.Request.Url.Segments);
                Console.Write(response.ToString());
                var responseBody = response.Write(_users).Body;
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseBody);
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}