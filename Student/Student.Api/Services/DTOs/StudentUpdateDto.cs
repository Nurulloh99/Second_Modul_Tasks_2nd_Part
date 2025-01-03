namespace Student.Api.Services.DTOs;

public class StudentUpdateDto : BaseStudentDto
{
    public Guid Id { get; set; }
    public string Password { get; set; }
}
