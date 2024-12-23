using _2._8_Lesson.Api.DataAccess.Enums;

namespace _2._8_Lesson.Api.DataAccess.Entities;

public class School
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int MyProperty { get; set; }
    public int Rating { get; set; }
    public string Description { get; set; }
    public int StudentsCount { get; set; }
    public string Password { get; set; }
    public Gender MaleFemale { get; set; }
}
