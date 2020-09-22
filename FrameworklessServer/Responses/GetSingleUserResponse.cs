using System.Net;
using FrameworklessServer.Data.Services;

namespace FrameworklessServer.Responses
{
    
    public class GetSingleUserResponse : IResponse
    {
        private readonly string _name;

        public GetSingleUserResponse(string name)
        {
            _name = name;
        }

        public Response Write(IUserService usersService)
        {
            var user = usersService.Get(_name);
            return new Response{Body = user.Name, StatusCode = HttpStatusCode.OK};
        }
        
    }
}