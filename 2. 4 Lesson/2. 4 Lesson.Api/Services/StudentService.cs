using _2._4_Lesson.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._4_Lesson.Api.Services;

public class StudentService : IStudentService
{
    private string studentFilePath;
    private List<Student> _students;

    public string studentPassword = "student";

    public StudentService()
    {
        _students = new List<Student>();
        studentFilePath = "../../../Data/Students.json";

        if(File.Exists(studentFilePath) is false)
        {
            File.WriteAllText(studentFilePath, "[]");
        }

        _students = GetAllTeachersFromJson();
    }

    public void DataSave()
    {
        var teacherJson = JsonSerializer.Serialize(_students);
        File.WriteAllText(studentFilePath, teacherJson);
    }

    public List<Student> GetAllTeachersFromJson()
    {
        var teacherReading = File.ReadAllText(studentFilePath);
        var teacherJson = JsonSerializer.Deserialize<List<Student>>(teacherReading);
        return teacherJson;
    }

    public Student AddStudent(Student student)
    {
        student.Id = Guid.NewGuid();
        _students.Add(student);
        DataSave();
        return student;
    }

    public Student GetById(Guid studentID)
    {
        foreach(var student in _students)
        {
            if(student.Id == studentID)
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

    public bool DeleteStudent(Guid studentID)
    {
        var deletingStudent = GetById(studentID);

        if(deletingStudent is null)
        {
            return false;
        }

        _students.Remove(deletingStudent);
        DataSave();
        return true;
    }

    public bool UpdateStudent(Student student)
    {
        var updatingStudent = GetById(student.Id);

        if(updatingStudent is null)
        {
            return false;
        }

        var index = _students.IndexOf(updatingStudent);
        _students[index] = student;
        DataSave();
        return true;
    }

    public bool DefineByPhoneNumber(string loginStudent, string phoneNumber)
    {
        foreach(var student in _students)
        {
            if(loginStudent == student.UserName && phoneNumber == student.PhoneNumber)
            {
                return true;
            }
        }

        return false;
    }
}
