using System.Linq;
using System.Net;
using FrameworklessServerTests;

namespace FrameworklessServer
{
    public class GetUsersResponse : IResponse
    {
        public Response Write(UsersService usersService)
        {
            var names = string.Join("\n", usersService.GetAllUsers().Select(u => u.Name));
            return new Response{Body = names, StatusCode = HttpStatusCode.OK};
        }
    }
}