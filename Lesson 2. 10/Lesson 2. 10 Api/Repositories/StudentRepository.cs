using System.Text.Json;
using Lesson_2._10_Api.DataAccess.Entities;

namespace Lesson_2._10_Api.Repositories;

public class StudentRepository : IStudentRepository
{
    public string _path = "../../../DataAccess/Data";
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

    public void SaveData()
    {
        File.WriteAllText(_path, JsonSerializer.Serialize(_students));
    }



    public Guid WriteStudent(Student student)
    {
        _students.Add(student);
        SaveData();
        return student.Id;
    }

    public List<Student> ReadAllStudents()
    {
        return JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(_path));
    }

    public Student ReadStudentById(Guid studentId)
    {
        foreach (var student in _students)
        {
            if (student.Id == studentId)
            {
                return student;
            }
        }

        return null;
    }

    public void MailContains(string mail)
    {
        foreach (var student in _students)
        {
            if (object.Equals(student.Mail, mail))
            {
                throw new Exception("Bunday email mavjud!");
            }
        }
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




}
