﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6_Lesson_Api.Services.Dto;

public class StudentCreateDto : BaseStudentDto
{
    public string Password { get; set; }
}