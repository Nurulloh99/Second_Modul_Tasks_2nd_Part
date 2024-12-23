using _2._6_Lesson_Api.Services.Dto;
using _2._6_Lesson_Api.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6_Lesson_Api.Services;

public interface IStudentService
{
    StudentGetDto AddStudentDto(StudentCreateDto student);
    StudentGetDto GetStudentById(Guid studentId);
    List<StudentGetDto> GetAllStudents();
    void DeleteStudent(Guid studentId);
    void UpdateStudent(StudentUpdateDto student);
    List<StudentGetDto> GetStudentsByDegree(DegreeStatusDto status);
    List<StudentGetDto> GetStudentsByGender(GenderDto status);
}