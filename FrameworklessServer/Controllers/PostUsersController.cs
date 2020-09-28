using System;
using System.IO;
using System.Net;

namespace FrameworklessServer.Controllers
{
    public class PostUsersController : IController
    {
        public Response HandleRequest(Request request)
        {
            var form = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Edit.html"));
            return new Response {Body = form, StatusCode = HttpStatusCode.OK};
        }
    }
}