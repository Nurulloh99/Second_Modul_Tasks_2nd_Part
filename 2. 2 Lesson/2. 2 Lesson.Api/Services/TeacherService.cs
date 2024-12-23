using _2._2_Lesson.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._2_Lesson.Api.Services;

public class TeacherService
{
    public string password = "director2024";

    public string secondPassword = "director2024";


    private string teachersFilePath;

    public TeacherService()
    {
        teachersFilePath = "../../../Data/Teachers.json";

        if(File.Exists(teachersFilePath) is false)
        {
            File.WriteAllText(teachersFilePath, ".");
        }
    }


    public void Savedata(List<Teacher> teachers)
    {
        var teachersJson = JsonSerializer.Serialize(teachers);
        File.WriteAllText(teachersFilePath, teachersJson);
    }



    public List<Teacher> GetAllTeachersInJson()
    {
        var teacherReasult = File.ReadAllText(teachersFilePath);
        var teachersJson = JsonSerializer.Deserialize<List<Teacher>>(teacherReasult);
        return teachersJson;
    }


    public Teacher AddTeacher(Teacher teacher)
    {
        teacher.Id = Guid.NewGuid();

        var allTeachers = GetAllTeachersInJson();
        allTeachers.Add(teacher);
        Savedata(allTeachers);

        return teacher;
    }



    public Teacher GetById(Guid teacherId)
    {
        var allTeachers = GetAllTeachersInJson();

        foreach (var teacher in allTeachers)
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
        var allTeachers = GetAllTeachersInJson();
        return allTeachers;
    }



    public bool DeleteTeacher(Guid teacherID)
    {
        var teacherById = GetById(teacherID);

        if(teacherById is null)
        {
            return false;
        }

        var allTeachers = GetAllTeachersInJson();

        foreach(var teacher in allTeachers)
        {
            if(teacher.Id == teacherID)
            {
                allTeachers.Remove(teacher);
                break;
            }
        }

        Savedata(allTeachers);
        return true;
    }



    public bool UpdateTeacher(Teacher teacher)
    {
        var teacherById = GetById(teacher.Id);

        if(teacherById is null)
        {
            return false;
        }

        var allTeachers = GetAllTeachersInJson();

        for(var i = 0; i < allTeachers.Count; i++)
        {
            if (allTeachers[i].Id == teacher.Id)
            {
                allTeachers[i] = teacher;
                break;
            }
        }

        Savedata(allTeachers);
        return true;
    }


}