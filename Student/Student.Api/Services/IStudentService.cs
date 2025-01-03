using Student.Api.Services.DTOs;
using Student.Api.Services.Enums;

namespace Student.Api.Services;

public interface IStudentService
{
    StudentGetDto AddStudent(StudentCreateDto studentDto);
    StudentGetDto GetStudentById(Guid studentDto);
    List<StudentGetDto> GetAllStudents();
    void DeleteStudent(Guid deletingStudent);
    void UpdateStudent(StudentUpdateDto studentDto);
    object GetStudentByDegree(StudentDegree degree);
    object GetStudentByGender(StudentGender gender);
}
