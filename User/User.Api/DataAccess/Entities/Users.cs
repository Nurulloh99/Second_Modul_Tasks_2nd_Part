using User.Api.DataAccess.Enums;
using User.Api.DataAccess.Enums.Status;

namespace User.Api.DataAccess.Entities;

public class Users
{
    public Guid Id { get; set; }
    public  string FirstName { get; set; }
    public  string SecondName { get; set; }
    public int Age { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public Gender StudentGender { get; set; }
    public Study StudentDegree { get; set; }
    public Work StudentJob { get; set; }
}
