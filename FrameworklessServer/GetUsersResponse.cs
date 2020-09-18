using System.Linq;
using System.Net;
using FrameworklessServerTests;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FrameworklessServer
{
    public class GetUsersResponse : IResponse
    {
        public  Response Write(IUserService usersService)
        {
            var names = string.Join("\n", usersService.GetAllUsers().Select(u => u.Name));
            return new Response{Body = JsonSerializer.Serialize(usersService.GetAllUsers()), StatusCode = HttpStatusCode.OK};
        }
    }
}