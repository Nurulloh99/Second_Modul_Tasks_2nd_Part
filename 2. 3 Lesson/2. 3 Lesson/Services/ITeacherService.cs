using _2._3_Lesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3_Lesson.Services;

public interface ITeacherService
{
    public Teacher AddTeacher(Teacher teacher);

    public Teacher GetById(Guid teacherId);

    public List<Teacher> GetAllTeachers();

    public bool DeleteTeacher(Guid teacherId);

    public bool UpdateTeacher(Teacher teacher);
}
