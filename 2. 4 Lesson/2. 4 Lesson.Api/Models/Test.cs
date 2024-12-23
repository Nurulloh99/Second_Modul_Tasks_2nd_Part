using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4_Lesson.Api.Models;

public class Test
{
    public Guid Id { get; set; }
    public string QuestionText { get; set; }
    public string A_Variant{ get; set; }
    public string B_Variant{ get; set; }
    public string C_Variant{ get; set; }
    public string Answer { get; set; }
}
