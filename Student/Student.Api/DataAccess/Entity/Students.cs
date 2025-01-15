using Student.Api.DataAccess.Enums;

namespace Student.Api.DataAccess.Entity;

public class Students
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Degree StatusDegree { get; set; }
    public Gender StatusGender { get; set; }
}
