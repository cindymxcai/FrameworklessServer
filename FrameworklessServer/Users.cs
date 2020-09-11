using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FrameworklessServer
{
    public class Users
    {
        private readonly User _owner;

        public Users()
        {
            _owner = GetAllUsers()[0];
        }

        public void Add(User user)
        {
            var allUsers = GetAllUsers();
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
            var streamWriter = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "UsersList.json"));
            streamWriter.WriteLine(newJson);
            
            streamWriter.Close();
        }

        public List<User> GetAllUsers()
        {
            var streamReader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "UsersList.json"));
            var jsonString = streamReader.ReadToEnd();
           
            streamReader.Close();

            return JsonConvert.DeserializeObject<List<User>>(jsonString);
        }

        public User Get(string name)
        {
            var users = GetAllUsers();
            return users.Find(p => p.Name == name);
        }
    }
}