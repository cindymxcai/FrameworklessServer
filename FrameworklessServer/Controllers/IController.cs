namespace FrameworklessServer.Controllers
{
    public interface IController
    {
        Response HandleRequest(Request request);
    }
}