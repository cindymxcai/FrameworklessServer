using System;
using FrameworklessServer.Controllers;

namespace FrameworklessServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var router = new Router();
            var users = new UsersService();
            var controller = new Controller(users);
            var server = new Server(controller,router, users);
            server.Start();
        }
    }
}