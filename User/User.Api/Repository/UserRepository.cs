using System.Text.Json;
using User.Api.DataAccess.Entities;

namespace User.Api.Repository
{
    public class UserRepository : IUserRepository
    {
        public string _path = "../../../DataAccess/Data/Users.json";
        private List<Users> _users;

        public UserRepository()
        {
            _users = new List<Users>();

            if (!File.Exists(_path))
            {
                File.WriteAllText(_path, "[]");
            }

            _users = ReadAllUsers();
        }

        public void SaveData()
        {
            var userJson = JsonSerializer.Serialize(_users);
            File.WriteAllText(_path, userJson);
        }

        public void EmailConsist(string email)
        {
            foreach (var user in _users)
            {
                if(object.Equals(user.EmailAddress, email))
                {
                    throw new Exception("Bunday email allaqachon ochilgan");
                }
            }
        }

        public List<Users> ReadAllUsers()
        {
            var userRes = File.ReadAllText(_path);
            var userJson = JsonSerializer.Deserialize<List<Users>>(userRes);
            return userJson;
        }

        public Users ReadUserById(Guid userr)
        {
            foreach (var user in _users)
            {
                if (object.Equals(user.Id, userr))
                {
                    return user;
                }
            }

            return null;
        }

        public void RemoveUser(Guid userId)
        {
            var findUser = ReadUserById(userId);
            _users.Remove(findUser);
            SaveData();
        }

        public void UpdateUser(Users user)
        {
            var findUser = ReadUserById(user.Id);
            var index = _users.IndexOf(findUser);
            _users[index] = user;  
            SaveData();
        }

        public Guid WriteUser(Users users)
        {
            _users.Add(users);
            SaveData();
            return users.Id;
        }
    }
}
