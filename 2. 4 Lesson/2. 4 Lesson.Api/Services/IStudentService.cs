using _2._4_Lesson.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4_Lesson.Api.Services;

public interface IStudentService
{
    public Student AddStudent(Student student);

    public Student GetById(Guid studentID);

    public List<Student> GetAllStudents();

    public bool DeleteStudent(Guid studentID);

    public bool UpdateStudent(Student studnet);

    public bool DefineByPhoneNumber(string loginTeacher, string phoneNumber);
}
