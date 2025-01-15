using Student.Api.Services.DTOs;
using Student.Api.Services.Enums;

namespace Student.Api.Services;

public interface IStudentService
{
    StudentGetDto AddStudent(StudentCreateDto student);
    StudentGetDto GetStudentById(Guid studentId);
    List<StudentGetDto> GetAllStudents();
    void DeleteStudent(Guid studentId);
    void UpdateStudent(StudentUpdateDto student);
    object ReadAllStudentsByDegree(StudentDegree studentDegree);
    object ReadAllStudentsByGender(StudentGender studentGender);
}
