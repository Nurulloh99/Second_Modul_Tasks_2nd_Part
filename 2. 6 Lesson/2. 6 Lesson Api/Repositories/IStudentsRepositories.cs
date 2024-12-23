using _2._6_Lesson_Api.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6_Lesson_Api.Repositories;

public interface IStudentsRepositories
{
    Guid WriteStudent(Student student);
    List<Student> ReadAllStudents();
    Student ReadStudentById(Guid studentId);
    void RemoveStudent(Guid studentId);
    void UpdateStudent(Student student);
    void EmailContains(string email);
}
