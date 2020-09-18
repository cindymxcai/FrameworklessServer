using FrameworklessServer;

namespace FrameworklessServerTests
{
    public interface IResponse
    {
        Response Write(IUserService usersService);
    }
}