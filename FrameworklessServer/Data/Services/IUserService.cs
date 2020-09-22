using System.Collections.Generic;
using FrameworklessServer.Data.Model;

namespace FrameworklessServer.Data.Services
{
    public interface IUserService
    {
        void Add(User user);

        void Delete(string name);
        List<User> GetAllUsers();
        User Get(string name);
        void UpdateUser(string originalName, string newName);
    }
}