using System.Net;
using FrameworklessServerTests;

namespace FrameworklessServer
{
    
    public class GetSingleUserResponse : IResponse
    {
        private readonly string _name;

        public GetSingleUserResponse(string name)
        {
            _name = name;
        }

        public Response Write(UsersService usersService)
        {
            var user = usersService.Get(_name);
            return new Response{Body = user.Name, StatusCode = HttpStatusCode.OK};
        }
    }
}