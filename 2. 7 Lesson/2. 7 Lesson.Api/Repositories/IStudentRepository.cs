using _2._7_Lesson.Api.Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7_Lesson.Api.Repositories;

public interface IStudentRepository
{
    Guid WriteStudent(Student student);
    List<Student> ReadAllStudents();
    Student ReadStudentById(Guid student);
    void EmailContains(string email);
    void RemovingStudent(Guid studentId);
    void UpdatingStudent(Student student);
}
