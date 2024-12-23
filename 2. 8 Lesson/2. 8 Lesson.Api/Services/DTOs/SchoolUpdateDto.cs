namespace _2._8_Lesson.Api.Services.DTOs;

public class SchoolUpdateDto : BaseSchoolDto
{
    public Guid Id { get; set; }
    public string Password { get; set; }
}
