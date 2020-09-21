using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FrameworklessServer.Data.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FrameworklessServer.Data.Services
{
    public class UsersService : IUserService
    {
        private readonly User _owner;

        public UsersService()
        {
            _owner = GetAllUsers()[0];
        }
        
        public void Add(User user) 
        {
            var allUsers = GetAllUsers();
            if (user == null)
                throw new ArgumentNullException();

            if (GetAllUsers().Any(u => u.Name == user.Name))
                throw new ArgumentException();

            allUsers.Add(user);
            CreateNewJArray(allUsers);
        }
        
        public void Delete(string name)
        {
            if (name == _owner.Name)
                throw new ArgumentException("Cindy owns this world! Cannot delete");

            var allUsers = GetAllUsers();
            allUsers.Remove(allUsers.First(u => u.Name == name));
            CreateNewJArray(allUsers);
        }

        public void CreateNewJArray(List<User> allUsers)
        {
            var newUsers = allUsers.Select(t => new JObject(new JProperty("Name", t.Name)));
            var newJson = new JArray(newUsers);
            using StreamWriter streamWriter = File.CreateText(Path.Combine(Directory.GetCurrentDirectory(), "UsersList.json" ));
            streamWriter.WriteLine(newJson);
            // var streamWriter = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "UsersList.json" ));
            
        }

        public  List<User> GetAllUsers()
        {
            var streamReader =  new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "UsersList.json"));
            var jsonString = streamReader.ReadToEnd();
           
            streamReader.Close();

            return JsonConvert.DeserializeObject<List<User>>(jsonString);
        }

        public User Get(string name)
        {
            var users = GetAllUsers();
            return users.Find(p => String.Equals(p.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }
        
    }
}