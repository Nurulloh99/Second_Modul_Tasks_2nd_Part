using Lesson_2._10_Api.DataAccess.Enums;

namespace Lesson_2._10_Api.DataAccess.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public int Age { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    public Gender MaleFemale { get; set; }
    public Degree DegreeStatus { get; set; }
}
