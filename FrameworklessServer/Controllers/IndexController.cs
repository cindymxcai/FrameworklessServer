using FrameworklessServer.Data.Services;
using FrameworklessServer.ResponseTypes;

namespace FrameworklessServer.Controllers
{
    public class IndexController : IController
    {
        private readonly IUserService _userService;

        public IndexController(IUserService userService)
        {
            _userService = userService;
        }
        public Response HandleRequest(Request request)
        {
            return request.Method == "GET" ? new IndexGreetingResponseType().Write(_userService) : new InvalidUrlResponseType().Write();
        }
    }
}