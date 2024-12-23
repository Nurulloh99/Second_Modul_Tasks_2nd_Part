using _2._6_Lesson_Api.DataAccess.Entities;
using System.Text.Json;

namespace _2._6_Lesson_Api.Repositories;

public class StudentRepositories : IStudentsRepositories
{

    private string _path = "../../../DataAccess/Data/Students.json";
    private List<Student> _students;

    public StudentRepositories()
    {
        _students = new List<Student>();

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _students = ReadAllStudents();
    }

    public void EmailContains(string email)
    {
        foreach(var student in _students)
        {
            if(student.Email == email)
            {
                throw new Exception($"This kind of email {student} already existed!");
            }
        }
    }

    void SaveData()
    {
        File.WriteAllText(_path, JsonSerializer.Serialize(_students));
    }

    public List<Student> ReadAllStudents()
    {
        return JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(_path));
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

        throw new Exception($"This student's ID: {studentId} has not been found!!!");
    }

    public void RemoveStudent(Guid studentId)
    {
        _students.Remove(ReadStudentById(studentId));
        SaveData();
    }

    public void UpdateStudent(Student student)
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
