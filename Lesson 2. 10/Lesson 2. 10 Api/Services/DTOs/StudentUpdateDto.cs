namespace Lesson_2._10_Api.Services.DTOs

{
    public class StudentUpdateDto : BaseStudentDto
    {
        public Guid Id { get; set; }
        public string Password { get; set; }

    }
}
