﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Lesson.Api.Services.DTOs;

public class UserGetDto : UserBaseDto
{
    public Guid Id { get; set; }
    
}
