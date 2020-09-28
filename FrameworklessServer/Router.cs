using System.Linq;
using System.Text.RegularExpressions;
using FrameworklessServer.Controllers;
using FrameworklessServer.Data.Services;

namespace FrameworklessServer
{
    public class Router
    {
        private readonly IUserService _userService;
        const string NameMatch = @"\w+";

        public Router(IUserService userService)
        {
            _userService = userService;
        }
        public IController GetController(string path)
        {
            return path switch
            {
                "/" => new IndexController(_userService),
                "/users"  => new AllUsersController(_userService),
                "/post" => new PostUsersController(),
                _ when Regex.IsMatch(path, $"/users/{NameMatch}") => GetNameFromUrl(),
                _ => new InvalidController(_userService)
            };
        }
        
        private IController GetNameFromUrl()
        {
            return new SingleUserController(_userService);
        }
    }
}