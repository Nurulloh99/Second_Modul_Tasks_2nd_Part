using _2._2_Lesson.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._2_Lesson.Api.Services;

public class StudentService
{

    public string password = "teacher2024";


    private string studentsFilePath;

    public StudentService()
    {
        studentsFilePath = "../../../Data/Students.json";

        if(File.Exists(studentsFilePath) is false)
        {
            File.WriteAllText(studentsFilePath, "[]");
        }
    }



    public void SaveData(List<Student> students)
    {
        var studentsJson = JsonSerializer.Serialize(students);
        File.WriteAllText(studentsFilePath, studentsJson);
    }


    public List<Student> GetAllStudentsInPrivate()
    {
        var studentsRes = File.ReadAllText(studentsFilePath);
        var studentsJson = JsonSerializer.Deserialize<List<Student>>(studentsRes);
        return studentsJson;
    }


    public Student AddStudent(Student student)
    {
        student.Id = Guid.NewGuid();
        var allStudents = GetAllStudentsInPrivate();

        allStudents.Add(student);
        SaveData(allStudents);
        return student;
    }



    public Student GetById(Guid studentId)
    {
        var allStudents = GetAllStudentsInPrivate();
        foreach (var student in allStudents)
        {
            if(student.Id == studentId)
            {
                return student;
            }
        }
        return null;
    }


    public List<Student> GetAllStudents()
    {
        var allStudents = GetAllStudentsInPrivate();
        return allStudents;
    }



    public bool DeleteStudent(Guid studentId)
    {
        var studentById = GetById(studentId);

        if(studentById is null)
        {
            return false;
        }

        var allStudents = GetAllStudentsInPrivate();
        
        foreach(var student in allStudents)
        {
            if(student.Id == student.Id)
            {
                allStudents.Remove(student);
                break;
            }
        }
        SaveData(allStudents);
        return true;
    }



    public bool UpdateStudent(Student student)
    {
        var studentById = GetById(student.Id);

        if(studentById is null)
        {
            return false;
        }

        var allStudents = GetAllStudentsInPrivate();

        for(var i = 0; i < allStudents.Count; i++)
        {
            if (allStudents[i].Id == studentById.Id)
            {
                allStudents[i] = student;
                break;
            }
        }

        SaveData(allStudents);
        return true;
    }

}
