using System;
using System.Net;

namespace FrameworklessServer
{
    public class Server
    {
        private readonly HttpListener _listener;

        public Server()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:8080/");
        }

        public void Start()
        {
            _listener.Start();
            while (true)
            {
                var context = _listener.GetContext();
                Console.WriteLine($"{context.Request.HttpMethod} {context.Request.Url}");
       
                var buffer = System.Text.Encoding.UTF8.GetBytes(
                    $"Hello Cindy - the time on the server is {FormatDateTime()}");
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            }
        }

        private string FormatDateTime()
        {
            var time = DateTime.Now.ToShortTimeString();
            var date = DateTime.Now.ToLongDateString();
            
            return $"{time} on {date}";
        }
    }
}