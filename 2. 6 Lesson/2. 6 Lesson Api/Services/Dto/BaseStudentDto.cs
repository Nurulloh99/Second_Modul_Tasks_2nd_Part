using _2._6_Lesson_Api.DataAccess.Enums;
using _2._6_Lesson_Api.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6_Lesson_Api.Services.Dto;

public class BaseStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public GenderDto Gender { get; set; }
    public DegreeStatusDto Degree { get; set; }
}
