﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7_Lesson.Api.Services.DTOs;

public class StudentCreateDto : BaseStudentDto
{
    public string Password { get; set; }
}
