using System.Text.Json;
using Student.Api.DataAccess.Entity;

namespace Student.Api.Repository;

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

    public void SaveData()
    {
        var studentJson = JsonSerializer.Serialize(_students);
        File.WriteAllText(_path, studentJson);
    }

    public void EmailContains(string email)
    {
        foreach (var student in _students)
        {
            if(student.Email == email)
            {
                throw new Exception("Error");
            }
        }
    }

    public List<Students> ReadAllStudents()
    {
        var studentRes = File.ReadAllText(_path);
        var studentJson = JsonSerializer.Deserialize<List<Students>>(studentRes);
        return studentJson;
    }

    public Students ReadStudentById(Guid studentId)
    {
        foreach (var student in _students)
        {
            if (object.Equals(student.Id, studentId))
            {
                return student;
            }
        }

        return null;
    }

    public void RemoveStudent(Guid studentId)
    {
        var findStudent = ReadStudentById(studentId);
        _students.Remove(findStudent);
        SaveData();
    }

    public void UpdateStudent(Students obj)
    {
        var updatingStudent = ReadStudentById(obj.Id);
        var index = _students.IndexOf(updatingStudent);
        _students[index] = obj;
        SaveData();
    }

    public Guid WriteStudent(Students student)
    {
        _students.Add(student);
        SaveData();
        return student.Id;
    }
}
