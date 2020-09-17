using FrameworklessServer;

namespace FrameworklessServerTests
{
    public interface IResponse
    {
        Response Write(UsersService usersService);
    }
}