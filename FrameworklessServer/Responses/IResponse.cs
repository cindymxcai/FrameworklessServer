using FrameworklessServer.Data.Services;

namespace FrameworklessServer.Responses
{
    public interface IResponse
    {
        Response Write(IUserService usersService);
    }
}