using Student.Api.DataAccess.Entity;
using Student.Api.Repository;
using Student.Api.Services.DTOs;
using Student.Api.Services.Enums;

namespace Student.Api.Services;

public class StudentService : IStudentService
{
    public IStudentRepository _studentRepo;

    public StudentService()
    {
        _studentRepo = new StudentRepository();
    }

    public StudentGetDto AddStudent(StudentCreateDto student)
    {
        ValidateStudentCreateDto(student);
        var newStudent = ConvertStudent(student);
        newStudent.Id = Guid.NewGuid();
        _studentRepo.EmailContains(newStudent.Email);
        _studentRepo.WriteStudent(newStudent);
        return ConvertStudent(newStudent);
    }

    public void DeleteStudent(Guid studentId)
    {
        _studentRepo.RemoveStudent(studentId);
    }

    public List<StudentGetDto> GetAllStudents()
    {
        var getAllStudents = _studentRepo.ReadAllStudents();
        var allStudents = new List<StudentGetDto>();

        foreach (var student in getAllStudents)
        {
            allStudents.Add(ConvertStudent(student));
        }

        return allStudents;
    }

    public StudentGetDto GetStudentById(Guid studentId)
    {
        var studentById = _studentRepo.ReadStudentById(studentId);
        return ConvertStudent(studentById);
    }

    public object ReadAllStudentsByDegree(StudentDegree studentDegree)
    {
        var getAllStudents = _studentRepo.ReadAllStudents();
        var allStudents = new List<StudentGetDto>();

        foreach(var student in getAllStudents)
        {
            if (object.Equals(student.StatusDegree, studentDegree))
            {
                allStudents.Add(ConvertStudent(student));
            }
        }

        return allStudents;
    }

    public object ReadAllStudentsByGender(StudentGender studentGender)
    {
        var getAllStudents = _studentRepo.ReadAllStudents();
        var allStudents = new List<StudentGetDto>();

        foreach (var student in getAllStudents)
        {
            if(object.Equals(student.StatusGender, studentGender))
            {
                allStudents.Add(ConvertStudent(student));
            }
        }

        return allStudents;
    }

    public void UpdateStudent(StudentUpdateDto student)
    {
        _studentRepo.UpdateStudent(ConvertStudent(student));
    }

    private Students ConvertStudent(StudentCreateDto student)
    {
        return new Students
        {
            FirstName = student.FirstName,
            SecondName = student.SecondName,
            Age = student.Age,
            Email = student.Email,
            Password = student.Password,
            StatusGender = student.StatusGender,
            StatusDegree = student.StatusDegree,
        };
    }

    private Students ConvertStudent(StudentUpdateDto student)
    {
        return new Students
        {
            Id = student.Id,
            FirstName = student.FirstName,
            SecondName = student.SecondName,
            Age = student.Age,
            Email = student.Email,
            Password = student.Password,
            StatusGender = student.StatusGender,
            StatusDegree = student.StatusDegree,
        };
    }

    private StudentGetDto ConvertStudent(Students student)
    {
        return new StudentGetDto
        {
            Id= student.Id,
            FirstName = student.FirstName,
            SecondName = student.SecondName,
            Age = student.Age,
            Email = student.Email,
            StatusDegree = student.StatusDegree,
            StatusGender = student.StatusGender,
        };
    }

    private void ValidateStudentCreateDto(StudentCreateDto student)
    {
        if (string.IsNullOrWhiteSpace(student.FirstName) || student.FirstName.Length > 50)
        {
            throw new Exception("Error occured!");
        }

        if (string.IsNullOrWhiteSpace(student.SecondName) || student.SecondName.Length > 50)
        {
            throw new Exception("Error occured!");
        }

        if (student.Age < 15 || student.Age > 150)
        {
            throw new Exception("Error occured!!!");
        }

        if (!student.Email.EndsWith("@gmail.com") || student.Email.Length < 10)
        {
            throw new Exception("Error");
        }

        if (student.Password.Length < 8 || string.IsNullOrEmpty(student.Password))
        {
            throw new Exception("Error");
        }
    }
}
