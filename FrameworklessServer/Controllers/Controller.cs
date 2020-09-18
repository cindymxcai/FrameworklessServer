using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using FrameworklessServerTests;

namespace FrameworklessServer.Controllers
{
    public class Controller 
    {
        
        //todo define route for this controller. Using router?
        private readonly IUserService _userService;
        const string regex = @"\w+";


        public Controller(IUserService userService)
        {
            _userService = userService;
        }

        public Response HandleRequest(Request request)
        {
            Console.WriteLine(request.Path);
            Console.WriteLine(request.Method);
            IResponse response;
            if (request.Path == "/users" && request.Method == "GET")
            {
                response = new GetUsersResponse();
                return response.Write(_userService);
            }

            if (request.Path == "/" && request.Method == "GET")
            {
                response = new IndexGreetingResponse();
                return response.Write(_userService);
            }

            if (Regex.IsMatch(request.Path, $"/users/{regex}"))
            {
                return GetNameFromUrl(request.Path);
            }

            response = new InvalidUrlResponse();
            return response.Write(_userService);
        }
        
        private Response GetNameFromUrl(string url)
        {
            var name = url.Split('/').Last();
            var response = new GetSingleUserResponse(name);
            return response.Write(_userService);
        }
    }
}