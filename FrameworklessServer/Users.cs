using System.Collections.Generic;

namespace FrameworklessServer
{
    public class Users
    {
        public List<User> AllUsers { get; }

        public Users()
        {
            AllUsers = new List<User>{new User("cindy")};
        }

        public void Add(User user)
        {
            AllUsers.Add(user);
        }
    }
}