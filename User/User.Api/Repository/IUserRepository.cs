using User.Api.DataAccess.Entities;

namespace User.Api.Repository;

public interface IUserRepository
{
    Guid WriteUser(Users users);
    Users ReadUserById(Guid user);
    void EmailConsist(string email);
    List<Users> ReadAllUsers();
    void RemoveUser(Guid userId);
    void UpdateUser(Users user);
}
