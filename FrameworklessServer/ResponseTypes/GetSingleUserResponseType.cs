using System.Net;
using FrameworklessServer.Data.Services;

namespace FrameworklessServer.ResponseTypes
{
    
    public class GetSingleUserResponseType 
    {
        private readonly string _name;

        public GetSingleUserResponseType(string name)
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