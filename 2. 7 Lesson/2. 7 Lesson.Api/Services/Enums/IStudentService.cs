using _2._7_Lesson.Api.Services.DTOs;

namespace _2._7_Lesson.Api.Services.Enums;

public interface IStudentService
{
    StudentGetDto AddStudentDto(StudentCreateDto student);
    StudentGetDto GetStudentById(Guid studentId);
    List<StudentGetDto> GetAllStudents();
    void DeleteStudent(Guid studentId);
    void UpdateStudent(StudentUpdateDto student);
    List<StudentGetDto> GetStudentsByGender(GenderDto studentGender);
    List<StudentGetDto> GetStudentsByDegree(DegreeStatusDto studentDegree);
}
