using _2._5_Lesson.Api.DataAccsess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Lesson.Api.Repositories;

public interface IUserRepository
{
    User WriteUser(User name);
    User ReadUserById(Guid userId);
    List<User> ReadUsers();
    bool RemoveUser(Guid userId);
    bool UpdateUser(User user);
    public bool CheckEmail(string email);
}
