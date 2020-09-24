using System;
using System.IO;
using System.Linq;
using System.Net;
using FrameworklessServer.Data.Model;
using FrameworklessServer.Data.Services;
using FrameworklessServer.ResponseTypes;
using Newtonsoft.Json;

namespace FrameworklessServer.Controllers
{
    public class SingleUserController : IController
    {
        private readonly IUserService _userService;

        public SingleUserController(IUserService userService)
        {
            _userService = userService;
        }

        public Response HandleRequest(Request request)
        {
            return request.Method == "PUT" ? UpdateUser(request.Path.Split("/").Last(), ReadBody(request.Body).Name) : GetNameFromUrl(request.Path);
        }
        
        private static User ReadBody(HttpListenerContext context)
        {
            var body = context.Request.InputStream;
            var streamReader = new StreamReader(body, context.Request.ContentEncoding);
            var json = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<User>(json);
        }

        public Response UpdateUser(string originalName, string newName)
        {
            try
            {
                _userService.UpdateUser(originalName, newName);
                return new Response{Body = "User Updated", StatusCode = HttpStatusCode.NoContent};

            }
            catch (Exception e)
            {
                return new Response{Body = e.Message, StatusCode = HttpStatusCode.NotFound};
            }
          
        }

        public Response GetNameFromUrl(string url)
        {
            var name = url.Split('/').Last();
            var response = new GetSingleUserResponseType(name);
            return response.Write(_userService);
        }

    }
}