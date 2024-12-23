using _2._3_Lesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._3_Lesson.Services;

public class StudentService : IStudentService
{
    private string studentFilePath;

    private List<Student> _students;

    public StudentService()
    {
        _students = new List<Student>();

        studentFilePath = "../../../Data/Students.json";

        if (File.Exists(studentFilePath) is false)
        {
            File.WriteAllText(studentFilePath, "[]");
        }
        _students = GetStudentsFromJson();
    }


    private void DataSave()
    {
        var studentJson = JsonSerializer.Serialize(_students);
        File.WriteAllText(studentFilePath, studentJson);
    }


    private List<Student> GetStudentsFromJson()
    {
        var studentResult = File.ReadAllText(studentFilePath);
        var studentsJson = JsonSerializer.Deserialize<List<Student>>(studentResult);
        return studentsJson;
    }


    public Student AddStudent(Student student)
    {
        student.Id = Guid.NewGuid();
        _students.Add(student);
        DataSave();
        return student;
    }


    public Student GetById(Guid studentId)
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



    public List<Student> GetAllStudents()
    {
        return _students;
    }


    public bool DeleteStudent(Guid studentId)
    {
        var student = GetById(studentId);

        if(student is null)
        {
            return false;
        }

        _students.Remove(student);
        DataSave();
        return true;
    }


    public bool UpdateStudent(Student student)
    {
        var students = GetById(student.Id);

        if(students is null)
        {
            return false;
        }

        var index = _students.IndexOf(students);
        _students[index] = student;
        DataSave();
        return true;
    }
}
