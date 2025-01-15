using User.Api.DataAccess.Entities;
using User.Api.Repository;
using User.Api.Services.DTOs;
using User.Api.Services.Enums;
using User.Api.Services.Enums.EnumStatus;

namespace User.Api.Services.Extensions;

public static class ExtensionForUserStudy
{
    public static IUserRepository userRepos;

    static ExtensionForUserStudy()
    {
        userRepos = new UserRepository();
    }

    public static object GetUsersByGender(this UserGender userStudent)
    {
        var getAllStudents = userRepos.ReadAllUsers();
        var allUsers = new List<UserGetDto>();

        foreach (var user in getAllStudents)
        {
            if (object.Equals(user.StudentGender, userStudent))
            {
                allUsers.Add(ConvertUser(user));
            }
        }

        return allUsers;
    }

    private static UserGetDto ConvertUser(Users user)
    {
        return new UserGetDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            SecondName = user.SecondName,
            Age = user.Age,
            PhoneNumber = user.PhoneNumber,
            EmailAddress = user.EmailAddress,
            StudentDegree = user.StudentDegree,
            StudentGender = user.StudentGender,
            StudentJob = user.StudentJob,
        };
    }
}

