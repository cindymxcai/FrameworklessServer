using FrameworklessServerTests;

namespace FrameworklessServer
{
    public class GetSingleUserResponse : IResponse
    {
        private readonly string _name;

        public GetSingleUserResponse(string name)
        {
            _name = name;
        }

        public Response Write(Users users)
        {
            var user = users.Get(_name);
            return new Response(user.Name, "200");
        }
    }
}