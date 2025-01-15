using User.Api.DataAccess.Enums.Status;
using User.Api.DataAccess.Enums;

namespace User.Api.Services.DTOs;

public class BaseUserDto
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public Gender StudentGender { get; set; }
    public Study StudentDegree { get; set; }
    public Work StudentJob { get; set; }
}
