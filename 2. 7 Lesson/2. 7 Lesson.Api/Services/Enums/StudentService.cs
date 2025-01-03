using _2._7_Lesson.Api.Data_Access.Entities;
using _2._7_Lesson.Api.Repositories;
using _2._7_Lesson.Api.Services.DTOs;

namespace _2._7_Lesson.Api.Services.Enums;

public class StudentService : IStudentService
{

    private IStudentRepository studentRepo;

    public StudentService()
    {
        studentRepo = new StudentRepository();
    }


    public StudentGetDto AddStudentDto(StudentCreateDto student)
    {
        ValidateStudentCreateDto(student);
        var newStudent = ConvertStudent(student);
        newStudent.Id = Guid.NewGuid();
        studentRepo.EmailContains(newStudent.Email);
        studentRepo.WriteStudent(newStudent);
        return ConvertStudent(newStudent);
    }

    public void DeleteStudent(Guid studentId)
    {
        studentRepo.RemovingStudent(studentId);
    }

    public List<StudentGetDto> GetAllStudents()
    {
        var getAllStudents = studentRepo.ReadAllStudents();
        var allStudents = new List<StudentGetDto>();

        foreach(var student in getAllStudents)
        {
            allStudents.Add(ConvertStudent(student));
        }

        return allStudents;
    }

    public StudentGetDto GetStudentById(Guid studentId)
    {
        var studentById = studentRepo.ReadStudentById(studentId);
        return ConvertStudent(studentById);
    }

    public List<StudentGetDto> GetStudentsByDegree(DegreeStatusDto studentDegree)
    {
        var getAllStudents = studentRepo.ReadAllStudents();
        var allStudents = new List<StudentGetDto>();

        foreach(var student in getAllStudents)
        {
            if((DegreeStatusDto)student.Degree == studentDegree)
            {
                allStudents.Add(ConvertStudent(student));
            }
        }

        return allStudents;
    }

    public List<StudentGetDto> GetStudentsByGender(GenderDto studentGender)
    {
        var getAllStudents = studentRepo.ReadAllStudents();
        var allStudents = new List<StudentGetDto>();

        foreach (var student in getAllStudents)
        {
            if ((GenderDto)student.Gender == studentGender)
            {
                allStudents.Add(ConvertStudent(student));
            }
        }

        return allStudents;
    }

    public void UpdateStudent(StudentUpdateDto student)
    {
        studentRepo.UpdatingStudent(ConvertStudent(student));
    }


    private Student ConvertStudent(StudentUpdateDto studentDto)
    {
        return new Student()
        {
            Id = studentDto.Id,
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            Age = studentDto.Age,
            Email = studentDto.Email,
            Password = studentDto.Password,
            Degree = (DataAccess.Enums.Degree)studentDto.Degree,
            Gender = (DataAccess.Enums.Gender)studentDto.Gender
        };
    }


    private Student ConvertStudent(StudentCreateDto studentDto)
    {
        return new Student()
        {
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            Age = studentDto.Age,
            Email = studentDto.Email,
            Password = studentDto.Password,
            Degree = (DataAccess.Enums.Degree)studentDto.Degree,
            Gender = (DataAccess.Enums.Gender)studentDto.Gender
        };
    }

    private StudentGetDto ConvertStudent(Student student)
    {
        return new StudentGetDto()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Age = student.Age,
            Email = student.Email,
            Degree = (DegreeStatusDto)student.Degree,
            Gender = (GenderDto)student.Gender
        };
    }


    private void ValidateStudentCreateDto(StudentCreateDto student)
    {
        if (string.IsNullOrWhiteSpace(student.FirstName) || student.FirstName.Length > 50)
        {
            throw new Exception("Error occured!!!");
        }


        if (string.IsNullOrWhiteSpace(student.LastName) || student.LastName.Length > 50)
        {
            throw new Exception("Error occured!!!");
        }


        if (student.Age < 15 || student.Age > 150)
        {
            throw new Exception("Error occured!!!");
        }


        if (!student.Email.EndsWith("@gmail.com") && student.Email.Length < 10)
        {
            throw new Exception("Error occured!!!");
        }


        if (string.IsNullOrEmpty(student.Password) || student.Password.Length < 8)
        {
            throw new Exception("Error occured!!!");
        }
    }
}
