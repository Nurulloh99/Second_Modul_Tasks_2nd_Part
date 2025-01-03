using Lesson_2._10_Api.DataAccess.Enums;
using Lesson_2._10_Api.Services.DTOs;
using Lesson_2._10_Api.Services.Enums;

namespace Lesson_2._10_Api.Services;

public interface IStudentService
{
    StudentGetDto AddStudent(StudentCreateDto student);
    List<StudentGetDto> GetAllStudents();
    StudentGetDto GetStudentById(Guid studentId);
    void DeleteStudent(Guid studentId);
    void UpdateStudent(StudentUpdateDto student);
    List<StudentGetDto> GetStudentsByGender(StudentGender studentSex);
    List<StudentGetDto> GetStudentsByDegree(StudentDegree studentDegree);
}
