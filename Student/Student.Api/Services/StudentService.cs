using Student.Api.DataAccess.Entities;
using Student.Api.Repositories;
using Student.Api.Services.DTOs;
using Student.Api.Services.Enums;

namespace Student.Api.Services;

public class StudentService : IStudentService
{
    public IStudentRepository studentRepo;

    public StudentService()
    {
        studentRepo = new StudentRepository();
    }


    public StudentGetDto AddStudent(StudentCreateDto studentDto)
    {
        ValidateStudentCreateDto(studentDto);
        var newStudent = ConvertStudent(studentDto);
        newStudent.Id = Guid.NewGuid();
        studentRepo.EmailConsists(newStudent.Email);
        studentRepo.WriteStudent(newStudent);
        return ConvertStudent(newStudent);
    }

    public void DeleteStudent(Guid deletingStudent)
    {
        studentRepo.RemoveStudent(deletingStudent);
    }

    public List<StudentGetDto> GetAllStudents()
    {
        var getAllStudents = studentRepo.ReadAllStudents();
        var allStudents = new List<StudentGetDto>();

        foreach (var student in getAllStudents)
        {
            allStudents.Add(ConvertStudent(student));
        }

        return allStudents;
    }

    public object GetStudentByDegree(StudentDegree degree)
    {
        var getAllStudents = studentRepo.ReadAllStudents();
        var allStudents = new List<StudentGetDto>();

        foreach (var student in getAllStudents)
        {
            if ((StudentDegree)student.StudentDegree == degree)
            {
                allStudents.Add(ConvertStudent(student));
            }
        }

        return allStudents;
    }

    public object GetStudentByGender(StudentGender gender)
    {
        var getAllStudents = studentRepo.ReadAllStudents();
        var allStudents = new List<StudentGetDto>();

        foreach (var student in getAllStudents)
        {
            if ((StudentGender)student.StudentGender == gender)
            {
                allStudents.Add(ConvertStudent(student));
            }
        }

        return allStudents;
    }

    public StudentGetDto GetStudentById(Guid studentDto)
    {
        var newStudent = studentRepo.ReadStudentById(studentDto);
        return ConvertStudent(newStudent);
    }

    public void UpdateStudent(StudentUpdateDto studentDto)
    {
        studentRepo.UpdateStudent(ConvertStudent(studentDto));
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
            StudentDegree = student.StudentDegree,
            StudentGender = student.StudentGender,
        };
    }

    private StudentGetDto ConvertStudent(Students student)
    {
        return new StudentGetDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            SecondName = student.SecondName,
            Age = student.Age,
            Email = student.Email,
            StudentDegree = student.StudentDegree,
            StudentGender = student.StudentGender,
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
            StudentDegree = student.StudentDegree,
            StudentGender = student.StudentGender,
        };
    }


    private void ValidateStudentCreateDto(StudentCreateDto studentDto)
    {
        if (string.IsNullOrWhiteSpace(studentDto.FirstName) || studentDto.FirstName.Length > 50)
        {
            throw new Exception("Error");
        }

        if (string.IsNullOrWhiteSpace(studentDto.SecondName) || studentDto.SecondName.Length > 50)
        {
            throw new Exception("Error");
        }

        if (studentDto.Age < 15 || studentDto.Age > 150)
        {
            throw new Exception("Error");
        }

        if (!studentDto.Email.EndsWith("@gmail.com") || studentDto.Email.Length < 10)
        {
            throw new Exception("Error");
        }

        if (studentDto.Password.StartsWith("(") && studentDto.Password.EndsWith(")") || studentDto.Password.Length < 8)
        {
            throw new Exception("Error");
        }
    }
}
