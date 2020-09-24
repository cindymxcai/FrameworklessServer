using FrameworklessServer.Data.Services;
using FrameworklessServer.ResponseTypes;

namespace FrameworklessServer.Controllers
{
    public class InvalidController : IController
    {
        private readonly IUserService _userService;

        public InvalidController(IUserService userService)
        {
            _userService = userService;
        }

        public Response HandleRequest(Request request)
        {
            return InvalidRequest();
        }

        public Response InvalidRequest()
        {
            return new InvalidUrlResponseType().Write(_userService);
        }
    }
}