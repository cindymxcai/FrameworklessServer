using System;

namespace FrameworklessServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var server = new Server();
            server.Start();
        }
    }
}