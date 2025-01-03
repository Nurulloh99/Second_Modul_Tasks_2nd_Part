using Student.Api.DataAccess.Entities;
using Student.Api.DataAccess.Enums;

namespace Student.Api.Repositories;

public interface IStudentRepository
{
    Guid WriteStudent(Students student);
    Students ReadStudentById(Guid studentId);
    List<Students> ReadAllStudents();
    void EmailConsists(string email);
    void RemoveStudent(Guid studentId);
    void UpdateStudent(Students student);
    void EmailConsists(Students newStudent);
}
