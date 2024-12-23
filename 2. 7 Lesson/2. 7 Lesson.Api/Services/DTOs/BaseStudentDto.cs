using _2._7_Lesson.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7_Lesson.Api.Services.DTOs;

public class BaseStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public Degree Degree { get; set; }
    public Gender Gender { get; set; }
}
