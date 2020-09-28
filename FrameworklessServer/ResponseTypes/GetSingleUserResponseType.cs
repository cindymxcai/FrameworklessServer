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
            return usersService.Get(_name) != null ? new Response{Body = usersService.Get(_name).Name, StatusCode = HttpStatusCode.OK} : new InvalidUrlResponseType().Write();
        }
    }
}