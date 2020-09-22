using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using FrameworklessServer.Data.Model;
using FrameworklessServer.Data.Services;
using FrameworklessServerTests;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
            switch (request.Path)
            {
                case "/" when request.Method == "GET":
                    response = new IndexGreetingResponse();
                    return response.Write(_userService);
                case "/users" when request.Method == "GET":
                    return GetAllUsers();
                case "/users" when request.Method == "POST":
                    return AddUser(ReadBody(request.Body));
                case "/users" when request.Method == "DELETE":
                    return DeleteUser(ReadBody(request.Body).Name);
            }
            if (Regex.IsMatch(request.Path, $"/users/{regex}"))
                return GetNameFromUrl(request.Path);

            response = new InvalidUrlResponse();
            return response.Write(_userService);
        }

        private Response GetNameFromUrl(string url)
        {
            var name = url.Split('/').Last();
            var response = new GetSingleUserResponse(name);
            return response.Write(_userService);
        }

        public Response GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            var newResponse = new Response {Body = JsonSerializer.Serialize(users), StatusCode = HttpStatusCode.OK};
            return newResponse;
        }

        public Response AddUser(User user)
        {
            try
            {
                _userService.Add(user);
                var response = new Response {Body = "User added", StatusCode = HttpStatusCode.OK};
                return response;
            }
            catch (ArgumentNullException e)
            {
                var response = new Response {Body = "", StatusCode = HttpStatusCode.NotFound};
                return response;
            }
        }

        public Response DeleteUser(string name)
        {
            try
            {
                _userService.Delete(name);
                var response = new Response {Body = "User deleted", StatusCode = HttpStatusCode.OK};
                return response;
            }
            catch (ArgumentNullException e)
            {
                var response = new Response {Body = "", StatusCode = HttpStatusCode.NotFound};
                return response;
            }
            catch
            {
                var response = new Response {Body = "", StatusCode = HttpStatusCode.NotFound};
                return response;
            }
        }

        private static User ReadBody(HttpListenerContext context)
        {
            var body = context.Request.InputStream;
            var streamReader = new StreamReader(body, context.Request.ContentEncoding);
            var json = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<User>(json);
        }
    }
}