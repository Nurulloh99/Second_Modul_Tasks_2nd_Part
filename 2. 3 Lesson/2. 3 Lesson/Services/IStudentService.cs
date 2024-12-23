using _2._3_Lesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3_Lesson.Services;

public interface IStudentService
{
    public Student AddStudent(Student student);

    public Student GetById(Guid studentId);

    public List<Student> GetAllStudents();

    public bool DeleteStudent(Guid studentId);

    public bool UpdateStudent(Student student);
}
