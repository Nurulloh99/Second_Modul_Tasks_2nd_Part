using Student.Api.DataAccess.Entity;
using Student.Api.Services.DTOs;

namespace Student.Api.Repository;

public interface IStudentRepository
{
    Guid WriteStudent(Students student);
    Students ReadStudentById(Guid studentId);
    List<Students> ReadAllStudents();
    void EmailContains(string email);
    void RemoveStudent(Guid studentId);
    void UpdateStudent(Students student);
}
