using System.Net;
using System.Net.Http;
using System.Text.Json;
using FrameworklessServerTests;

namespace FrameworklessServer.Controller
{
    public class Controller
    {
        
        //todo define route for this controller. Using router?
        private readonly IUserService _userService;

        public Controller(IUserService userService)
        {
            _userService = userService;
        }

        public Response HandleRequest(Request request)
        {
            if (request.Path == "/users" && request.Method == HttpMethod.Get)
            {

                var allUsers = _userService.GetAllUsers();
                var response = new Response
                {
                    Body = JsonSerializer.Serialize(allUsers),
                    StatusCode = HttpStatusCode.OK
                };
                return response;
            }
            return new Response{StatusCode = HttpStatusCode.NotFound};
        }
    }
}