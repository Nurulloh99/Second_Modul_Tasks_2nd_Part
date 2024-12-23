using _2._5_Lesson.Api.DataAccsess.Entities;
using _2._5_Lesson.Api.Repositories;
using _2._5_Lesson.Api.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Lesson.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;

    public UserService()
    {
        _userRepo = new UserRepository();
    }

    private User UserConvertor(UserCreateDto userGetDto)
    {
        var user = new User()
        {
            FirstName = userGetDto.FirstName,
            LastName = userGetDto.LastName,
            Age = userGetDto.Age,
            Email = userGetDto.Email,
            Password = userGetDto.Password,
        };

        return user;
    }




    private UserGetDto UserConvertor(User userGetDto)
    {
        var user = new UserGetDto()
        {
            Id = userGetDto.Id,
            FirstName = userGetDto.FirstName,
            LastName = userGetDto.LastName,
            Age = userGetDto.Age,
            Email = userGetDto.Email,
        };

        return user;
    }





    public UserGetDto AddUser(UserCreateDto user)
    {
        var userCreate = UserConvertor(user);
        userCreate.Id = Guid.NewGuid();
        var checkUser = _userRepo.CheckEmail(user.Email);

        if(checkUser is false || user.Password.Length < 8)
        {
            return null;
        }
        _userRepo.WriteUser(userCreate);
        var userGetDto = UserConvertor(userCreate);
        return userGetDto;

    }

    public bool DeleteUser(Guid userId)
    {
        var useId = _userRepo.RemoveUser(userId);
        return useId; 
    }

    public List<UserGetDto> GetAllUsers()
    {
        var usersGetDtos = new List<UserGetDto>();
        var _users = _userRepo.ReadUsers();

        foreach(var user in _users)
        {
            usersGetDtos.Add(UserConvertor(user));
        }

        return usersGetDtos;
    }

    public UserGetDto GetById(Guid userId)
    {
        var user = _userRepo.ReadUserById(userId);
        var userGet = UserConvertor(user);
        return userGet;
    }

    public bool UpdateUser(UserUpdateDto user)
    {
        var userForUpdate = UserConvertor(user);
        var result = _userRepo.UpdateUser(userForUpdate);
        return result;
    }

    private User UserConvertor(UserUpdateDto user)
    {
        var userBase = new User()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Age = user.Age,
            Email = user.Email,
            Password = user.Password,
        };
        return userBase;
    }
}
