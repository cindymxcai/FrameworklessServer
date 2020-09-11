using System;
using System.Collections.Generic;
using System.Linq;

namespace FrameworklessServer
{
    public class Users
    {
        public List<User> AllUsers { get; }
        private readonly User _owner;


        public Users()
        {
            _owner = new User("Cindy");
            AllUsers = new List<User>{_owner};
        }

        public void Add(User user)
        {
            AllUsers.Add(user);
        }

        public void Delete(string name)
        {
            if (name == _owner.Name)
                throw new ArgumentException("Cindy owns this world! Cannot delete");
            var userToDelete = AllUsers.First(p => p.Name == name);
            AllUsers.Remove(userToDelete);

        }
    }
}