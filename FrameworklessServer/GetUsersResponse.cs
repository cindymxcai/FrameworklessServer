using System.Linq;
using FrameworklessServerTests;

namespace FrameworklessServer
{
    public class GetUsersResponse : IResponse
    {
        public Response Write(Users users)
        {
            var names = string.Join("\n", users.GetAllUsers().Select(u => u.Name));
            return new Response(names, "200");
        }
    }
}