using _2._3_Lesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._3_Lesson.Services;

public class TeacherService : ITeacherService
{
    private string teacherFilePath;

    private List<Teacher> _teachers;

    public TeacherService()
    {
        _teachers = new List<Teacher>();

        teacherFilePath = "../../../Data/Teachers.json";

        if(File.Exists(teacherFilePath) is false)
        {
            File.WriteAllText(teacherFilePath, "[]");
        }
        _teachers = GetAllTeachersFromJson();
    }
    


    public void DataSave()
    {
        var teacherJson = JsonSerializer.Serialize(teacherFilePath);
        File.WriteAllText(teacherFilePath, teacherJson);
    }



    public List<Teacher> GetAllTeachersFromJson()
    {
        var teacherResult = File.ReadAllText(teacherFilePath);
        var teacherDesrialize = JsonSerializer.Deserialize<List<Teacher>>(teacherResult);
        return teacherDesrialize;
    }



    public Teacher AddTeacher(Teacher teacher)
    {
        teacher.Id = Guid.NewGuid();
        _teachers.Add(teacher);
        DataSave();
        return teacher;
    }




    public Teacher GetById(Guid teacherId)
    {
        foreach(var teacher in _teachers)
        {
            if(teacher.Id == teacherId)
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




    public bool DeleteTeacher(Guid teacherId)
    {
        var teachers = GetById(teacherId);

        if(teachers is null)
        {
            return false;
        }

        _teachers.Remove(teachers);
        DataSave();
        return true;
    }



    public bool UpdateTeacher(Teacher teacher)
    {
        var teachers = GetById(teacher.Id);

        if(teachers is null)
        {
            return false;
        }

        var index = _teachers.IndexOf(teachers);
        _teachers[index] = teacher;
        DataSave();
        return true;
    }











}
