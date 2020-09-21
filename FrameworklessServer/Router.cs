using System;
using System.Linq;
using System.Text.RegularExpressions;
using FrameworklessServer.Controllers;
using FrameworklessServerTests;

namespace FrameworklessServer
{
    public class Router
    {
        private readonly Controller _controller;

        public Router(Controller controller)
        {
            _controller = controller;
        }

        public void HandleHttpRequest(Request request)
        {
            if (request.Path == "/users" && request.Method == "GET")
            {
                _controller.GetAllUsers();
            }
            
        }
        public IResponse HandleRequest(string[] url)
        {
            const string regex = @"\w+";

            var segmentedUrl = url.Aggregate("", (current, segment) => current + segment);
            Console.WriteLine(segmentedUrl);
            return segmentedUrl switch
            {
                "/" => new IndexGreetingResponse(),
                "/users" => new GetUsersResponse(),
                _ when Regex.IsMatch(segmentedUrl, $"/users/{regex}") => GetNameFromUrl(segmentedUrl),
                _ => new InvalidUrlResponse() 
            };
        }
        
        private IResponse GetNameFromUrl(string url)
        {
            var name = url.Split('/').Last();
            return new GetSingleUserResponse(name);

        }
    }
}