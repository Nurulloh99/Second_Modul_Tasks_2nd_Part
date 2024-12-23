using _2._5_Lesson.Api.Services.DTOs;

namespace _2._5_Lesson.Api.Services;

public interface IUserService
{
    UserGetDto AddUser(UserCreateDto user);
    UserGetDto GetById(Guid userId);
    public List<UserGetDto> GetAllUsers();
    bool DeleteUser(Guid userId);
    bool UpdateUser(UserUpdateDto user);
}