﻿using System;
using FrameworklessServer.Controllers;
using FrameworklessServer.Data.Services;

namespace FrameworklessServer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var users = new UsersService();
            var controller = new Controller(users);
            var server = new Server(controller);
            server.Start();
        }
    }
}