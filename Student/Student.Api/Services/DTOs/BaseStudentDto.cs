using Student.Api.DataAccess.Enums;

namespace Student.Api.Services.DTOs;

public class BaseStudentDto
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public Degree StudentDegree { get; set; }
    public Gender StudentGender { get; set; }
}
