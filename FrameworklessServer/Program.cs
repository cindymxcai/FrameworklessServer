using System;
using FrameworklessServer.Controllers;
using FrameworklessServer.Data.Services;

namespace FrameworklessServer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var usersService = new UserService();
            var router = new Router(usersService);
            var server = new Server(router);
            server.Start();
        }
    }
}