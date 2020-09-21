using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FrameworklessServer.Data.Model;
using FrameworklessServer.Data.Services;
using FrameworklessServerTests;

namespace FrameworklessServer
{
    public class IndexGreetingResponse : IResponse
    {
        public  Response Write(IUserService usersService)
        {
            var responseBody = FormatBody(usersService.GetAllUsers());
            return new Response{Body = responseBody, StatusCode = HttpStatusCode.OK};
        }

        private  string FormatBody(List<User> users)
        {
            var names = users.Select(user => user.Name).ToList();
            var formattedNames = FormatNames(names);

            var time = $"{ DateTime.Now.ToShortTimeString()}";
            var date = $"{DateTime.Now.ToLongDateString()}";

            return $"Hello {formattedNames} - the time on the server is {time} on {date}";
        }
        
        private static string FormatNames(IReadOnlyCollection<string> users)
        {
            return users.Count switch
            {
                0 => throw new InvalidOperationException(),
                1 => users.First(),
                2 => $"{users.First()} and {users.Last()}",
                _ => $"{string.Join(", ", users.ToArray(), 0, users.Count-1)}, and {users.Last()}"
            };
        }

    }
}