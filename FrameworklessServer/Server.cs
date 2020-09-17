using System;
using System.Net;

namespace FrameworklessServer
{
    public class Server
    {
        private readonly Router _router;
        private readonly UsersService _usersService;
        private readonly HttpListener _listener;

        public Server(Router router, UsersService usersService)
        {
            _router = router;
            _usersService = usersService;
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

                //TODO put this stuff in Router
                var response = _router.GetRequestControl(context.Request.Url.Segments);
                Console.Write(response.ToString());
                var responseBody = response.Write(_usersService).Body;
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseBody);
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}