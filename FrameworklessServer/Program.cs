using System;

namespace FrameworklessServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var router = new Router();
            var users = new Users();
            var server = new Server(router, users);
            server.Start();
        }
    }
}