using _2._7_Lesson.Api.Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace _2._7_Lesson.Api.Repositories;

public class StudentRepository : IStudentRepository
{

    public string _path = "../../../DataAccess/Data/Students.json";
    private List<Student> _students;

    public StudentRepository()
    {
        _students = new List<Student>();

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _students = ReadAllStudents();
    }


    public List<Student> ReadAllStudents()
    {
        var studentJson = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(_path));
        return studentJson;
    }


    public void SaveData()
    {
        File.WriteAllText(_path, JsonSerializer.Serialize(_students));
    }



    public void EmailContains(string email)
    {
        foreach(var student in _students)
        {
            if(student.Email == email)
            {
                throw new Exception("Bunday email mavjud");
            }
        }
    }



    public Student ReadStudentById(Guid studentId)
    {
        foreach(var student in _students)
        {
            if(student.Id == studentId)
            {
                return student;
            }
        }

        return null;
    }


    public void RemovingStudent(Guid studentId)
    {
        _students.Remove(ReadStudentById(studentId));
        SaveData();
    }


    public void UpdatingStudent(Student student)
    {
        _students[_students.IndexOf(ReadStudentById(student.Id))] = student;
        SaveData();
    }

    public Guid WriteStudent(Student student)
    {
        _students.Add(student);
        SaveData();
        return student.Id;
    }
}
