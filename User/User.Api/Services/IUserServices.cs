using User.Api.Services.DTOs;
using User.Api.Services.Enums;
using User.Api.Services.Enums.EnumStatus;

namespace User.Api.Services;

public interface IUserServices
{
    UserGetDto AddUser(UserCreateDto user);
    UserGetDto GetUserById(Guid userId);
    List<UserGetDto> GetAllUsers();
    void DeleteStudent(Guid userid);
    void UpdateUser(UserUpdateDto user);
    object GetUsersByStudy(UserStudent userStudent);
    object GetUsersByWork(UserWorker userWorker);
    object GetUsersByGender(UserGender userStudent);
}
