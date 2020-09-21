using FrameworklessServer;
using FrameworklessServer.Data.Services;

namespace FrameworklessServerTests
{
    public interface IResponse
    {
        Response Write(IUserService usersService);
    }
}