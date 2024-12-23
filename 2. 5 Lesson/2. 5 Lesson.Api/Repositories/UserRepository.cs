using _2._5_Lesson.Api.DataAccsess.Entities;
using System.Text.Json;

namespace _2._5_Lesson.Api.Repositories;

public class UserRepository : IUserRepository
{
    private string path;

    private List<User> _users;

    public UserRepository()
    {
        path = "../../../DataAccess/Data/Users.json";
        _users = new List<User>();

        if (File.Exists(path) is false)
        {
            File.WriteAllText(path, "[]");
        }

        _users = ReadAllUsersFromJson();
    }


    private void SaveData()
    {
        var usersJson = JsonSerializer.Serialize(_users);
        File.WriteAllText(path, usersJson);
    }


    private List<User> ReadAllUsersFromJson()
    {
        var usersResult = File.ReadAllText(path);
        var usersJson = JsonSerializer.Deserialize<List<User>>(usersResult);

        return usersJson;
    }


    public User WriteUser(User name)
    {
        name.Id = Guid.NewGuid();

        _users.Add(name);
        SaveData();
        return name;
    }


    public User ReadUserById(Guid userId)
    {
        foreach (var user in _users)
        {
            if (user.Id == userId)
            {
                return user;
            }
        }
        return null;
    }


    public List<User> ReadUsers()
    {
        return _users;
    }



    public bool RemoveUser(Guid userId)
    {
        var removingUser = ReadUserById(userId);

        if (removingUser is null)
        {
            return false;
        }

        _users.Remove(removingUser);
        SaveData();
        return true;
    }


    public bool UpdateUser(User user)
    {
        var updatingUser = ReadUserById(user.Id);

        if (updatingUser is null)
        {
            return false;
        }

        var index = _users.IndexOf(updatingUser);
        _users[index] = user;
        SaveData();
        return true;
    }

    public bool CheckEmail(string email)
    {
        foreach (var user in _users)
        {
            if (user.Email == email || email.EndsWith("@gmail.com") is false)
            {
                return false;
            }
        }
        return true;
    }
}