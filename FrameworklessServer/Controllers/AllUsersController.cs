using System;
using System.IO;
using System.Linq;
using System.Net;
using FrameworklessServer.Data.Model;
using FrameworklessServer.Data.Services;
using FrameworklessServer.ResponseTypes;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FrameworklessServer.Controllers
{
    public class AllUsersController : IController
    {
        private readonly IUserService _userService;

        public AllUsersController(IUserService userService)
        {
            _userService = userService;
        }
        public Response HandleRequest(Request request)
        {
            switch (request.Method)
            {
                case "GET": return GetAllUsers();
                case "POST": return AddUser(ReadBody(request.Body));
                case "DELETE": return DeleteUser(ReadBody(request.Body).Name); 
            }
            return new InvalidUrlResponseType().Write();
        }
        
        private static User ReadBody(HttpListenerContext context)
        {
            var body = context.Request.InputStream;
            var streamReader = new StreamReader(body, context.Request.ContentEncoding);
            var rawData = streamReader.ReadToEnd(); 
            return new User(rawData.Split("=").Last());
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
                var response = new Response {Body = e.Message, StatusCode = HttpStatusCode.NotFound};
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
            catch (InvalidOperationException e)
            {
                var response = new Response {Body = e.Message, StatusCode = HttpStatusCode.NotFound};
                return response;
            }
        }
    }
}