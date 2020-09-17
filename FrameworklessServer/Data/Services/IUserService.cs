using System.Collections.Generic;

namespace FrameworklessServer
{
    public interface IUserService
    {
        void Add(User user); //todo check if user already exists

        void Delete(string name);
        void CreateNewJArray(List<User> allUsers);
        List<User> GetAllUsers();
        User Get(string name);
    }
}