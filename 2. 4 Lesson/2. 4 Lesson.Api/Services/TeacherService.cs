using _2._4_Lesson.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._4_Lesson.Api.Services;

public class TeacherService : ITeacherService
{
    private string teacherFilePath;
    private List<Teacher> _teachers;
    Teacher teacher = new Teacher();


    public TeacherService()
    {
        _teachers = new List<Teacher>();
        teacherFilePath = "../../../Data/Teachers.json";

        if (File.Exists(teacherFilePath) is false)
        {
            File.WriteAllText(teacherFilePath, "[]");
        }

        _teachers = GetAllTeachersFromJson();
    }

    public void DataSave()
    {
        var teacherJson = JsonSerializer.Serialize(_teachers);
        File.WriteAllText(teacherFilePath, teacherJson);
    }

    public List<Teacher> GetAllTeachersFromJson()
    {
        var teacherResult = File.ReadAllText(teacherFilePath);
        var teacherJsonRes = JsonSerializer.Deserialize<List<Teacher>>(teacherResult);
        return teacherJsonRes;
    }

    public Teacher AddTeacher(Teacher teacher)
    {
        teacher.Id = Guid.NewGuid();
        _teachers.Add(teacher);
        DataSave();
        return teacher;
    }

    public Teacher GetById(Guid teacherID)
    {
        foreach(var teacher in _teachers)
        {
            if(teacher.Id == teacherID)
            {
                return teacher;
            }
        }
        return null;
    }

    public List<Teacher> GetAllTeachers()
    {
        return _teachers;
    }

    public bool DeleteTeacher(Guid teacherID)
    {
        var deletingTeacher = GetById(teacherID);

        if(deletingTeacher is null)
        {
            return false;
        }

        _teachers.Remove(deletingTeacher);
        DataSave();
        return true;
    }

    public bool UpdateTeacher(Teacher teacher)
    {
        var updatingTeacher = GetById(teacher.Id);

        if(updatingTeacher is null)
        {
            return false;
        }

        var index = _teachers.IndexOf(updatingTeacher);
        _teachers[index] = teacher;
        DataSave();
        return true;
    }

    public bool DefineByPhoneNumber(string LoginTeacher, string phoneNumber)
    {
        foreach(var teacher in _teachers)
        {
            if(LoginTeacher == teacher.UserName && phoneNumber == teacher.PhoneNumber)
            {
                return true;
            }
        }
        return false;
    }
}
