using _2._4_Lesson.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4_Lesson.Api.Services
{
    internal interface ITeacherService
    {
        public Teacher AddTeacher(Teacher teacher);

        public Teacher GetById(Guid teacherID);

        public List<Teacher> GetAllTeachers();

        public bool DeleteTeacher(Guid teacherID);

        public bool UpdateTeacher(Teacher teacher);

        public bool DefineByPhoneNumber(string LoginTeacher, string phoneNumber);
    }
}
