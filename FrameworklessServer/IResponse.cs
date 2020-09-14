using FrameworklessServer;

namespace FrameworklessServerTests
{
    public interface IResponse
    {
        Response Write(Users users);
    }
}