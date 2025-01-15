using User.Api.DataAccess.Entities;
using User.Api.Repository;
using User.Api.Services.DTOs;
using User.Api.Services.Enums;
using User.Api.Services.Enums.EnumStatus;

namespace User.Api.Services;

public class UserServices : IUserServices
{
    public IUserRepository userRepo;

    public UserServices()
    {
        userRepo = new UserRepository();
    }


    public UserGetDto AddUser(UserCreateDto user)
    {
        ValidateUserCreateDto(user);
        var newUser = ConvertUser(user);
        newUser.Id = Guid.NewGuid();
        userRepo.EmailConsist(newUser.EmailAddress);
        userRepo.WriteUser(newUser);
        return ConvertUser(newUser);
    }

    public void DeleteStudent(Guid userId)
    {
        userRepo.RemoveUser(userId);
    }
    
    public List<UserGetDto> GetAllUsers()
    {
        var getAllUsers = userRepo.ReadAllUsers();
        var allUsers = new List<UserGetDto>();

        foreach (var user in getAllUsers)
        {
            allUsers.Add(ConvertUser(user));
        }

        return allUsers;
    }

    public UserGetDto GetUserById(Guid userId)
    {
        var getUser = userRepo.ReadUserById(userId);
        return ConvertUser(getUser);
    }

    public object GetUsersByGender(UserGender userStudent)   //  QWERTY
    {
        var getAllStudents = userRepo.ReadAllUsers();
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

    public object GetUsersByStudy(UserStudent userStudent)
    {
        var getAllStudents = userRepo.ReadAllUsers();
        var allUsers = new List<UserGetDto>();

        foreach (var user in getAllStudents)
        {
            if(object.Equals(user.StudentDegree, userStudent))
            {
                allUsers.Add(ConvertUser(user));
            }
        }

        return allUsers;
    }

    public object GetUsersByWork(UserWorker userWorker)
    {
        var getAllStudents = userRepo.ReadAllUsers();
        var allUsers = new List<UserGetDto>();

        foreach(var user in getAllStudents)
        {
            if(object.Equals(user.StudentJob, userWorker))
            {
                allUsers.Add(ConvertUser(user));
            }
        }

        return allUsers;
    }

    public void UpdateUser(UserUpdateDto user)
    {
        userRepo.UpdateUser(ConvertUser(user));
    }

    private Users ConvertUser(UserCreateDto user)
    {
        return new Users
        {
            FirstName = user.FirstName,
            SecondName = user.SecondName,
            Age = user.Age,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber,
            EmailAddress = user.EmailAddress,
            StudentDegree = user.StudentDegree,
            StudentGender = user.StudentGender,
            StudentJob = user.StudentJob,
        };
    }


    private Users ConvertUser(UserUpdateDto user)
    {
        return new Users
        {
            FirstName = user.FirstName,
            SecondName = user.SecondName,
            Age = user.Age,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber,
            EmailAddress = user.EmailAddress,
            StudentDegree = user.StudentDegree,
            StudentGender = user.StudentGender,
            StudentJob = user.StudentJob,
        };
    }


    private UserGetDto ConvertUser(Users user)
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


    private void ValidateUserCreateDto(UserCreateDto user)
    {
        if(string.IsNullOrEmpty(user.FirstName) || user.FirstName.Length < 50)
        {
            throw new Exception("Ismdagi xatolik!");
        }

        if(string.IsNullOrEmpty(user.SecondName) || user.SecondName.Length < 50)
        {
            throw new Exception("Familiyadagi xatolik!");
        }

        if(user.Age > 12 || user.Age < 150)
        {
            throw new Exception("Yoshdagi xatolik");
        }

        if(user.PhoneNumber.StartsWith("+998") || user.PhoneNumber.Length < 5)
        {
            throw new Exception("Tel raqamdagi xatolik");
        }

        if(user.EmailAddress.EndsWith("@gmail.com") || user.EmailAddress.Length < 10)
        {
            throw new Exception("Emaildagi xatolik");
        }
    }
}
