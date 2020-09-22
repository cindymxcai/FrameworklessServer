using System.Linq;
using System.Net;
using FrameworklessServer.Data.Services;
using FrameworklessServerTests;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FrameworklessServer
{
    public class GetUsersResponse : IResponse
    {
        public  Response Write(IUserService usersService)
        {
            return new Response{Body = JsonSerializer.Serialize(usersService.GetAllUsers()), StatusCode = HttpStatusCode.OK};
        }
    }
}