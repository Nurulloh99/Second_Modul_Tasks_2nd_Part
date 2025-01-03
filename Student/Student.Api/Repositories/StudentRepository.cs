using System.Text.Json;
using Student.Api.DataAccess.Entities;
using Student.Api.DataAccess.Enums;

namespace Student.Api.Repositories;

public class StudentRepository : IStudentRepository
{
    public string _path = "../../../DataAccess/Data/Students.json";
    private List<Students> _students;

    public StudentRepository()
    {
        _students = new List<Students>();

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _students = ReadAllStudents();
    }

    public void DataSave()
    {
        var studentJson = JsonSerializer.Serialize(_students);
        File.WriteAllText(_path, studentJson);
    }


    public void EmailConsists(string email)
    {
        foreach (var student in _students)
        {
            if (student.Email == email)
            {
                throw new Exception("Bunday email allaqachon yaratilingan!");
            }
        }
    }

    public List<Students> ReadAllStudents()
    {
        var studentJson = JsonSerializer.Deserialize<List<Students>>(File.ReadAllText(_path));
        return studentJson;
    }

    public Students ReadStudentById(Guid studentId)
    {
        foreach (var student in ReadAllStudents())
        {
            if (student.Id == studentId)
            {
                return student;
            }
        }

        return null;
    }

    public void RemoveStudent(Guid studentId)
    {
        var removingStudent = ReadStudentById(studentId);
        _students.Remove(removingStudent);
        DataSave();
    }

    public void UpdateStudent(Students student)
    {
        var index = _students.IndexOf(student);
        _students[index] = student;
        DataSave();
    }

    public Guid WriteStudent(Students student)
    {
        _students.Add(student);
        DataSave();
        return student.Id;
    }
}
