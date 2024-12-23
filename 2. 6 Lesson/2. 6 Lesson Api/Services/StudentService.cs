using _2._6_Lesson_Api.DataAccess.Entities;
using _2._6_Lesson_Api.Repositories;
using _2._6_Lesson_Api.Services.Dto;
using _2._6_Lesson_Api.Services.Enums;

namespace _2._6_Lesson_Api.Services;

public class StudentService : IStudentService
{

    private IStudentsRepositories StudentRepo;

    public StudentService()
    {
        StudentRepo = new StudentRepositories();
    }


    public StudentGetDto AddStudentDto(StudentCreateDto student)
    {
        ValidateStudentCreateDto(student);            // validatsiya qvotti

        var newStudent = ConvertStudent(student);     // StudentCreateDto dan kevotgan infoni student ga otqizvorvotti
        newStudent.Id = Guid.NewGuid();               // shu studentga ID yaratilinvotti
        StudentRepo.EmailContains(newStudent.Email);  // Tepada IStudentsRepositories dan StudentRepo nomi bilan obyekt olindi va undan shu email haqqattanam bomi yomi tekwirildi

        StudentRepo.WriteStudent(newStudent);         // Convert qlingan studentni qowibqoydm
        return ConvertStudent(newStudent);            // Passwordni yawirvotganim un ConvertStudent qilib qaytarilvotti
    }



    public void DeleteStudent(Guid studentId)
    {
        StudentRepo.RemoveStudent(studentId);
    }




    public List<StudentGetDto> GetAllStudents()
    {
        var students = StudentRepo.ReadAllStudents();
        var getStudentsList = new List<StudentGetDto>();

        foreach (var student in students)
        {
            getStudentsList.Add(ConvertStudent(student));
        }

        return getStudentsList;
    }



    public StudentGetDto GetStudentById(Guid studentId)
    {
        var studentById = StudentRepo.ReadStudentById(studentId);
        return ConvertStudent(studentById);
    }



    public List<StudentGetDto> GetStudentsByDegree(DegreeStatusDto status)
    {
        var students = StudentRepo.ReadAllStudents();
        var studentsByDegrees = new List<StudentGetDto>();

        foreach(var student in students)
        {
            if ((DegreeStatusDto)student.Degree == status)
            {
                studentsByDegrees.Add(ConvertStudent(student));
            }
        }
        return studentsByDegrees;
    }



    public List<StudentGetDto> GetStudentsByGender(GenderDto status)
    {
        var students = StudentRepo.ReadAllStudents();
        var studentByGender = new List<StudentGetDto>();

        foreach(var student in students)
        {
            if((GenderDto)student.Gender == status)
            {
                studentByGender.Add(ConvertStudent(student));
            }
        }

        return studentByGender;
    }




    public void UpdateStudent(StudentUpdateDto student)
    {
        StudentRepo.UpdateStudent(ConvertStudent(student));
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
            Degree = (DataAccess.Enums.DegreeStatus)studentDto.Degree,
            Gender = (DataAccess.Enums.Gender)studentDto.Gender,
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
            Degree = (DataAccess.Enums.DegreeStatus)studentDto.Degree,
            Gender = (DataAccess.Enums.Gender)studentDto.Gender,
        };
    }


    private StudentGetDto ConvertStudent(Student studentDto)
    {
        return new StudentGetDto()
        {
            Id = studentDto.Id,
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            Age = studentDto.Age,
            Email = studentDto.Email,
            Degree = (DegreeStatusDto)studentDto.Degree,
            Gender = (GenderDto)studentDto.Gender,
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


        if (student.Email.EndsWith("@gmail.com") && student.Email.Length < 10)
        {
            throw new Exception("Error occured!!!");
        }


        if (string.IsNullOrEmpty(student.Password) || student.Password.Length < 8)
        {
            throw new Exception("Error occured!!!");
        }
    }
}