using Lesson_2._10_Api.DataAccess.Entities;

namespace Lesson_2._10_Api.Repositories;

public interface IStudentRepository
{
    Guid WriteStudent(Student student);
    List<Student> ReadAllStudents();
    Student ReadStudentById(Guid id);
    void MailContains(string mail);
    void RemoveStudent(Guid studentId);
    void UpdateStudent(Student student);
}
