using Student.Api.DataAccess.Enums;

namespace Student.Api.DataAccess.Entities;

public class Students
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Degree StudentDegree { get; set; }
    public Gender StudentGender { get; set; }
}
