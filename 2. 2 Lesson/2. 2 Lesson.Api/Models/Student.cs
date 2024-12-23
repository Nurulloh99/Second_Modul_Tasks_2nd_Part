using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_Lesson.Api.Models;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public int Age { get; set; }
    public int Degree { get; set; }
    public string Gender { get; set; }
    public List<int> StudentTestResults { get; set; } = new List<int>();
}
