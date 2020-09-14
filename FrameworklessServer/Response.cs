namespace FrameworklessServer
{
    public class Response
    {
        public string Body { get; }
        
        public string StatusCode { get; }

        public Response(string body, string statusCode)
        {
            Body = body;
            StatusCode = statusCode;
        }
    }
}