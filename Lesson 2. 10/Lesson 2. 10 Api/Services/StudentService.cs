using System.Net.Cache;
using Lesson_2._10_Api.DataAccess.Entities;
using Lesson_2._10_Api.Repositories;
using Lesson_2._10_Api.Services.DTOs;
using Lesson_2._10_Api.Services.Enums;

namespace Lesson_2._10_Api.Services;

public class StudentService : IStudentService
{

    private IStudentRepository studentRepo;

    public StudentService()
    {
        studentRepo = new StudentRepository();
    }



    public StudentGetDto AddStudent(StudentCreateDto student)
    {
        ValidateStudentCreateDto(student);
        var newStudent = ConvertStudent(student);
        newStudent.Id = Guid.NewGuid();
        studentRepo.MailContains(newStudent.Mail);
        studentRepo.WriteStudent(newStudent);
        return ConvertStudent(newStudent);
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


    public StudentGetDto GetStudentById(Guid studentId)
    {
        var getStudentById = studentRepo.ReadStudentById(studentId);
        return ConvertStudent(getStudentById);
    }

    public void DeleteStudent(Guid studentId)
    {
        studentRepo.RemoveStudent(studentId);
    }

    public void UpdateStudent(StudentUpdateDto student)
    {
        studentRepo.UpdateStudent(ConvertStudent(student));
    }

    public List<StudentGetDto> GetStudentsByGender(StudentGender studentGen)
    {
        var getAllStudents = studentRepo.ReadAllStudents();
        var allStudents = new List<StudentGetDto>();

        foreach (var student in getAllStudents)
        {
            if(object.Equals(student.MaleFemale, studentGen))
            {
                allStudents.Add(ConvertStudent(student));
            }
        }

        return allStudents;
    }

    public List<StudentGetDto> GetStudentsByDegree(StudentDegree studentDegree)
    {
        var getAllStudents = studentRepo.ReadAllStudents();
        var allStudents = new List<StudentGetDto>();

        foreach(var student in getAllStudents)
        {
            if(object.Equals(student.DegreeStatus, studentDegree))
            {
                allStudents.Add(ConvertStudent(student));
            }
        }

        return allStudents;
    }

    private Student ConvertStudent(StudentUpdateDto studentDto)
    {
        return new Student
        {
            Id = studentDto.Id,
            FirstName = studentDto.FirstName,
            SecondName = studentDto.SecondName,
            Age = studentDto.Age,
            Mail = studentDto.Mail,
            Password = studentDto.Password,
            DegreeStatus = studentDto.DegreeStatus,
            MaleFemale = studentDto.MaleFemale,
        };
    }


    private Student ConvertStudent(StudentCreateDto studentDto)
    {
        return new Student
        {
            FirstName = studentDto.FirstName,
            SecondName = studentDto.SecondName,
            Age = studentDto.Age,
            Mail = studentDto.Mail,
            Password = studentDto.Password,
            DegreeStatus = studentDto.DegreeStatus,
            MaleFemale= studentDto.MaleFemale,
        };
    }


    private StudentGetDto ConvertStudent(Student studentDto)
    {
        return new StudentGetDto
        {
            Id = studentDto.Id,
            FirstName = studentDto.FirstName,
            SecondName = studentDto.SecondName,
            Age = studentDto.Age,
            Mail = studentDto.Mail,
            DegreeStatus = studentDto.DegreeStatus,
            MaleFemale = studentDto.MaleFemale,
        };
    }


    private void ValidateStudentCreateDto(StudentCreateDto student)
    {
        if(string.IsNullOrEmpty(student.FirstName) || student.FirstName.Length > 50)
        {
            throw new Exception("Error Occured!");
        }

        if (string.IsNullOrEmpty(student.SecondName) || student.SecondName.Length > 50)
        {
            throw new Exception("Error Occured!");
        }

        if(student.Age < 15 || student.Age > 150)
        {
            throw new Exception("Error Occured!");
        }

        if(student.Mail.EndsWith("@gmail.com") || student.Mail.Length < 10)
        {
            throw new Exception("Error Occured!");
        }

        if(string.IsNullOrEmpty(student.Password) || student.Password.Length < 8)
        {
            throw new Exception("Error Occured!");
        }
    }


}

